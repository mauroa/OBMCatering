using OBMCatering.Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OBMCatering.Presentacion
{
    public partial class OrdenesCompraForm : Form
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
        OrdenCompraPresentacion ordenCompraSeleccionada;

        public OrdenesCompraForm()
        {
            InitializeComponent();
        }

        void OrdenesCompra_Load(object sender, EventArgs e)
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
            grvOrdenesCompra.SelectionChanged += GrvOrdenesCompra_SelectionChanged;
            grvOrdenesCompra.CellEnter += GrvOrdenesCompra_CellEnter;
            CargarProveedores();
            CargarOrdenesCompra();
            LimpiarFormulario();

            contexto.RegistrarEvento("Ingreso a la pantalla de ordenes de compra");
        }

        void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                OrdenCompra ordenCompra = ordenesCompraBL.Obtener(ordenCompraSeleccionada.ObtenerId());
                EstadoOrdenCompra nuevoEstado = EstadoOrdenCompra.Generada;

                if (ordenCompra.Estado == EstadoOrdenCompra.Generada)
                {
                    nuevoEstado = EstadoOrdenCompra.Aprobada;
                }
                else if (ordenCompra.Estado == EstadoOrdenCompra.Aprobada)
                {
                    nuevoEstado = EstadoOrdenCompra.Realizada;
                }

                ordenCompra.Estado = nuevoEstado;
                ordenesCompraBL.Actualizar(ordenCompra);

                contexto.RegistrarEvento("La orden de compra para el pedido de {0} ha sido actualizada", ordenCompra.OrdenVenta.Cliente.Nombre);

                if (nuevoEstado == EstadoOrdenCompra.Realizada)
                {
                    CrearOrdenPago();
                }

                CargarOrdenesCompra();
                LimpiarFormulario();
            }
            catch(Exception ex)
            {
                contexto.RegistrarError(ex);
            }
        }

        void GrvOrdenesCompra_SelectionChanged(object sender, EventArgs e)
        {
            int filasSeleccionadas = grvOrdenesCompra.SelectedRows.Count;

            if (filasSeleccionadas == 0 || filasSeleccionadas > 1) return;

            DataGridViewRow filaSeleccionada = grvOrdenesCompra.SelectedRows[0];
            OrdenCompraPresentacion ordenCompraSeleccionada = (OrdenCompraPresentacion)filaSeleccionada.DataBoundItem;

            CargarOrdenCompraSeleccionada(ordenCompraSeleccionada);
        }

        void GrvOrdenesCompra_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaSeleccionada = grvOrdenesCompra.Rows[e.RowIndex];

            filaSeleccionada.Selected = true;

            OrdenCompraPresentacion ordenCompraSeleccionada = (OrdenCompraPresentacion)filaSeleccionada.DataBoundItem;

            CargarOrdenCompraSeleccionada(ordenCompraSeleccionada);
        }

        void CargarProveedores()
        {
            try
            {
                IEnumerable<Proveedor> proveedores = proveedoresBL.ObtenerActivos();

                foreach (Proveedor proveedor in proveedores)
                {
                    cboProveedor.Items.Add(proveedor.Nombre);
                }
            }
            catch (Exception ex)
            {
                contexto.RegistrarError(ex);
            }
        }

        void CrearOrdenPago()
        {
            OrdenPago ordenPago = new OrdenPago();
            Proveedor proveedor = proveedoresBL.ObtenerPorNombre(cboProveedor.SelectedItem.ToString());

            ordenPago.Fecha = DateTime.Now;
            ordenPago.Pagada = false;
            ordenPago.Proveedor = proveedor;

            foreach (ItemOrdenCompraPresentacion itemOrdenCompra in ordenCompraSeleccionada.ObtenerItems())
            {
                ItemOrdenPago itemOrdenPago = new ItemOrdenPago();

                itemOrdenPago.ItemOrdenCompra = itemOrdenCompra.ObtenerItemOrdenCompra();
                itemOrdenPago.Precio = 0m;

                ordenPago.Items.Add(itemOrdenPago);
            }

            ordenesPagoBL.Crear(ordenPago);
            contexto.RegistrarEvento("La orden de pago para el proveedor {0} ha sido creada", proveedor.Nombre);
        }

        void CargarOrdenesCompra()
        {
            try
            {
                IEnumerable<OrdenCompra> ordenesCompra = ordenesCompraBL.Obtener();

                grvOrdenesCompra.DataSource = ObtenerOrdenesCompraPresentacion(ordenesCompra);
            }
            catch (Exception ex)
            {
                contexto.RegistrarError(ex);
            }
        }

        IEnumerable<OrdenCompraPresentacion> ObtenerOrdenesCompraPresentacion(IEnumerable<OrdenCompra> ordenesCompra)
        {
            List<OrdenCompraPresentacion> ordenesCompraPresentacion = new List<OrdenCompraPresentacion>();

            foreach (OrdenCompra ordenCompra in ordenesCompra)
            {
                ordenesCompraPresentacion.Add(new OrdenCompraPresentacion(ordenCompra));
            }

            return ordenesCompraPresentacion;
        }

        void CargarOrdenCompraSeleccionada(OrdenCompraPresentacion ordenCompraPresentacion)
        {
            lblFecha.Text = ordenCompraPresentacion.Fecha.ToShortDateString();
            lblCliente.Text = ordenCompraPresentacion.Cliente;
            lblEstado.Text = ordenCompraPresentacion.Estado;

            if(ordenCompraPresentacion.Estado == EstadoOrdenCompra.Aprobada.ToString())
            {
                lblProveedorTitulo.Visible = true;
                cboProveedor.Visible = true;
                btnGuardar.Text = "Realizada";
            }
            else
            {
                lblProveedorTitulo.Visible = false;
                cboProveedor.Visible = false;
                btnGuardar.Text = "Aprobar";
            }

            btnGuardar.Visible = ordenCompraPresentacion.Estado != EstadoOrdenCompra.Realizada.ToString();
            grvIngredientes.DataSource = ordenCompraPresentacion.ObtenerItems();
            ordenCompraSeleccionada = ordenCompraPresentacion;
        }

        void LimpiarFormulario()
        {
            lblFecha.Text = string.Empty;
            lblCliente.Text = string.Empty;
            lblEstado.Text = string.Empty;
            grvOrdenesCompra.ClearSelection();
            grvIngredientes.DataSource = new List<ItemOrdenCompraPresentacion>();
            lblProveedorTitulo.Visible = false;
            cboProveedor.Visible = false;
            btnGuardar.Visible = false;
            ordenCompraSeleccionada = null;
        }
    }
}
