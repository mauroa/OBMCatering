using OBMCatering.Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace OBMCatering.Presentacion
{
    public partial class OrdenesVentaForm : Form
    {
        LocalidadesBL localidadesBL;
        ClientesBL clientesBL;
        IngredientesBL ingredientesBL;
        PreciosIngredientesBL precioIngredientesBL;
        RecetasBL recetasBL;
        OrdenesVentaBL ordenesVentaBL;
        FacturasBL facturasBL;
        OrdenesCompraBL ordenesCompraBL;
        OrdenVentaPresentacion ordenVentaSeleccionada;

        public OrdenesVentaForm()
        {
            InitializeComponent();
        }

        void OrdenesVentaForm_Load(object sender, EventArgs e)
        {
            localidadesBL = new LocalidadesBL(ContextoNegocio.Instancia);
            clientesBL = new ClientesBL(ContextoNegocio.Instancia, localidadesBL);
            ingredientesBL = new IngredientesBL(ContextoNegocio.Instancia);
            precioIngredientesBL = new PreciosIngredientesBL(ContextoNegocio.Instancia);
            recetasBL = new RecetasBL(ContextoNegocio.Instancia, precioIngredientesBL);
            ordenesVentaBL = new OrdenesVentaBL(ContextoNegocio.Instancia, recetasBL, clientesBL);
            facturasBL = new FacturasBL(ContextoNegocio.Instancia, ordenesVentaBL);
            ordenesCompraBL = new OrdenesCompraBL(ContextoNegocio.Instancia, ordenesVentaBL, ingredientesBL);

            btnGuardar.Click += BtnGuardar_Click;
            btnCalcularPrecio.Click += BtnCalcularPrecio_Click;
            grvPedidos.SelectionChanged += GrvPedidos_SelectionChanged;
            grvPedidos.CellEnter += GrvPedidos_CellEnter;
            CargarClientes();
            CargarRecetas();
            CargarOrdenesVenta();
            LimpiarFormulario();
        }

        void BtnGuardar_Click(object sender, EventArgs e)
        {
            bool existeOrdenVenta = ordenesVentaBL.Existe(ordenVentaSeleccionada.ObtenerId());
            OrdenVenta ordenVenta;

            if (existeOrdenVenta)
            {
                ordenVenta = ordenesVentaBL.Obtener(ordenVentaSeleccionada.ObtenerId());
                SetearOrdenVenta(ordenVenta);
                ordenesVentaBL.Actualizar(ordenVenta);
            }
            else
            {
                ordenVenta = Crear();
                ordenesVentaBL.Crear(ordenVenta);
            }

            if(!ordenVentaSeleccionada.Aprobada && ordenVenta.Aprobada)
            {
                CrearFactura();
                CrearOrdenCompra();
            }

            CargarOrdenesVenta();
            LimpiarFormulario();
        }

        void BtnCalcularPrecio_Click(object sender, EventArgs e)
        {
            OrdenVenta ordenVenta = Crear();
            decimal precio = ordenesVentaBL.CalcularPrecio(ordenVenta);

            lblPrecioCalculado.Text = precio.ToString();
        }

        void GrvPedidos_SelectionChanged(object sender, EventArgs e)
        {
            int filasSeleccionadas = grvPedidos.SelectedRows.Count;

            if (filasSeleccionadas == 0 || filasSeleccionadas > 1) return;

            DataGridViewRow filaSeleccionada = grvPedidos.SelectedRows[0];
            OrdenVentaPresentacion ordenVentaSeleccionada = (OrdenVentaPresentacion)filaSeleccionada.DataBoundItem;

            CargarOrdenVentaSeleccionada(ordenVentaSeleccionada);
        }

        void GrvPedidos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaSeleccionada = grvPedidos.Rows[e.RowIndex];

            filaSeleccionada.Selected = true;

            OrdenVentaPresentacion ordenVentaSeleccionada = (OrdenVentaPresentacion)filaSeleccionada.DataBoundItem;

            CargarOrdenVentaSeleccionada(ordenVentaSeleccionada);
        }

        void CargarClientes()
        {
            IEnumerable<Cliente> clientes = clientesBL.ObtenerActivos();

            foreach(Cliente cliente in clientes)
            {
                cboClientes.Items.Add(cliente.Nombre);
            }
        }

        void CargarRecetas()
        {
            IEnumerable<Receta> recetas = recetasBL.Obtener(EstadoReceta.Activa);

            foreach(Receta receta in recetas)
            {
                lstRecetas.Items.Add(receta.Nombre);
            }
        }

        void CargarOrdenesVenta()
        {
            IEnumerable<OrdenVenta> ordenesVenta = ordenesVentaBL.Obtener();

            grvPedidos.DataSource = ObtenerOrdenesVentaPresentacion(ordenesVenta);
        }

        IEnumerable<OrdenVentaPresentacion> ObtenerOrdenesVentaPresentacion(IEnumerable<OrdenVenta> ordenesVenta)
        {
            List<OrdenVentaPresentacion> ordenesVentaPresentacion = new List<OrdenVentaPresentacion>();

            foreach (OrdenVenta ordenVenta in ordenesVenta)
            {
                ordenesVentaPresentacion.Add(new OrdenVentaPresentacion(ordenVenta));
            }

            return ordenesVentaPresentacion;
        }

        OrdenVenta Crear()
        {
            Cliente cliente = clientesBL.ObtenerPorNombre(cboClientes.SelectedItem.ToString());
            OrdenVenta ordenVenta = new OrdenVenta();

            SetearOrdenVenta(ordenVenta);
            ordenVenta.Cliente = cliente;

            return ordenVenta;
        }

        void SetearOrdenVenta(OrdenVenta ordenVenta)
        {
            ordenVenta.FechaInicio = dtpFechaInicio.Value;
            ordenVenta.FechaFin = dtpFechaFin.Value;
            ordenVenta.Comensales = int.Parse(txtComensales.Text);

            if(!string.IsNullOrEmpty(lblPrecioCalculado.Text))
            {
                ordenVenta.Precio = decimal.Parse(lblPrecioCalculado.Text);
            }

            ordenVenta.Aprobada = chkAprobada.Checked;

            foreach(Receta receta in ordenVenta.Recetas.ToList())
            {
                if(!lstRecetas.Items.Contains(receta.Nombre))
                {
                    ordenVenta.Recetas.Remove(receta);
                }
            }

            foreach(object item in lstRecetas.SelectedItems)
            {
                bool existeReceta = false;

                foreach (Receta receta in ordenVenta.Recetas)
                {
                    if(receta.Nombre == item.ToString())
                    {
                        existeReceta = true;
                        break;
                    }
                }

                if(!existeReceta)
                {
                    Receta receta = recetasBL.Obtener(item.ToString());

                    ordenVenta.Recetas.Add(receta);
                }
            }
        }

        void CargarOrdenVentaSeleccionada(OrdenVentaPresentacion ordenVentaPresentacion)
        {
            cboClientes.SelectedItem = ordenVentaPresentacion.Cliente;
            dtpFechaInicio.Value = ordenVentaPresentacion.FechaInicio;
            dtpFechaFin.Value = ordenVentaPresentacion.FechaFin;
            txtComensales.Text = ordenVentaPresentacion.Comensales;
            chkAprobada.Checked = ordenVentaPresentacion.Aprobada;

            lstRecetas.ClearSelected();

            for(int i = 0; i < lstRecetas.Items.Count; i++)
            {
                string receta = lstRecetas.Items[i].ToString();

                IEnumerable<string> recetas = ordenVentaPresentacion.ObtenerRecetas();

                if (recetas.Contains(receta))
                {
                    lstRecetas.SetSelected(i, true);
                }
            }

            lblPrecioCalculado.Text = ordenVentaPresentacion.Precio;
            ordenVentaSeleccionada = ordenVentaPresentacion;
        }

        void CrearFactura()
        {
            OrdenVenta ordenVenta = ordenesVentaBL.Obtener(ordenVentaSeleccionada.ObtenerId());
            Factura factura = new Factura();

            factura.OrdenVenta = ordenVenta;
            factura.Fecha = DateTime.Now;

            facturasBL.Crear(factura);
        }

        void CrearOrdenCompra()
        {
            OrdenVenta ordenVenta = ordenesVentaBL.Obtener(ordenVentaSeleccionada.ObtenerId());

            ordenesCompraBL.Crear(ordenVenta);
        }

        void LimpiarFormulario()
        {
            cboClientes.SelectedItem = null;
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;
            txtComensales.Text = string.Empty;
            chkAprobada.Checked = false;
            lstRecetas.ClearSelected();
            lblPrecioCalculado.Text = string.Empty;
            grvPedidos.ClearSelection();
            ordenVentaSeleccionada = null;
        }
    }
}
