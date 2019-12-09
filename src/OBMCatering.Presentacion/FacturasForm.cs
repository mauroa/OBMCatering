using OBMCatering.Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OBMCatering.Presentacion
{
    public partial class FacturasForm : Form
    {
        LocalidadesBL localidadesBL;
        ClientesBL clientesBL;
        PreciosIngredientesBL precioIngredientesBL;
        RecetasBL recetasBL;
        OrdenesVentaBL ordenesVentaBL;
        FacturasBL facturasBL;
        FacturaPresentacion facturaSeleccionada;

        public FacturasForm()
        {
            InitializeComponent();
        }

        void FacturasForm_Load(object sender, EventArgs e)
        {
            localidadesBL = new LocalidadesBL(ContextoNegocio.Instancia);
            clientesBL = new ClientesBL(ContextoNegocio.Instancia, localidadesBL);
            precioIngredientesBL = new PreciosIngredientesBL(ContextoNegocio.Instancia);
            recetasBL = new RecetasBL(ContextoNegocio.Instancia, precioIngredientesBL);
            ordenesVentaBL = new OrdenesVentaBL(ContextoNegocio.Instancia, recetasBL, clientesBL);
            facturasBL = new FacturasBL(ContextoNegocio.Instancia, ordenesVentaBL);

            btnCobrar.Click += BtnCobrar_Click;
            grvFacturas.SelectionChanged += GrvFacturas_SelectionChanged;
            grvFacturas.CellEnter += GrvFacturas_CellEnter;
            CargarFacturas();
            LimpiarFormulario();
        }

        void BtnCobrar_Click(object sender, EventArgs e)
        {
            Factura factura = facturasBL.Obtener(facturaSeleccionada.ObtenerId());

            factura.Cobrada = true;
            facturasBL.Actualizar(factura);

            CargarFacturas();
            LimpiarFormulario();
        }

        void GrvFacturas_SelectionChanged(object sender, EventArgs e)
        {
            int filasSeleccionadas = grvFacturas.SelectedRows.Count;

            if (filasSeleccionadas == 0 || filasSeleccionadas > 1) return;

            DataGridViewRow filaSeleccionada = grvFacturas.SelectedRows[0];
            FacturaPresentacion facturaSeleccionada = (FacturaPresentacion)filaSeleccionada.DataBoundItem;

            CargarFacturaSeleccionada(facturaSeleccionada);
        }

        void GrvFacturas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaSeleccionada = grvFacturas.Rows[e.RowIndex];

            filaSeleccionada.Selected = true;

            FacturaPresentacion facturaSeleccionada = (FacturaPresentacion)filaSeleccionada.DataBoundItem;

            CargarFacturaSeleccionada(facturaSeleccionada);
        }

        void CargarFacturas()
        {
            IEnumerable<Factura> facturas = facturasBL.Obtener();

            grvFacturas.DataSource = ObtenerFacturasPresentacion(facturas);
        }

        IEnumerable<FacturaPresentacion> ObtenerFacturasPresentacion(IEnumerable<Factura> facturas)
        {
            List<FacturaPresentacion> facturasPresentacion = new List<FacturaPresentacion>();

            foreach (Factura factura in facturas)
            {
                facturasPresentacion.Add(new FacturaPresentacion(factura));
            }

            return facturasPresentacion;
        }

        void CargarFacturaSeleccionada(FacturaPresentacion facturaPresentacion)
        {
            lblFecha.Text = facturaPresentacion.Fecha.ToShortDateString();
            lblCliente.Text = facturaPresentacion.Cliente;
            lblFechaInicio.Text = facturaPresentacion.FechaInicio.ToShortDateString();
            lblFechaFin.Text = facturaPresentacion.FechaFin.ToShortDateString();
            lblComensales.Text = facturaPresentacion.Comensales.ToString();
            lblRecetas.Text = facturaPresentacion.Recetas;
            lblPrecioCalculado.Text = facturaPresentacion.Precio.ToString();
            btnCobrar.Visible = !facturaPresentacion.Cobrada;
            facturaSeleccionada = facturaPresentacion;
        }

        void LimpiarFormulario()
        {
            lblFecha.Text = string.Empty;
            lblCliente.Text = string.Empty;
            lblFechaInicio.Text = string.Empty;
            lblFechaFin.Text = string.Empty;
            lblComensales.Text = string.Empty;
            lblRecetas.Text = string.Empty;
            lblPrecioCalculado.Text = string.Empty;
            btnCobrar.Visible = false;
            grvFacturas.ClearSelection();
        }
    }
}
