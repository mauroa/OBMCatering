using OBMCatering.Negocio;
using OBMCatering.Presentacion.Properties;
using System;
using System.Windows.Forms;

namespace OBMCatering.Presentacion
{
    /// <summary>
    /// Representa el formulario de login del sistema
    /// </summary>
    public partial class LoginForm : Form
    {
        ContextoPresentacion contexto;
        UsuariosBL usuariosBL;
        bool modoReset;

        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="LoginForm"/>
        /// </summary>
        public LoginForm()
        {
            this.CargarLenguaje();
            InitializeComponent();

            Text = Resources.LoginForm_Titulo;
            lblUsuario.Text = Resources.LoginForm_Usuario;
            lblPassword.Text = Resources.LoginForm_Password;
            lblNuevoPassword.Text = Resources.LoginForm_NuevoPassword;
            btnIngresar.Text = Resources.LoginForm_Ingresar;
            btnCancelar.Text = Resources.LoginForm_Cancelar;
        }

        void LoginForm_Load(object sender, EventArgs e)
        {
            AcceptButton = btnIngresar;

            contexto = ContextoPresentacion.Instancia;
            usuariosBL = new UsuariosBL(contexto.Negocio);

            lblNuevoPassword.Visible = false;
            txtNuevoPassword.Visible = false;
            btnIngresar.Click += BtnIngresar_Click;
            btnCancelar.Click += BtnCancelar_Click;

            LimpiarFormulario();

            contexto.RegistrarEvento(Resources.LoginForm_Ingreso);
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
                    txtNuevoPassword.Focus();
                    lblMensaje.Text = Resources.LoginForm_CambiarPassword;
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

                    contexto.RegistrarEvento(Resources.LoginForm_PasswordReseteado);
                }
                else
                {
                    password = usuariosBL.CrearPasswordHash(txtPassword.Text);
                }

                bool autenticado = usuariosBL.Autenticar(nombreUsuario, password);

                if (autenticado)
                {
                    contexto.RegistrarEvento(Resources.LoginForm_UsuarioAutenticado);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    contexto.RegistrarError(Resources.LoginForm_ErrorAutenticacion);
                }
            }
            catch(Exception ex)
            {
                contexto.RegistrarError(ex, Resources.LoginForm_ErrorAutenticacion);
            }
        }

        void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        void LimpiarFormulario()
        {
            lblMensaje.Text = Resources.LoginForm_IngresarCredenciales;
            txtUsuario.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtNuevoPassword.Text = string.Empty;
            lblNuevoPassword.Visible = false;
            txtNuevoPassword.Visible = false;
            modoReset = false;
        }
    }
}
