using OBMCatering.Negocio;
using OBMCatering.Presentacion.Properties;
using System;
using System.Windows.Forms;

namespace OBMCatering.Presentacion
{
    public partial class InicioForm : Form
    {
        ContextoPresentacion contexto;

        public InicioForm()
        {
            Inicializar();
        }

        void Inicializar()
        {
            this.CargarLenguaje();

            InitializeComponent();

            contexto = ContextoPresentacion.Instancia;

            Text = Resources.InicioForm_Titulo;
            tsAdministrar.Text = Resources.InicioForm_Menu_Administrar_Titulo;
            tsiClientes.Text = Resources.InicioForm_Menu_Administrar_Clientes;
            tsiProveedores.Text = Resources.InicioForm_Menu_Administrar_Proveedores;
            tsiEmpleados.Text = Resources.InicioForm_Menu_Administrar_Empleados;
            tsiUsuarios.Text = Resources.InicioForm_Menu_Administrar_Usuarios;
            tsCocina.Text = Resources.InicioForm_Menu_Cocina_Titulo;
            tsiPedidosCocina.Text = Resources.InicioForm_Menu_Cocina_Pedidos;
            tsiRecetas.Text = Resources.InicioForm_Menu_Cocina_Recetas;
            tsiPrecios.Text = Resources.InicioForm_Menu_Cocina_Precios;
            tsVentas.Text = Resources.InicioForm_Menu_Ventas_Titulo;
            tsiPedidos.Text = Resources.InicioForm_Menu_Ventas_Pedidos;
            tsiFacturas.Text = Resources.InicioForm_Menu_Ventas_Facturas;
            tsCompras.Text = Resources.InicioForm_Menu_Compras_Titulo;
            tsiOrdenesCompra.Text = Resources.InicioForm_Menu_Compras_Ordenes;
            tsiOrdenesPago.Text = Resources.InicioForm_Menu_Compras_Pagos;
            tsOpciones.Text = Resources.InicioForm_Menu_Opciones_Titulo;
            tsiBitacora.Text = Resources.InicioForm_Menu_Opciones_Bitacora;
            tsiLenguaje.Text = Resources.InicioForm_Menu_Opciones_Lenguaje;
            tsiEspaniol.Text = Resources.InicioForm_Menu_Opciones_Espaniol;
            tsiIngles.Text = Resources.InicioForm_Menu_Opciones_Ingles;
            tsiSalir.Text = Resources.InicioForm_Menu_Opciones_Salir;

            tsiClientes.Click += TsiClientes_Click;
            tsiProveedores.Click += TsiProveedores_Click;
            tsiEmpleados.Click += TsiEmpleados_Click;
            tsiUsuarios.Click += TsiUsuarios_Click;
            tsiPedidosCocina.Click += TsiPedidosCocina_Click;
            tsiRecetas.Click += TsiRecetas_Click;
            tsiPrecios.Click += TsiPrecios_Click;
            tsiPedidos.Click += TsiPedidos_Click;
            tsiFacturas.Click += TsiFacturas_Click;
            tsiOrdenesCompra.Click += TsiOrdenesCompra_Click;
            tsiOrdenesPago.Click += TsiOrdenesPago_Click;
            tsiBitacora.Click += TsiBitacora_Click;
            tsiEspaniol.Click += TsiEspaniol_Click;
            tsiIngles.Click += TsiIngles_Click;
            tsiSalir.Click += TsSalir_Click;
        }

        void ConfigurarPerfil()
        {
            Usuario usuario = contexto.Negocio.ObtenerUsuarioAutenticado();

            switch(usuario.Perfil)
            {
                case PerfilUsuario.Admin:
                    tsAdministrar.Visible = true;
                    tsCocina.Visible = true;
                    tsCompras.Visible = true;
                    tsVentas.Visible = true;
                    tsiBitacora.Visible = true;
                    break;
                case PerfilUsuario.Cocina:
                    tsCocina.Visible = true;
                    tsAdministrar.Visible = false;
                    tsCompras.Visible = false;
                    tsVentas.Visible = false;
                    tsiBitacora.Visible = false;
                    break;
                case PerfilUsuario.Compras:
                    tsCompras.Visible = true;
                    tsAdministrar.Visible = true;
                    tsiProveedores.Visible = true;
                    tsiClientes.Visible = false;
                    tsiEmpleados.Visible = false;
                    tsiUsuarios.Visible = false;
                    tsCocina.Visible = false;
                    tsVentas.Visible = false;
                    tsiBitacora.Visible = false;
                    break;
                case PerfilUsuario.Ventas:
                    tsVentas.Visible = true;
                    tsAdministrar.Visible = true;
                    tsiProveedores.Visible = false;
                    tsiClientes.Visible = true;
                    tsiEmpleados.Visible = false;
                    tsiUsuarios.Visible = false;
                    tsCocina.Visible = false;
                    tsCompras.Visible = false;
                    tsiBitacora.Visible = false;
                    break;
            }
        }

        void TsiClientes_Click(object sender, EventArgs e)
        {
            ClientesForm form = new ClientesForm();

            form.Show();
        }

        void TsiProveedores_Click(object sender, EventArgs e)
        {
            ProveedoresForm form = new ProveedoresForm();

            form.Show();
        }

        void TsiEmpleados_Click(object sender, EventArgs e)
        {
            EmpleadosForm form = new EmpleadosForm();

            form.Show();
        }

        void TsiUsuarios_Click(object sender, EventArgs e)
        {
            UsuariosForm form = new UsuariosForm();

            form.Show();
        }

        void TsiPedidosCocina_Click(object sender, EventArgs e)
        {
            PedidosForm form = new PedidosForm();

            form.Show();
        }

        void TsiRecetas_Click(object sender, EventArgs e)
        {
            RecetasForm form = new RecetasForm();

            form.Show();
        }

        void TsiPrecios_Click(object sender, EventArgs e)
        {
            PreciosForm form = new PreciosForm();

            form.Show();
        }

        void TsiPedidos_Click(object sender, EventArgs e)
        {
            OrdenesVentaForm form = new OrdenesVentaForm();

            form.Show();
        }

        void TsiFacturas_Click(object sender, EventArgs e)
        {
            FacturasForm form = new FacturasForm();

            form.Show();
        }

        void TsiOrdenesCompra_Click(object sender, EventArgs e)
        {
            OrdenesCompraForm form = new OrdenesCompraForm();

            form.Show();
        }

        void TsiOrdenesPago_Click(object sender, EventArgs e)
        {
            OrdenesPagoForm form = new OrdenesPagoForm();

            form.Show();
        }

        void TsiBitacora_Click(object sender, EventArgs e)
        {
            BitacoraForm form = new BitacoraForm();

            form.Show();
        }

        void TsiEspaniol_Click(object sender, EventArgs e)
        {
            contexto.DefinirLenguaje(cultura: "es-AR");
            ActualizarLenguaje();
        }

        void TsiIngles_Click(object sender, EventArgs e)
        {
            contexto.DefinirLenguaje(cultura: "en-US");
            ActualizarLenguaje();
        }

        void ActualizarLenguaje()
        {
            Controls.Clear();
            Inicializar();
        }

        void TsSalir_Click(object sender, EventArgs e)
        {
            contexto.Negocio.AsignarUsuarioAutenticado(null);
            Hide();
            
            DialogResult resultado;

            using (var loginForm = new LoginForm())
            {
                resultado = loginForm.ShowDialog();
            }

            if (resultado == DialogResult.OK)
            {
                ConfigurarPerfil();
                Show();
            }
            else
            {
                Dispose();
            }
        }
    }
}
