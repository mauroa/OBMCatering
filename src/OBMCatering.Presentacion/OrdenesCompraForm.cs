using OBMCatering.Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OBMCatering.Presentacion
{
    public partial class OrdenesCompraForm : Form
    {
        LocalidadesBL localidadesBL;
        ClientesBL clientesBL;
        IngredientesBL ingredientesBL;
        PreciosIngredientesBL precioIngredientesBL;
        RecetasBL recetasBL;
        OrdenesVentaBL ordenesVentaBL;
        FacturasBL facturasBL;
        OrdenesCompraBL ordenesCompraBL;
        OrdenCompraPresentacion ordenCompraSeleccionada;

        public OrdenesCompraForm()
        {
            InitializeComponent();
        }

        void OrdenesCompra_Load(object sender, EventArgs e)
        {
            localidadesBL = new LocalidadesBL(ContextoNegocio.Instancia);
            clientesBL = new ClientesBL(ContextoNegocio.Instancia, localidadesBL);
            ingredientesBL = new IngredientesBL(ContextoNegocio.Instancia);
            precioIngredientesBL = new PreciosIngredientesBL(ContextoNegocio.Instancia);
            recetasBL = new RecetasBL(ContextoNegocio.Instancia, precioIngredientesBL);
            ordenesVentaBL = new OrdenesVentaBL(ContextoNegocio.Instancia, recetasBL, clientesBL);
            ordenesCompraBL = new OrdenesCompraBL(ContextoNegocio.Instancia, ordenesVentaBL, ingredientesBL);

            btnAprobar.Click += BtnAprobar_Click;
            grvOrdenesCompra.SelectionChanged += GrvOrdenesCompra_SelectionChanged;
            grvOrdenesCompra.CellEnter += GrvOrdenesCompra_CellEnter;
            CargarOrdenesCompra();
            LimpiarFormulario();
        }

        void BtnAprobar_Click(object sender, EventArgs e)
        {
            OrdenCompra ordenCompra = ordenesCompraBL.Obtener(ordenCompraSeleccionada.ObtenerId());

            ordenCompra.Ejecutada = true;
            ordenesCompraBL.Actualizar(ordenCompra);

            CargarOrdenesCompra();
            LimpiarFormulario();
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

        void CargarOrdenesCompra()
        {
            IEnumerable<OrdenCompra> ordenesCompra = ordenesCompraBL.Obtener();

            grvOrdenesCompra.DataSource = ObtenerOrdenesCompraPresentacion(ordenesCompra);
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
            btnAprobar.Visible = !ordenCompraPresentacion.Ejecutada;
            grvIngredientes.DataSource = ordenCompraPresentacion.ObtenerItems();
            ordenCompraSeleccionada = ordenCompraPresentacion;
        }

        void LimpiarFormulario()
        {
            lblFecha.Text = string.Empty;
            lblCliente.Text = string.Empty;
            grvOrdenesCompra.ClearSelection();
            grvIngredientes.DataSource = new List<ItemOrdenCompraPresentacion>();
            btnAprobar.Visible = false;
            ordenCompraSeleccionada = null;
        }
    }
}
