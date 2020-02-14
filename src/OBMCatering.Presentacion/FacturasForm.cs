using OBMCatering.Negocio;
using OBMCatering.Presentacion.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OBMCatering.Presentacion
{
    public partial class FacturasForm : Form
    {
        ContextoPresentacion contexto;
        LocalidadesBL localidadesBL;
        ClientesBL clientesBL;
        PreciosIngredientesBL precioIngredientesBL;
        RecetasBL recetasBL;
        OrdenesVentaBL ordenesVentaBL;
        FacturasBL facturasBL;
        FacturaPresentacion facturaSeleccionada;

        public FacturasForm()
        {
            this.CargarLenguaje();
            InitializeComponent();

            Text = Resources.FacturasForm_Titulo;
            lblFechaTitulo.Text = Resources.FacturasForm_Datos_Fecha;
            lblClienteTitulo.Text = Resources.FacturasForm_Datos_Cliente;
            lblFechaInicioTitulo.Text = Resources.FacturasForm_Datos_Desde;
            lblFechaFinTitulo.Text = Resources.FacturasForm_Datos_Hasta;
            lblComensalesTitulo.Text = Resources.FacturasForm_Datos_Comensales;
            lblRecetasTitulo.Text = Resources.FacturasForm_Datos_Recetas;
            lblPrecio.Text = Resources.FacturasForm_Datos_Precio;
            btnCobrada.Text = Resources.FacturasForm_Cobrada;
        }

        void FacturasForm_Load(object sender, EventArgs e)
        {
            contexto = ContextoPresentacion.Instancia;
            localidadesBL = new LocalidadesBL(contexto.Negocio);
            clientesBL = new ClientesBL(contexto.Negocio, localidadesBL);
            precioIngredientesBL = new PreciosIngredientesBL(contexto.Negocio);
            recetasBL = new RecetasBL(contexto.Negocio, precioIngredientesBL);
            ordenesVentaBL = new OrdenesVentaBL(contexto.Negocio, recetasBL, clientesBL);
            facturasBL = new FacturasBL(contexto.Negocio, ordenesVentaBL);

            btnCobrada.Click += BtnCobrada_Click;
            grvFacturas.SelectionChanged += GrvFacturas_SelectionChanged;
            grvFacturas.CellEnter += GrvFacturas_CellEnter;
            CargarFacturas();
            LimpiarFormulario();

            contexto.RegistrarEvento(Resources.FacturasForm_Ingreso);
        }

        void BtnCobrada_Click(object sender, EventArgs e)
        {
            try
            {
                Factura factura = facturasBL.Obtener(facturaSeleccionada.ObtenerId());

                factura.Cobrada = true;
                facturasBL.Actualizar(factura);

                CargarFacturas();
                LimpiarFormulario();

                contexto.RegistrarEvento(Resources.FacturasForm_FacturaCobrada, factura.OrdenVenta.Cliente.Nombre);
            }
            catch(Exception ex)
            {
                contexto.RegistrarError(ex);
            }
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
            try
            {
                IEnumerable<Factura> facturas = facturasBL.Obtener();

                grvFacturas.DataSource = ObtenerFacturasPresentacion(facturas);
            }
            catch (Exception ex)
            {
                contexto.RegistrarError(ex);
            }
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
            btnCobrada.Visible = !facturaPresentacion.Cobrada;
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
            btnCobrada.Visible = false;
            grvFacturas.ClearSelection();
        }
    }
}
