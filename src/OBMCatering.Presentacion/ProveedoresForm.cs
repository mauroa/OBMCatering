using OBMCatering.Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OBMCatering.Presentacion
{
    public partial class ProveedoresForm : Form
    {
        ContextoPresentacion contexto;
        LocalidadesBL localidadesBL;
        ProveedoresBL proveedoresBL;

        public ProveedoresForm()
        {
            InitializeComponent();
        }

        void ProveedoresForm_Load(object sender, EventArgs e)
        {
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

            contexto.RegistrarEvento("Ingreso a la pantalla de proveedores");
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

                    contexto.RegistrarEvento("El proveedor {0} ha sido actualizado", proveedor.Nombre);
                }
                else
                {
                    proveedor = new Proveedor();

                    SetearProveedor(proveedor);
                    proveedoresBL.Crear(proveedor);

                    contexto.RegistrarEvento("El proveedor {0} ha sido creado", proveedor.Nombre);
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

            DataGridViewRow filaSeleccionada = grvProveedores.SelectedRows[0];
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
