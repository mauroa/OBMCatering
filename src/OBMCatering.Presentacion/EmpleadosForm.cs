﻿using OBMCatering.Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OBMCatering.Presentacion
{
    public partial class EmpleadosForm : Form
    {
        LocalidadesBL localidadesBL;
        EmpleadosBL empleadosBL;

        public EmpleadosForm()
        {
            InitializeComponent();
        }

        void EmpleadosForm_Load(object sender, EventArgs e)
        {
            localidadesBL = new LocalidadesBL(ContextoNegocio.Instancia);
            empleadosBL = new EmpleadosBL(ContextoNegocio.Instancia, localidadesBL);
            
            btnGuardar.Click += BtnGuardar_Click;
            grvEmpleados.SelectionChanged += GrvClientes_SelectionChanged;
            grvEmpleados.CellEnter += GrvClientes_CellEnter;
            cboProvincias.SelectedValueChanged += CboProvincias_SelectedValueChanged;
            CargarProvincias();
            CargarEmpleados();
            LimpiarFormulario();
        }

        void BtnGuardar_Click(object sender, EventArgs e)
        {
            bool existeEmpleado = empleadosBL.Existe(txtCUIT.Text);
            Empleado empleado;

            if (existeEmpleado)
            {
                empleado = empleadosBL.Obtener(txtCUIT.Text);

                SetearEmpleado(empleado);
                empleadosBL.Actualizar(empleado); ;
            }
            else
            {
                empleado = new Empleado();

                SetearEmpleado(empleado);
                empleadosBL.Crear(empleado);
            }

            CargarEmpleados();
            LimpiarFormulario();
        }

        void GrvClientes_SelectionChanged(object sender, EventArgs e)
        {
            int filasSeleccionadas = grvEmpleados.SelectedRows.Count;

            if (filasSeleccionadas == 0 || filasSeleccionadas > 1) return;

            DataGridViewRow filaSeleccionada = grvEmpleados.SelectedRows[0];
            EmpleadoPresentacion empleadoSeleccionado = (EmpleadoPresentacion)filaSeleccionada.DataBoundItem;

            CargarEmpleadoSeleccionado(empleadoSeleccionado);
        }

        void GrvClientes_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaSeleccionada = grvEmpleados.Rows[e.RowIndex];

            filaSeleccionada.Selected = true;

            EmpleadoPresentacion empleadoSeleccionado = (EmpleadoPresentacion)filaSeleccionada.DataBoundItem;

            CargarEmpleadoSeleccionado(empleadoSeleccionado);
        }

        void CboProvincias_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cboProvincias.SelectedItem == null)
            {
                return;
            }

            string provinciaSeleccionada = cboProvincias.SelectedItem.ToString();

            CargarLocalidades(provinciaSeleccionada);
        }

        void CargarEmpleadoSeleccionado(EmpleadoPresentacion empleado)
        {
            txtCUIT.Text = empleado.CUIT;
            txtNombre.Text = empleado.Nombre;
            dtpFechaNacimiento.Value = empleado.FechaNacimiento;
            txtDomicilio.Text = empleado.Domicilio;
            cboProvincias.SelectedItem = empleado.Provincia;
            cboLocalidades.SelectedItem = empleado.Localidad;
            txtCP.Text = empleado.CodigoPostal;
            txtTelefono.Text = empleado.Telefono;
            txtEmail.Text = empleado.Email;
            dtpFechaAlta.Value = empleado.FechaAlta;

            DateTime fechaBaja = dtpFechaBaja.MinDate;

            if(empleado.FechaBaja.HasValue)
            {
                fechaBaja = empleado.FechaBaja.Value;
            }

            dtpFechaBaja.Value = fechaBaja;
            chkActivo.Checked = !empleado.FechaBaja.HasValue;
        }

        void CargarProvincias()
        {
            IEnumerable<Provincia> provincias = localidadesBL.ObtenerProvincias();

            foreach(Provincia provincia in provincias)
            {
                cboProvincias.Items.Add(provincia.Nombre);
            }
        }

        void CargarLocalidades(string provinciaSeleccionada)
        {
            Provincia provincia = localidadesBL.ObtenerProvincia(provinciaSeleccionada);
            IEnumerable<Localidad> localidades = localidadesBL.ObtenerLocalidades(provincia);

            cboLocalidades.Items.Clear();

            foreach (Localidad localidad in localidades)
            {
                cboLocalidades.Items.Add(localidad.Nombre);
            }
        }

        void CargarEmpleados()
        {
            IEnumerable<Empleado> empleados = empleadosBL.Obtener();

            grvEmpleados.DataSource = ObtenerEmpleadosPresentacion(empleados);
        }

        IEnumerable<EmpleadoPresentacion> ObtenerEmpleadosPresentacion(IEnumerable<Empleado> empleados)
        {
            List<EmpleadoPresentacion> empleadosPresentacion = new List<EmpleadoPresentacion>();

            foreach(Empleado empleado in empleados)
            {
                empleadosPresentacion.Add(new EmpleadoPresentacion(empleado));
            }

            return empleadosPresentacion;
        }

        void SetearEmpleado(Empleado empleado)
        {
            Localidad localidad = localidadesBL.ObtenerLocalidad(cboLocalidades.SelectedItem.ToString());

            empleado.CUIT = txtCUIT.Text;
            empleado.Nombre = txtNombre.Text;
            empleado.FechaNacimiento = dtpFechaNacimiento.Value;
            empleado.Domicilio = txtDomicilio.Text;
            empleado.Localidad = localidad;
            empleado.CodigoPostal = txtCP.Text;
            empleado.Telefono = txtTelefono.Text;
            empleado.Email = txtEmail.Text;
            empleado.FechaAlta = dtpFechaAlta.Value;

            if(dtpFechaBaja.Value != dtpFechaBaja.MinDate)
            {
                empleado.FechaBaja = dtpFechaBaja.Value;
            }
        }

        void LimpiarFormulario()
        {
            txtCUIT.Text = string.Empty;
            txtNombre.Text = string.Empty;
            dtpFechaNacimiento.Value = dtpFechaNacimiento.MinDate;
            txtDomicilio.Text = string.Empty;
            cboProvincias.SelectedItem = null;
            cboLocalidades.SelectedItem = null;
            txtCP.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
            dtpFechaAlta.Value = dtpFechaAlta.MinDate;
            dtpFechaBaja.Value = dtpFechaAlta.MinDate;
            chkActivo.Checked = false;
            grvEmpleados.ClearSelection();
        }
    }
}
