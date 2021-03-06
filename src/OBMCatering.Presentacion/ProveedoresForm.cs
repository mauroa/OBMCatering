﻿using OBMCatering.Negocio;
using OBMCatering.Presentacion.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OBMCatering.Presentacion
{
    /// <summary>
    /// Representa el formulario de proveedores del sistema
    /// </summary>
    public partial class ProveedoresForm : Form
    {
        ContextoPresentacion contexto;
        LocalidadesBL localidadesBL;
        ProveedoresBL proveedoresBL;

        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="ProveedoresForm"/>
        /// </summary>
        public ProveedoresForm()
        {
            this.CargarLenguaje();
            InitializeComponent();

            Text = Resources.ProveedoresForm_Titulo;
            lblCUIT.Text = Resources.ProveedoresForm_Datos_CUIT;
            lblNombre.Text = Resources.ProveedoresForm_Datos_Nombre;
            lblDomicilio.Text = Resources.ProveedoresForm_Datos_Domicilio;
            lblProvincia.Text = Resources.ProveedoresForm_Datos_Provincia;
            lblLocalidad.Text = Resources.ProveedoresForm_Datos_Localidad;
            lblCP.Text = Resources.ProveedoresForm_Datos_CodigoPostal;
            lblTelefono.Text = Resources.ProveedoresForm_Datos_Telefono;
            lblEmail.Text = Resources.ProveedoresForm_Datos_Email;
            lblFechaAlta.Text = Resources.ProveedoresForm_Datos_FechaAlta;
            lblFechaBaja.Text = Resources.ProveedoresForm_Datos_FechaBaja;
            chkActivo.Text = Resources.ProveedoresForm_Datos_Activo;
            btnGuardar.Text = Resources.ProveedoresForm_Datos_Guardar;

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            HelpButton = true;
            HelpRequested += ProveedoresForm_HelpRequested;
        }

        void ProveedoresForm_Load(object sender, EventArgs e)
        {
            AcceptButton = btnGuardar;

            contexto = ContextoPresentacion.Instancia;
            localidadesBL = new LocalidadesBL(contexto.Negocio);
            proveedoresBL = new ProveedoresBL(contexto.Negocio, localidadesBL);
            
            btnGuardar.Click += BtnGuardar_Click;
            grvProveedores.SelectionChanged += GrvClientes_SelectionChanged;
            grvProveedores.CellEnter += GrvClientes_CellEnter;
            cboProvincias.SelectedValueChanged += CboProvincias_SelectedValueChanged;
            CargarProvincias();
            CargarProveedores();
            LimpiarFormulario();

            contexto.RegistrarEvento(Resources.ProveedoresForm_Ingreso);
        }

        void ProveedoresForm_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Form ayudaForm = new AyudaForm()
            {
                MensajeAyuda = Resources.ProveedoresForm_Help_Mensaje
            };

            ayudaForm.ShowDialog();
        }

        void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                bool existeProveedor = proveedoresBL.Existe(txtCUIT.Text);
                Proveedor proveedor;

                if (existeProveedor)
                {
                    proveedor = proveedoresBL.ObtenerPorCUIT(txtCUIT.Text);

                    SetearProveedor(proveedor);
                    proveedoresBL.Actualizar(proveedor);

                    contexto.RegistrarEvento(Resources.ProveedoresForm_ProveedorActualizado, proveedor.Nombre);
                }
                else
                {
                    proveedor = new Proveedor();

                    SetearProveedor(proveedor);
                    proveedoresBL.Crear(proveedor);

                    contexto.RegistrarEvento(Resources.ProveedoresForm_ProveedorCreado, proveedor.Nombre);
                }

                CargarProveedores();
                LimpiarFormulario();
            }
            catch(Exception ex)
            {
                contexto.RegistrarError(ex);
            }
        }

        void GrvClientes_SelectionChanged(object sender, EventArgs e)
        {
            int filasSeleccionadas = grvProveedores.SelectedRows.Count;

            if (filasSeleccionadas == 0 || filasSeleccionadas > 1) return;

            DataGridViewRow filaSeleccionada = grvProveedores.CurrentRow;
            ProveedorPresentacion proveedorSeleccionado = (ProveedorPresentacion)filaSeleccionada.DataBoundItem;

            CargarProveedorSeleccionado(proveedorSeleccionado);
        }

        void GrvClientes_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaSeleccionada = grvProveedores.Rows[e.RowIndex];

            filaSeleccionada.Selected = true;

            ProveedorPresentacion proveedorSeleccionado = (ProveedorPresentacion)filaSeleccionada.DataBoundItem;

            CargarProveedorSeleccionado(proveedorSeleccionado);
        }

        void CboProvincias_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboProvincias.SelectedItem == null)
            {
                return;
            }

            string provinciaSeleccionada = cboProvincias.SelectedItem.ToString();

            CargarLocalidades(provinciaSeleccionada);
        }

        void CargarProveedorSeleccionado(ProveedorPresentacion proveedor)
        {
            txtCUIT.Text = proveedor.CUIT;
            txtNombre.Text = proveedor.Nombre;
            txtDomicilio.Text = proveedor.Domicilio;
            cboProvincias.SelectedItem = proveedor.Provincia;
            cboLocalidades.SelectedItem = proveedor.Localidad;
            txtCP.Text = proveedor.CodigoPostal;
            txtTelefono.Text = proveedor.Telefono;
            txtEmail.Text = proveedor.Email;
            dtpFechaAlta.Value = proveedor.FechaAlta;

            DateTime fechaBaja = dtpFechaBaja.MinDate;

            if(proveedor.FechaBaja.HasValue)
            {
                fechaBaja = proveedor.FechaBaja.Value;
            }

            dtpFechaBaja.Value = fechaBaja;
            chkActivo.Checked = !proveedor.FechaBaja.HasValue;
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

        void CargarProveedores()
        {
            try
            {
                IEnumerable<Proveedor> proveedores = proveedoresBL.Obtener();

                grvProveedores.DataSource = ObtenerProveedoresPresentacion(proveedores);
            }
            catch (Exception ex)
            {
                contexto.RegistrarError(ex);
            }
        }

        IEnumerable<ProveedorPresentacion> ObtenerProveedoresPresentacion(IEnumerable<Proveedor> proveedores)
        {
            List<ProveedorPresentacion> proveedoresPresentacion = new List<ProveedorPresentacion>();

            foreach(Proveedor proveedor in proveedores)
            {
                proveedoresPresentacion.Add(new ProveedorPresentacion(proveedor));
            }

            return proveedoresPresentacion;
        }

        void SetearProveedor(Proveedor proveedor)
        {
            Localidad localidad = localidadesBL.ObtenerLocalidad(cboLocalidades.SelectedItem.ToString());

            proveedor.CUIT = txtCUIT.Text;
            proveedor.Nombre = txtNombre.Text;
            proveedor.Domicilio = txtDomicilio.Text;
            proveedor.Localidad = localidad;
            proveedor.CodigoPostal = txtCP.Text;
            proveedor.Telefono = txtTelefono.Text;
            proveedor.Email = txtEmail.Text;
            proveedor.FechaAlta = dtpFechaAlta.Value;

            if (dtpFechaBaja.Value != dtpFechaBaja.MinDate)
            {
                proveedor.FechaBaja = dtpFechaBaja.Value;
            }
        }

        void LimpiarFormulario()
        {
            txtCUIT.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDomicilio.Text = string.Empty;
            cboProvincias.SelectedItem = null;
            cboLocalidades.SelectedItem = null;
            txtCP.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
            dtpFechaAlta.Value = DateTime.Now;
            dtpFechaBaja.Value = dtpFechaBaja.MinDate;
            chkActivo.Checked = false;
            grvProveedores.ClearSelection();
        }
    }
}
