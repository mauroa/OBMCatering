using OBMCatering.Negocio;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using OBMCatering.Presentacion.Properties;

namespace OBMCatering.Presentacion
{
    /// <summary>
    /// Representa el formulario de pedidos para la cocina, en el sistema
    /// </summary>
    public partial class PedidosForm : Form
    {
        ContextoPresentacion contexto;
        LocalidadesBL localidadesBL;
        ClientesBL clientesBL;
        PreciosIngredientesBL precioIngredientesBL;
        RecetasBL recetasBL;
        OrdenesVentaBL ordenesVentaBL;

        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="PedidosForm"/>
        /// </summary>
        public PedidosForm()
        {
            this.CargarLenguaje();
            InitializeComponent();

            Text = Resources.PedidosForm_Titulo;
            lblDesde.Text = Resources.PedidosForm_Datos_Desde;
            lblHasta.Text = Resources.PedidosForm_Datos_Hasta;
            lblCliente.Text = Resources.PedidosForm_Datos_Cliente;
            btnFiltrar.Text = Resources.PedidosForm_Datos_Filtrar;
            btnRecetas.Text = Resources.PedidosForm_Datos_Recetas;

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            HelpButton = true;
            HelpRequested += PedidosForm_HelpRequested;
        }

        void PedidosForm_Load(object sender, EventArgs e)
        {
            AcceptButton = btnFiltrar;

            contexto = ContextoPresentacion.Instancia;
            localidadesBL = new LocalidadesBL(contexto.Negocio);
            clientesBL = new ClientesBL(contexto.Negocio, localidadesBL);
            precioIngredientesBL = new PreciosIngredientesBL(contexto.Negocio);
            recetasBL = new RecetasBL(contexto.Negocio, precioIngredientesBL);
            ordenesVentaBL = new OrdenesVentaBL(contexto.Negocio, recetasBL, clientesBL);

            btnFiltrar.Click += BtnFiltrar_Click;
            btnRecetas.Click += BtnRecetas_Click;

            CargarClientes();
            CargarPedidos();
            LimpiarFormulario();

            contexto.RegistrarEvento(Resources.PedidosForm_Ingreso);
        }

        void PedidosForm_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Form ayudaForm = new AyudaForm()
            {
                MensajeAyuda = Resources.PedidosForm_Help_Mensaje
            };

            ayudaForm.ShowDialog();
        }

        void BtnFiltrar_Click(object sender, EventArgs e)
        {
            FiltrarPedidos();
        }

        void BtnRecetas_Click(object sender, EventArgs e)
        {
            RecetasForm form = new RecetasForm();

            form.Show();
        }

        void CargarClientes()
        {
            try
            {
                IEnumerable<Cliente> clientes = clientesBL.ObtenerActivos();

                cboClientes.Items.Add("");

                foreach (Cliente cliente in clientes)
                {
                    cboClientes.Items.Add(cliente.Nombre);
                }
            }
            catch(Exception ex)
            {
                contexto.RegistrarError(ex);
            }
        }

        void CargarPedidos()
        {
            try
            {
                IEnumerable<OrdenVenta> ordenesVenta = ordenesVentaBL.Obtener(aprobadas: true);

                CargarPedidos(ordenesVenta);
            }
            catch (Exception ex)
            {
                contexto.RegistrarError(ex);
            }
        }

        void FiltrarPedidos()
        {
            try
            {
                IEnumerable<OrdenVenta> ordenesVenta = ordenesVentaBL.Obtener(aprobadas: true);

                if (dtpDesde.Value > dtpDesde.MinDate)
                {
                    ordenesVenta = ordenesVenta.Where(ordenVenta => ordenVenta.FechaInicio >= dtpDesde.Value);
                }

                if (dtpHasta.Value > dtpHasta.MinDate)
                {
                    ordenesVenta = ordenesVenta.Where(ordenVenta => ordenVenta.FechaFin <= dtpHasta.Value);
                }

                string cliente = null;

                if (cboClientes.SelectedItem != null)
                {
                    cliente = cboClientes.SelectedItem.ToString();
                }

                if (!string.IsNullOrEmpty(cliente))
                {
                    ordenesVenta = ordenesVenta.Where(ordenVenta => ordenVenta.Cliente.Nombre == cliente);
                }

                CargarPedidos(ordenesVenta);
            }
            catch (Exception ex)
            {
                contexto.RegistrarError(ex);
            }
        }

        void CargarPedidos(IEnumerable<OrdenVenta> ordenesVenta)
        {
            IEnumerable<OrdenVentaPresentacion> ordenesVentaPresentacion = ObtenerOrdenesVentaPresentacion(ordenesVenta);

            grvPedidos.DataSource = ordenesVentaPresentacion;
        }

        IEnumerable<OrdenVentaPresentacion> ObtenerOrdenesVentaPresentacion(IEnumerable<OrdenVenta> ordenesVenta)
        {
            List<OrdenVentaPresentacion> ordenesVentaPresentacion = new List<OrdenVentaPresentacion>();

            foreach (OrdenVenta ordenVenta in ordenesVenta)
            {
                ordenesVentaPresentacion.Add(new OrdenVentaPresentacion(ordenVenta));
            }

            return ordenesVentaPresentacion;
        }

        void LimpiarFormulario()
        {
            dtpDesde.Value = dtpDesde.MinDate;
            dtpHasta.Value = dtpHasta.MinDate;
            cboClientes.SelectedItem = "";
            grvPedidos.ClearSelection();
        }
    }
}
