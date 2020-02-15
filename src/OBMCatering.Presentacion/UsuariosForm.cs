using OBMCatering.Negocio;
using OBMCatering.Presentacion.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OBMCatering.Presentacion
{
    public partial class UsuariosForm : Form
    {
        ContextoPresentacion contexto;
        UsuariosBL usuariosBL;

        public UsuariosForm()
        {
            this.CargarLenguaje();
            InitializeComponent();

            Text = Resources.UsuariosForm_Titulo;
            lblUsuario.Text = Resources.UsuariosForm_Datos_Usuario;
            lblNombre.Text = Resources.UsuariosForm_Datos_Nombre;
            lblEmail.Text = Resources.UsuariosForm_Datos_Email;
            lblPassword.Text = Resources.UsuariosForm_Datos_Password;
            lblPerfil.Text = Resources.UsuariosForm_Datos_Perfil;
            chkResetear.Text = Resources.UsuariosForm_Datos_Resetear;
            btnGuardar.Text = Resources.UsuariosForm_Datos_Guardar;

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            HelpButton = true;
            HelpRequested += UsuariosForm_HelpRequested;
        }

        void UsuariosForm_Load(object sender, EventArgs e)
        {
            AcceptButton = btnGuardar;

            contexto = ContextoPresentacion.Instancia;
            usuariosBL = new UsuariosBL(contexto.Negocio);

            btnGuardar.Click += BtnGuardar_Click;
            grvUsuarios.SelectionChanged += GrvUsuarios_SelectionChanged;
            grvUsuarios.CellEnter += GrvUsuarios_CellEnter;
            CargarPerfiles();
            CargarUsuarios();
            LimpiarFormulario();

            contexto.RegistrarEvento(Resources.UsuariosForm_Ingreso);
        }

        void UsuariosForm_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show(Resources.UsuariosForm_Help_Mensaje, Resources.Form_Help_Titulo, MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                bool existeUsuario = usuariosBL.Existe(txtUsuario.Text);
                Usuario usuario;

                if (existeUsuario)
                {
                    usuario = usuariosBL.Obtener(txtUsuario.Text);

                    SetearUsuario(usuario, esActualizacion: true);
                    usuariosBL.Actualizar(usuario);

                    contexto.RegistrarEvento(Resources.UsuariosForm_UsuarioActualizado, usuario.Nombre);
                }
                else
                {
                    usuario = new Usuario();

                    SetearUsuario(usuario, esActualizacion: false);
                    usuariosBL.Crear(usuario);

                    contexto.RegistrarEvento(Resources.UsuariosForm_UsuarioCreado, usuario.Nombre);
                }

                CargarUsuarios();
                LimpiarFormulario();
            }
            catch(Exception ex)
            {
                contexto.RegistrarError(ex);
            }
        }

        void GrvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            int filasSeleccionadas = grvUsuarios.SelectedRows.Count;

            if (filasSeleccionadas == 0 || filasSeleccionadas > 1) return;

            DataGridViewRow filaSeleccionada = grvUsuarios.SelectedRows[0];
            UsuarioPresentacion usuarioSeleccionado = (UsuarioPresentacion)filaSeleccionada.DataBoundItem;

            CargarUsuarioSeleccionado(usuarioSeleccionado);
        }

        void GrvUsuarios_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaSeleccionada = grvUsuarios.Rows[e.RowIndex];

            filaSeleccionada.Selected = true;

            UsuarioPresentacion usuarioSeleccionado = (UsuarioPresentacion)filaSeleccionada.DataBoundItem;

            CargarUsuarioSeleccionado(usuarioSeleccionado);
        }

        void CargarPerfiles()
        {
            cboPerfil.Items.Add(PerfilUsuario.Admin.ToString());
            cboPerfil.Items.Add(PerfilUsuario.Cocina.ToString());
            cboPerfil.Items.Add(PerfilUsuario.Compras.ToString());
            cboPerfil.Items.Add(PerfilUsuario.Ventas.ToString());
        }

        void CargarUsuarios()
        {
            try
            {
                IEnumerable<Usuario> usuarios = usuariosBL.Obtener();

                grvUsuarios.DataSource = ObtenerUsuariosPresentacion(usuarios);
            }
            catch (Exception ex)
            {
                contexto.RegistrarError(ex);
            }
        }

        IEnumerable<UsuarioPresentacion> ObtenerUsuariosPresentacion(IEnumerable<Usuario> usuarios)
        {
            List<UsuarioPresentacion> usuariosPresentacion = new List<UsuarioPresentacion>();

            foreach (Usuario usuario in usuarios)
            {
                usuariosPresentacion.Add(new UsuarioPresentacion(usuario));
            }

            return usuariosPresentacion;
        }

        void SetearUsuario(Usuario usuario, bool esActualizacion)
        {
            PerfilUsuario perfil = (PerfilUsuario)Enum.Parse(typeof(PerfilUsuario), cboPerfil.SelectedItem.ToString());

            usuario.Nick = txtUsuario.Text;
            usuario.Nombre = txtNombre.Text;
            usuario.Email = txtEmail.Text;
            usuario.Perfil = perfil;
            usuario.CambiarPassword = chkResetear.Checked;

            if (!esActualizacion)
            {
                usuario.Password = usuariosBL.CrearPasswordHash(txtPassword.Text);
            }
        }

        void CargarUsuarioSeleccionado(UsuarioPresentacion usuario)
        {
            txtUsuario.Text = usuario.Nick;
            txtNombre.Text = usuario.Nombre;
            txtEmail.Text = usuario.Email;
            txtPassword.Text = usuario.Password;
            txtPassword.Enabled = false;
            cboPerfil.SelectedItem = usuario.Perfil;
            chkResetear.Checked = usuario.Resetear;
        }

        void LimpiarFormulario()
        {
            txtUsuario.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtPassword.Enabled = true;
            cboPerfil.SelectedItem = null;
            chkResetear.Checked = false;
            grvUsuarios.ClearSelection();
        }
    }
}
