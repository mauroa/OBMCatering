﻿using OBMCatering.Negocio;
using OBMCatering.Presentacion.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OBMCatering.Presentacion
{
    /// <summary>
    /// Representa el formulario de administracion de empleados del sistema
    /// </summary>
    public partial class EmpleadosForm : Form
    {
        ContextoPresentacion contexto;
        LocalidadesBL localidadesBL;
        EmpleadosBL empleadosBL;

        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="EmpleadosForm"/>
        /// </summary>
        public EmpleadosForm()
        {
            this.CargarLenguaje();
            InitializeComponent();

            Text = Resources.EmpleadosForm_Titulo;
            lblCUIT.Text = Resources.EmpleadosForm_Datos_CUIT;
            lblNombre.Text = Resources.EmpleadosForm_Datos_Nombre;
            lblFechaNacimiento.Text = Resources.EmpleadosForm_Datos_FechaNacimiento;
            lblDomicilio.Text = Resources.EmpleadosForm_Datos_Domicilio;
            lblProvincia.Text = Resources.EmpleadosForm_Datos_Provincia;
            lblLocalidad.Text = Resources.EmpleadosForm_Datos_Localidad;
            lblCP.Text = Resources.EmpleadosForm_Datos_CP;
            lblTelefono.Text = Resources.EmpleadosForm_Datos_Telefono;
            lblEmail.Text = Resources.EmpleadosForm_Datos_Email;
            lblFechaAlta.Text = Resources.EmpleadosForm_Datos_FechaAlta;
            lblFechaBaja.Text = Resources.EmpleadosForm_Datos_FechaBaja;
            chkActivo.Text = Resources.EmpleadosForm_Datos_Activo;
            btnGuardar.Text = Resources.EmpleadosForm_Datos_Guardar;

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            HelpButton = true;
            HelpRequested += EmpleadosForm_HelpRequested;
        }

        void EmpleadosForm_Load(object sender, EventArgs e)
        {
            AcceptButton = btnGuardar;

            contexto = ContextoPresentacion.Instancia;
            localidadesBL = new LocalidadesBL(contexto.Negocio);
            empleadosBL = new EmpleadosBL(contexto.Negocio, localidadesBL);
            
            btnGuardar.Click += BtnGuardar_Click;
            grvEmpleados.SelectionChanged += GrvClientes_SelectionChanged;
            grvEmpleados.CellEnter += GrvClientes_CellEnter;
            cboProvincias.SelectedValueChanged += CboProvincias_SelectedValueChanged;
            CargarProvincias();
            CargarEmpleados();
            LimpiarFormulario();

            contexto.RegistrarEvento(Resources.EmpleadosForm_Ingreso);
        }

        void EmpleadosForm_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Form ayudaForm = new AyudaForm()
            {
                MensajeAyuda = Resources.EmpleadosForm_Help_Mensaje
            };

            ayudaForm.ShowDialog();
        }

        void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                bool existeEmpleado = empleadosBL.Existe(txtCUIT.Text);
                Empleado empleado;

                if (existeEmpleado)
                {
                    empleado = empleadosBL.Obtener(txtCUIT.Text);

                    SetearEmpleado(empleado);
                    empleadosBL.Actualizar(empleado);

                    contexto.RegistrarEvento(Resources.EmpleadosForm_EmpleadoActualizado, empleado.Nombre);
                }
                else
                {
                    empleado = new Empleado();

                    SetearEmpleado(empleado);
                    empleadosBL.Crear(empleado);

                    contexto.RegistrarEvento(Resources.EmpleadosForm_EmpleadoCreado, empleado.Nombre);
                }

                CargarEmpleados();
                LimpiarFormulario();
            }
            catch(Exception ex)
            {
                contexto.RegistrarError(ex);
            }
        }

        void GrvClientes_SelectionChanged(object sender, EventArgs e)
        {
            int filasSeleccionadas = grvEmpleados.SelectedRows.Count;

            if (filasSeleccionadas == 0 || filasSeleccionadas > 1) return;

            DataGridViewRow filaSeleccionada = grvEmpleados.CurrentRow;
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
            try
            {
                IEnumerable<Provincia> provincias = localidadesBL.ObtenerProvincias();

                foreach (Provincia provincia in provincias)
                {
                    cboProvincias.Items.Add(provincia.Nombre);
                }
            }
            catch (Exception ex)
            {
                contexto.RegistrarError(ex);
            }
        }

        void CargarLocalidades(string provinciaSeleccionada)
        {
            try
            {
                Provincia provincia = localidadesBL.ObtenerProvincia(provinciaSeleccionada);
                IEnumerable<Localidad> localidades = localidadesBL.ObtenerLocalidades(provincia);

                cboLocalidades.Items.Clear();

                foreach (Localidad localidad in localidades)
                {
                    cboLocalidades.Items.Add(localidad.Nombre);
                }
            }
            catch (Exception ex)
            {
                contexto.RegistrarError(ex);
            }
        }

        void CargarEmpleados()
        {
            try
            {
                IEnumerable<Empleado> empleados = empleadosBL.Obtener();

                grvEmpleados.DataSource = ObtenerEmpleadosPresentacion(empleados);
            }
            catch (Exception ex)
            {
                contexto.RegistrarError(ex);
            }
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

            if (dtpFechaBaja.Value != dtpFechaBaja.MinDate)
            {
                empleado.FechaBaja = dtpFechaBaja.Value;
            }
        }

        void LimpiarFormulario()
        {
            txtCUIT.Text = string.Empty;
            txtNombre.Text = string.Empty;
            dtpFechaNacimiento.Value = DateTime.Now;
            txtDomicilio.Text = string.Empty;
            cboProvincias.SelectedItem = null;
            cboLocalidades.SelectedItem = null;
            txtCP.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
            dtpFechaAlta.Value = DateTime.Now;
            dtpFechaBaja.Value = dtpFechaAlta.MinDate;
            chkActivo.Checked = false;
            grvEmpleados.ClearSelection();
        }
    }
}
