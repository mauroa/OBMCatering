using OBMCatering.Negocio;
using OBMCatering.Presentacion.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OBMCatering.Presentacion
{
    public partial class OrdenesPagoForm : Form
    {
        ContextoPresentacion contexto;
        LocalidadesBL localidadesBL;
        ClientesBL clientesBL;
        IngredientesBL ingredientesBL;
        PreciosIngredientesBL precioIngredientesBL;
        RecetasBL recetasBL;
        OrdenesVentaBL ordenesVentaBL;
        OrdenesCompraBL ordenesCompraBL;
        ProveedoresBL proveedoresBL;
        OrdenesPagoBL ordenesPagoBL;
        OrdenPagoPresentacion ordenPagoSeleccionada;

        public OrdenesPagoForm()
        {
            this.CargarLenguaje();
            InitializeComponent();

            Text = Resources.OrdenesPagoForm_Titulo;
            lblFechaTitulo.Text = Resources.OrdenesPagoForm_Datos_Fecha;
            lblProveedorTitulo.Text = Resources.OrdenesPagoForm_Datos_Proveedor;
            chkPagada.Text = Resources.OrdenesPagoForm_Datos_Pagada;
            lblItems.Text = Resources.OrdenesPagoForm_Datos_Items;
            btnGuardar.Text = Resources.OrdenesPagoForm_Datos_Guardar;
        }

        void OrdenesPago_Load(object sender, EventArgs e)
        {
            contexto = ContextoPresentacion.Instancia;
            localidadesBL = new LocalidadesBL(contexto.Negocio);
            clientesBL = new ClientesBL(contexto.Negocio, localidadesBL);
            ingredientesBL = new IngredientesBL(contexto.Negocio);
            precioIngredientesBL = new PreciosIngredientesBL(contexto.Negocio);
            recetasBL = new RecetasBL(contexto.Negocio, precioIngredientesBL);
            ordenesVentaBL = new OrdenesVentaBL(contexto.Negocio, recetasBL, clientesBL);
            ordenesCompraBL = new OrdenesCompraBL(contexto.Negocio, ordenesVentaBL, ingredientesBL);
            proveedoresBL = new ProveedoresBL(contexto.Negocio, localidadesBL);
            ordenesPagoBL = new OrdenesPagoBL(contexto.Negocio, proveedoresBL, ordenesCompraBL);

            btnGuardar.Click += BtnGuardar_Click;
            grvOrdenesPago.SelectionChanged += GrvOrdenesPago_SelectionChanged;
            grvOrdenesPago.CellEnter += GrvOrdenesPago_CellEnter;
            CargarOrdenesPago();
            LimpiarFormulario();

            contexto.RegistrarEvento(Resources.OrdenesPagoForm_Ingreso);
        }

        void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                IEnumerable<ItemOrdenPagoPresentacion> itemsOrdenesPagoPresentacion = (IEnumerable<ItemOrdenPagoPresentacion>)grvItems.DataSource;
                OrdenPago ordenPago = ordenesPagoBL.Obtener(ordenPagoSeleccionada.ObtenerId());

                foreach (ItemOrdenPago item in ordenPago.Items)
                {
                    ItemOrdenPagoPresentacion itemOrdenPagoPresentacion = null;

                    foreach (ItemOrdenPagoPresentacion itemPresentacion in itemsOrdenesPagoPresentacion)
                    {
                        if (itemPresentacion.Ingrediente == item.ItemOrdenCompra.Ingrediente.Nombre)
                        {
                            itemOrdenPagoPresentacion = itemPresentacion;
                            break;
                        }
                    }

                    if (itemOrdenPagoPresentacion != null)
                    {
                        item.Precio = decimal.Parse(itemOrdenPagoPresentacion.Precio);
                    }
                }

                ordenPago.Pagada = chkPagada.Checked;
                ordenesPagoBL.Actualizar(ordenPago);

                CargarOrdenesPago();
                LimpiarFormulario();

                contexto.RegistrarEvento(Resources.OrdenesPagoForm_OrdenPagoActualizada, ordenPago.Proveedor.Nombre);
            }
            catch(Exception ex)
            {
                contexto.RegistrarError(ex);
            }
        }

        void GrvOrdenesPago_SelectionChanged(object sender, EventArgs e)
        {
            int filasSeleccionadas = grvOrdenesPago.SelectedRows.Count;

            if (filasSeleccionadas == 0 || filasSeleccionadas > 1) return;

            DataGridViewRow filaSeleccionada = grvOrdenesPago.SelectedRows[0];
            OrdenPagoPresentacion ordenPagoSeleccionada = (OrdenPagoPresentacion)filaSeleccionada.DataBoundItem;

            CargarOrdenPagoSeleccionada(ordenPagoSeleccionada);
        }

        void GrvOrdenesPago_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaSeleccionada = grvOrdenesPago.Rows[e.RowIndex];

            filaSeleccionada.Selected = true;

            OrdenPagoPresentacion ordenPagoSeleccionada = (OrdenPagoPresentacion)filaSeleccionada.DataBoundItem;

            CargarOrdenPagoSeleccionada(ordenPagoSeleccionada);
        }

        void CargarOrdenesPago()
        {
            try
            {
                IEnumerable<OrdenPago> ordenesPago = ordenesPagoBL.Obtener();

                grvOrdenesPago.DataSource = ObtenerOrdenesPagoPresentacion(ordenesPago);
            }
            catch (Exception ex)
            {
                contexto.RegistrarError(ex);
            }
        }

        IEnumerable<OrdenPagoPresentacion> ObtenerOrdenesPagoPresentacion(IEnumerable<OrdenPago> ordenesPago)
        {
            List<OrdenPagoPresentacion> ordenesPagoPresentacion = new List<OrdenPagoPresentacion>();

            foreach (OrdenPago ordenPago in ordenesPago)
            {
                ordenesPagoPresentacion.Add(new OrdenPagoPresentacion(ordenPago));
            }

            return ordenesPagoPresentacion;
        }

        void CargarOrdenPagoSeleccionada(OrdenPagoPresentacion ordenPagoPresentacion)
        {
            lblFecha.Text = ordenPagoPresentacion.Fecha.ToShortDateString();
            lblProveedor.Text = ordenPagoPresentacion.Proveedor;
            chkPagada.Checked = ordenPagoPresentacion.Pagada;
            grvItems.DataSource = ordenPagoPresentacion.ObtenerItems();
            grvItems.ReadOnly = ordenPagoPresentacion.Pagada;
            btnGuardar.Visible = !ordenPagoPresentacion.Pagada;
            ordenPagoSeleccionada = ordenPagoPresentacion;
        }

        void LimpiarFormulario()
        {
            lblFecha.Text = string.Empty;
            lblProveedor.Text = string.Empty;
            chkPagada.Checked = false;
            grvOrdenesPago.ClearSelection();
            grvItems.DataSource = new List<ItemOrdenPagoPresentacion>();
            btnGuardar.Visible = false;
            ordenPagoSeleccionada = null;
        }
    }
}
