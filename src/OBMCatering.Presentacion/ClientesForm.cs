using OBMCatering.Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OBMCatering.Presentacion
{
    public partial class ClientesForm : Form
    {
        LocalidadesBL localidadesBL;
        ClientesBL clientesBL;

        public ClientesForm()
        {
            InitializeComponent();
        }

        void ClientesForm_Load(object sender, EventArgs e)
        {
            localidadesBL = new LocalidadesBL(ContextoNegocio.Instancia);
            clientesBL = new ClientesBL(ContextoNegocio.Instancia, localidadesBL);
            
            btnGuardar.Click += BtnGuardar_Click;
            grvClientes.SelectionChanged += GrvClientes_SelectionChanged;
            grvClientes.CellEnter += GrvClientes_CellEnter;
            cboProvincias.SelectedValueChanged += CboProvincias_SelectedValueChanged;
            CargarProvincias();
            CargarTiposCliente();
            CargarClientes();
            LimpiarFormulario();
        }

        void BtnGuardar_Click(object sender, EventArgs e)
        {
            bool existeCliente = clientesBL.Existe(txtCUIT.Text);
            Cliente cliente;

            if (existeCliente)
            {
                cliente = clientesBL.ObtenerPorCUIT(txtCUIT.Text);

                SetearCliente(cliente);
                clientesBL.Actualizar(cliente); ;
            }
            else
            {
                cliente = new Cliente();

                SetearCliente(cliente);
                clientesBL.Crear(cliente);
            }

            CargarClientes();
            LimpiarFormulario();
        }

        void GrvClientes_SelectionChanged(object sender, EventArgs e)
        {
            int filasSeleccionadas = grvClientes.SelectedRows.Count;

            if (filasSeleccionadas == 0 || filasSeleccionadas > 1) return;

            DataGridViewRow filaSeleccionada = grvClientes.SelectedRows[0];
            ClientePresentacion clienteSeleccionado = (ClientePresentacion)filaSeleccionada.DataBoundItem;

            CargarClienteSeleccionado(clienteSeleccionado);
        }

        void GrvClientes_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaSeleccionada = grvClientes.Rows[e.RowIndex];

            filaSeleccionada.Selected = true;

            ClientePresentacion clienteSeleccionado = (ClientePresentacion)filaSeleccionada.DataBoundItem;

            CargarClienteSeleccionado(clienteSeleccionado);
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

        void CargarClienteSeleccionado(ClientePresentacion cliente)
        {
            txtCUIT.Text = cliente.CUIT;
            txtNombre.Text = cliente.Nombre;
            dtpFechaAlta.Value = cliente.FechaAlta;
            txtDomicilio.Text = cliente.Domicilio;
            cboProvincias.SelectedItem = cliente.Provincia;
            cboLocalidades.SelectedItem = cliente.Localidad;
            txtCP.Text = cliente.CodigoPostal;
            txtTelefono.Text = cliente.Telefono;
            txtEmail.Text = cliente.Email;
            cboTipos.SelectedItem = cliente.Tipo;
            chkActivo.Checked = cliente.Activo;
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

        void CargarTiposCliente()
        {
            cboTipos.Items.Add(TipoCliente.Empresa.ToString());
            cboTipos.Items.Add(TipoCliente.Persona.ToString());
        }

        void CargarClientes()
        {
            IEnumerable<Cliente> clientes = clientesBL.Obtener();

            grvClientes.DataSource = ObtenerClientesPresentacion(clientes);
        }

        IEnumerable<ClientePresentacion> ObtenerClientesPresentacion(IEnumerable<Cliente> clientes)
        {
            List<ClientePresentacion> clientesPresentacion = new List<ClientePresentacion>();

            foreach(Cliente cliente in clientes)
            {
                clientesPresentacion.Add(new ClientePresentacion(cliente));
            }

            return clientesPresentacion;
        }

        void SetearCliente(Cliente cliente)
        {
            Localidad localidad = localidadesBL.ObtenerLocalidad(cboLocalidades.SelectedItem.ToString());
            TipoCliente tipo = (TipoCliente)Enum.Parse(typeof(TipoCliente), cboTipos.SelectedItem.ToString());

            cliente.CUIT = txtCUIT.Text;
            cliente.Nombre = txtNombre.Text;
            cliente.FechaAlta = dtpFechaAlta.Value;
            cliente.Domicilio = txtDomicilio.Text;
            cliente.Localidad = localidad;
            cliente.CodigoPostal = txtCP.Text;
            cliente.Telefono = txtTelefono.Text;
            cliente.Email = txtEmail.Text;
            cliente.Tipo = tipo;
            cliente.Activo = chkActivo.Checked;
        }

        void LimpiarFormulario()
        {
            txtCUIT.Text = string.Empty;
            txtNombre.Text = string.Empty;
            dtpFechaAlta.Value = dtpFechaAlta.MinDate;
            txtDomicilio.Text = string.Empty;
            cboProvincias.SelectedItem = null;
            cboLocalidades.SelectedItem = null;
            txtCP.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cboTipos.SelectedItem = null;
            chkActivo.Checked = false;
            grvClientes.ClearSelection();
        }
    }
}
