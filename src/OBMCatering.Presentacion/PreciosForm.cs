using OBMCatering.Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OBMCatering.Presentacion
{
    public partial class PreciosForm : Form
    {
        IngredientesBL ingredientesBL;
        PreciosIngredientesBL preciosIngredientesBL;
        RecetasBL recetasBL;

        public PreciosForm()
        {
            InitializeComponent();
        }

        void PreciosForm_Load(object sender, EventArgs e)
        {
            ingredientesBL = new IngredientesBL(ContextoNegocio.Instancia);
            preciosIngredientesBL = new PreciosIngredientesBL(ContextoNegocio.Instancia);
            recetasBL = new RecetasBL(ContextoNegocio.Instancia, preciosIngredientesBL);

            btnGuardar.Click += BtnGuardar_Click;
            grvPrecios.SelectionChanged += GrvRecetas_SelectionChanged; ;
            grvPrecios.CellEnter += GrvRecetas_CellEnter;
            CargarUnidades();
            CargarPrecios();
            LimpiarFormulario();
        }

        void BtnGuardar_Click(object sender, EventArgs e)
        {
            Ingrediente ingrediente = ingredientesBL.Obtener(lblIngrediente.Text);
            PrecioIngrediente precioIngrediente = preciosIngredientesBL.Obtener(ingrediente);

            precioIngrediente.Precio = decimal.Parse(txtPrecio.Text);
            precioIngrediente.Cantidad = decimal.Parse(txtCantidad.Text);
            precioIngrediente.Unidad = (UnidadMedida)Enum.Parse(typeof(UnidadMedida), cboUnidad.SelectedItem.ToString());

            preciosIngredientesBL.Actualizar(precioIngrediente);
            recetasBL.ActualizarRecetasSinPrecio();
            CargarPrecios();
            LimpiarFormulario();
        }

        void GrvRecetas_SelectionChanged(object sender, EventArgs e)
        {
            int filasSeleccionadas = grvPrecios.SelectedRows.Count;

            if (filasSeleccionadas == 0 || filasSeleccionadas > 1) return;

            DataGridViewRow filaSeleccionada = grvPrecios.SelectedRows[0];
            PrecioIngredientePresentacion precioSeleccionado = (PrecioIngredientePresentacion)filaSeleccionada.DataBoundItem;

            CargarPrecioSeleccionado(precioSeleccionado);
        }

        void GrvRecetas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaSeleccionada = grvPrecios.Rows[e.RowIndex];

            filaSeleccionada.Selected = true;

            PrecioIngredientePresentacion precioSeleccionado = (PrecioIngredientePresentacion)filaSeleccionada.DataBoundItem;

            CargarPrecioSeleccionado(precioSeleccionado);
        }

        void CargarUnidades()
        {
            cboUnidad.Items.Add(UnidadMedida.gr.ToString());
            cboUnidad.Items.Add(UnidadMedida.ml.ToString());
            cboUnidad.Items.Add(UnidadMedida.unidad.ToString());
        }

        void CargarPrecios()
        {
            IEnumerable<PrecioIngrediente> precios = preciosIngredientesBL.Obtener();

            grvPrecios.DataSource = ObtenerPreciosPresentacion(precios);
        }

        IEnumerable<PrecioIngredientePresentacion> ObtenerPreciosPresentacion(IEnumerable<PrecioIngrediente> precios)
        {
            List<PrecioIngredientePresentacion> preciosPresentacion = new List<PrecioIngredientePresentacion>();

            foreach (PrecioIngrediente precio in precios)
            {
                preciosPresentacion.Add(new PrecioIngredientePresentacion(precio));
            }

            return preciosPresentacion;
        }

        void CargarPrecioSeleccionado(PrecioIngredientePresentacion precioSeleccionado)
        {
            lblIngrediente.Text = precioSeleccionado.Ingrediente;
            txtPrecio.Text = precioSeleccionado.Precio;
            txtCantidad.Text = precioSeleccionado.Cantidad;
            cboUnidad.SelectedItem = precioSeleccionado.Unidad;
        }

        void LimpiarFormulario()
        {
            lblIngrediente.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            cboUnidad.SelectedItem = null;
            grvPrecios.ClearSelection();
        }
    }
}
