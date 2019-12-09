using OBMCatering.Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OBMCatering.Presentacion
{
    public partial class RecetasForm : Form
    {
        PreciosIngredientesBL preciosIngredientesBL;
        RecetasBL recetasBL;

        public RecetasForm()
        {
            InitializeComponent();
        }

        void RecetasForm_Load(object sender, EventArgs e)
        {
            preciosIngredientesBL = new PreciosIngredientesBL(ContextoNegocio.Instancia);
            recetasBL = new RecetasBL(ContextoNegocio.Instancia, preciosIngredientesBL);

            btnGuardar.Click += BtnGuardar_Click;
            btnVer.Click += BtnVer_Click; ;
            grvRecetas.SelectionChanged += GrvRecetas_SelectionChanged; ;
            grvRecetas.CellEnter += GrvRecetas_CellEnter;
            CargarRecetas();
            LimpiarFormulario();
        }

        void BtnGuardar_Click(object sender, EventArgs e)
        {
            bool existeReceta = recetasBL.Existe(txtNombre.Text);
            Receta receta;

            if (existeReceta)
            {
                receta = recetasBL.Obtener(txtNombre.Text);

                SetearReceta(receta);
                recetasBL.Actualizar(receta); ;
            }
            else
            {
                receta = new Receta();

                SetearReceta(receta);
                recetasBL.Crear(receta);
            }

            CargarRecetas();
            LimpiarFormulario();
        }

        void BtnVer_Click(object sender, EventArgs e)
        {
            IngredientesForm form = new IngredientesForm();
            DataGridViewRow filaSeleccionada = grvRecetas.SelectedRows[0];
            RecetaPresentacion recetaSeleccionada = (RecetaPresentacion)filaSeleccionada.DataBoundItem;

            form.Receta = recetaSeleccionada;
            form.Text = "Ingredientes " + recetaSeleccionada.Nombre;
            form.Show();
        }

        void GrvRecetas_SelectionChanged(object sender, EventArgs e)
        {
            int filasSeleccionadas = grvRecetas.SelectedRows.Count;

            if (filasSeleccionadas == 0 || filasSeleccionadas > 1) return;

            DataGridViewRow filaSeleccionada = grvRecetas.SelectedRows[0];
            RecetaPresentacion recetaSeleccionada = (RecetaPresentacion)filaSeleccionada.DataBoundItem;

            CargarRecetaSeleccionada(recetaSeleccionada);
        }

        void GrvRecetas_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaSeleccionada = grvRecetas.Rows[e.RowIndex];

            filaSeleccionada.Selected = true;

            RecetaPresentacion recetaSeleccionada = (RecetaPresentacion)filaSeleccionada.DataBoundItem;

            CargarRecetaSeleccionada(recetaSeleccionada);
        }

        void CargarRecetas()
        {
            IEnumerable<Receta> recetas = recetasBL.Obtener();

            grvRecetas.DataSource = ObtenerRecetasPresentacion(recetas);
        }

        IEnumerable<RecetaPresentacion> ObtenerRecetasPresentacion(IEnumerable<Receta> recetas)
        {
            List<RecetaPresentacion> recetasPresentacion = new List<RecetaPresentacion>();

            foreach (Receta receta in recetas)
            {
                recetasPresentacion.Add(new RecetaPresentacion(receta));
            }

            return recetasPresentacion;
        }

        void SetearReceta(Receta receta)
        {
            receta.Nombre = txtNombre.Text;
            receta.Detalle = txtDetalle.Text;

            EstadoReceta estado = EstadoReceta.SinIngredientes;

            if(chkNoDisponible.Checked)
            {
                estado = EstadoReceta.Inactiva;
            }

            receta.Estado = estado;
        }

        void CargarRecetaSeleccionada(RecetaPresentacion recetaSeleccionada)
        {
            txtNombre.Text = recetaSeleccionada.Nombre;
            txtDetalle.Text = recetaSeleccionada.Detalle;
            chkNoDisponible.Checked = recetaSeleccionada.Estado == EstadoReceta.Inactiva.ToString();
            btnVer.Enabled = true;
        }

        void LimpiarFormulario()
        {
            txtNombre.Text = string.Empty;
            txtDetalle.Text = string.Empty;
            chkNoDisponible.Checked = false;
            btnVer.Enabled = false;
            grvRecetas.ClearSelection();
        }
    }
}
