using OBMCatering.Negocio;
using OBMCatering.Presentacion.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OBMCatering.Presentacion
{
    public partial class PreciosForm : Form
    {
        ContextoPresentacion contexto;
        IngredientesBL ingredientesBL;
        PreciosIngredientesBL preciosIngredientesBL;
        RecetasBL recetasBL;

        public PreciosForm()
        {
            this.CargarLenguaje();
            InitializeComponent();

            Text = Resources.PreciosForm_Titulo;
            lblIngredienteTitulo.Text = Resources.PreciosForm_Datos_Ingrediente;
            lblPrecio.Text = Resources.PreciosForm_Datos_Precio;
            lblCantidad.Text = Resources.PreciosForm_Datos_Cantidad;
            lblUnidad.Text = Resources.PreciosForm_Datos_Unidad;
            btnGuardar.Text = Resources.PreciosForm_Datos_Guardar;

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            HelpButton = true;
            HelpRequested += PreciosForm_HelpRequested;
        }

        void PreciosForm_Load(object sender, EventArgs e)
        {
            AcceptButton = btnGuardar;

            contexto = ContextoPresentacion.Instancia;
            ingredientesBL = new IngredientesBL(contexto.Negocio);
            preciosIngredientesBL = new PreciosIngredientesBL(contexto.Negocio);
            recetasBL = new RecetasBL(contexto.Negocio, preciosIngredientesBL);

            btnGuardar.Click += BtnGuardar_Click;
            grvPrecios.SelectionChanged += GrvRecetas_SelectionChanged; ;
            grvPrecios.CellEnter += GrvRecetas_CellEnter;
            CargarUnidades();
            CargarPrecios();
            LimpiarFormulario();

            contexto.RegistrarEvento(Resources.PreciosForm_Ingreso);
        }

        void PreciosForm_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(Resources.PreciosForm_Help_Mensaje, Resources.Form_Help_Titulo, MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
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

                contexto.RegistrarEvento(Resources.PreciosForm_ListaActualizada, ingrediente.Nombre);
            }
            catch(Exception ex)
            {
                contexto.RegistrarError(ex);
            }
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
            cboUnidad.Items.Add(UnidadMedida.u.ToString());
        }

        void CargarPrecios()
        {
            try
            {
                IEnumerable<PrecioIngrediente> precios = preciosIngredientesBL.Obtener();

                grvPrecios.DataSource = ObtenerPreciosPresentacion(precios);
            }
            catch (Exception ex)
            {
                contexto.RegistrarError(ex);
            }
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
