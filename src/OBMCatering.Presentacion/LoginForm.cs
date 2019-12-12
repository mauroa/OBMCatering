using OBMCatering.Negocio;
using System;
using System.Windows.Forms;

namespace OBMCatering.Presentacion
{
    public partial class LoginForm : Form
    {
        ContextoPresentacion contexto;
        UsuariosBL usuariosBL;
        bool modoReset;

        public LoginForm()
        {
            InitializeComponent();
        }

        void LoginForm_Load(object sender, EventArgs e)
        {
            contexto = ContextoPresentacion.Instancia;
            usuariosBL = new UsuariosBL(contexto.Negocio);

            lblNuevoPassword.Visible = false;
            txtNuevoPassword.Visible = false;
            btnIngresar.Click += BtnIngresar_Click;
            btnCancelar.Click += BtnCancelar_Click;

            LimpiarFormulario();

            contexto.RegistrarEvento("Ingreso a la pantalla de login");
        }

        void BtnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreUsuario = txtUsuario.Text;
                Usuario usuario = usuariosBL.Obtener(nombreUsuario);

                if (!modoReset && usuario.CambiarPassword)
                {
                    lblNuevoPassword.Visible = true;
                    txtNuevoPassword.Visible = true;
                    lblMensaje.Text = "Se necesita un cambio de password antes de ingresar al sistema. Por favor ingresar nuevo password y continuar";
                    modoReset = true;

                    return;
                }

                string password;

                if (modoReset)
                {
                    string nuevoPassword = usuariosBL.CrearPasswordHash(txtNuevoPassword.Text);

                    usuario.Password = nuevoPassword;
                    usuario.CambiarPassword = false;
                    usuariosBL.Actualizar(usuario);

                    password = nuevoPassword;
                    modoReset = false;

                    contexto.RegistrarEvento("El password ha sido reseteado");
                }
                else
                {
                    password = usuariosBL.CrearPasswordHash(txtPassword.Text);
                }

                bool autenticado = usuariosBL.Autenticar(nombreUsuario, password);

                if (autenticado)
                {
                    contexto.RegistrarEvento("El usuario ha sido autenticado correctamente");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    contexto.RegistrarEvento("El usuario ha fallado la autenticacion");
                    DialogResult = DialogResult.Abort;
                }
            }
            catch(Exception ex)
            {
                contexto.RegistrarError(ex);
            }
        }

        void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        void LimpiarFormulario()
        {
            lblMensaje.Text = "Ingrese Usuario y Password para acceder al sistema OBM Catering";
            txtUsuario.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtNuevoPassword.Text = string.Empty;
            lblNuevoPassword.Visible = false;
            txtNuevoPassword.Visible = false;
            modoReset = false;
        }
    }
}
