﻿using OBMCatering.Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OBMCatering.Presentacion
{
    public partial class IngredientesForm : Form
    {
        PreciosIngredientesBL preciosIngredientesBL;
        RecetasBL recetasBL;

        public IngredientesForm()
        {
            InitializeComponent();
        }

        public RecetaPresentacion Receta { get; set; }

        void IngredientesForm_Load(object sender, EventArgs e)
        {
            preciosIngredientesBL = new PreciosIngredientesBL(ContextoNegocio.Instancia);
            recetasBL = new RecetasBL(ContextoNegocio.Instancia, preciosIngredientesBL);

            btnGuardar.Click += BtnGuardar_Click;
            grvIngredientes.SelectionChanged += GrvIngredientes_SelectionChanged; ;
            grvIngredientes.CellEnter += GrvIngredientes_CellEnter;
            CargarUnidades();
            CargarIngredientes();
            LimpiarFormulario();
        }

        void BtnGuardar_Click(object sender, EventArgs e)
        {
            Receta receta = recetasBL.Obtener(Receta.Nombre);
            IngredienteReceta ingredienteReceta = null;

            foreach(IngredienteReceta ingrediente in receta.Ingredientes)
            {
                if(ingrediente.Ingrediente.Nombre == txtIngrediente.Text)
                {
                    ingredienteReceta = ingrediente;
                    break;
                }
            }

            if (ingredienteReceta == null)
            {
                ingredienteReceta = new IngredienteReceta();

                SetearIngrediente(ingredienteReceta);
                receta.Ingredientes.Add(ingredienteReceta);
            }
            else
            {
                SetearIngrediente(ingredienteReceta);
            }

            recetasBL.Actualizar(receta);
            CargarIngredientes();
            LimpiarFormulario();
        }

        void GrvIngredientes_SelectionChanged(object sender, EventArgs e)
        {
            int filasSeleccionadas = grvIngredientes.SelectedRows.Count;

            if (filasSeleccionadas == 0 || filasSeleccionadas > 1) return;

            DataGridViewRow filaSeleccionada = grvIngredientes.SelectedRows[0];
            IngredientePresentacion ingredienteSeleccionado = (IngredientePresentacion)filaSeleccionada.DataBoundItem;

            CargarIngredienteSeleccionado(ingredienteSeleccionado);
        }

        void GrvIngredientes_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaSeleccionada = grvIngredientes.Rows[e.RowIndex];

            filaSeleccionada.Selected = true;

            IngredientePresentacion ingredienteSeleccionado = (IngredientePresentacion)filaSeleccionada.DataBoundItem;

            CargarIngredienteSeleccionado(ingredienteSeleccionado);
        }

        void CargarUnidades()
        {
            cboUnidad.Items.Add(UnidadMedida.gr.ToString());
            cboUnidad.Items.Add(UnidadMedida.ml.ToString());
            cboUnidad.Items.Add(UnidadMedida.unidad.ToString());
        }

        void CargarIngredientes()
        {
            Receta receta = recetasBL.Obtener(Receta.Nombre);

            grvIngredientes.DataSource = ObtenerIngredientesPresentacion(receta);
        }

        IEnumerable<IngredientePresentacion> ObtenerIngredientesPresentacion(Receta receta)
        {
            List<IngredientePresentacion> ingredientesPresentacion = new List<IngredientePresentacion>();

            foreach (IngredienteReceta ingrediente in receta.Ingredientes)
            {
                ingredientesPresentacion.Add(new IngredientePresentacion(ingrediente));
            }

            return ingredientesPresentacion;
        }

        void SetearIngrediente(IngredienteReceta ingredienteReceta)
        {
            UnidadMedida unidad = (UnidadMedida)Enum.Parse(typeof(UnidadMedida), cboUnidad.SelectedItem.ToString());

            if(ingredienteReceta.Ingrediente == null)
            {
                ingredienteReceta.Ingrediente = new Ingrediente();
            }

            ingredienteReceta.Ingrediente.Nombre = txtIngrediente.Text;
            ingredienteReceta.Cantidad = decimal.Parse(txtCantidad.Text);
            ingredienteReceta.Unidad = unidad;
        }

        void CargarIngredienteSeleccionado(IngredientePresentacion ingredienteSeleccionado)
        {
            txtIngrediente.Text = ingredienteSeleccionado.Nombre;
            txtCantidad.Text = ingredienteSeleccionado.Cantidad;
            cboUnidad.SelectedItem = ingredienteSeleccionado.Unidad;
        }

        void LimpiarFormulario()
        {
            txtIngrediente.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            cboUnidad.SelectedItem = null;
            grvIngredientes.ClearSelection();
        }
    }
}
