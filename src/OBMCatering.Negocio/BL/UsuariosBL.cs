using OBMCatering.Negocio.Properties;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace OBMCatering.Negocio
{
    public class UsuariosBL
    {
        ContextoNegocio contexto;
        Datos.OBMCateringDAL dal;

        public UsuariosBL(ContextoNegocio contexto)
        {
            this.contexto = contexto;
            dal = contexto.ObtenerDatos();
        }

        public string CrearPasswordHash(string password)
        {
            if(string.IsNullOrEmpty(password))
            {
                throw new OBMCateringException(Resources.UsuariosBL_Validaciones_PasswordNull);
            }

            using (var md5 = MD5.Create())
            {
                StringBuilder builder = new StringBuilder();
                byte[] passwordBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(password));

                foreach (byte b in passwordBytes)
                {
                    builder.Append(b.ToString("x2").ToLower());
                }

                return builder.ToString();
            }
        }

        public void Crear(Usuario usuario)
        {
            ValidarUsuario(usuario);

            Datos.UsuariosDAL dalUsuarios = dal.ObtenerUsuariosDAL();
            Datos.PerfilUsuario perfilDAL = dalUsuarios.ObtenerPerfil(usuario.Perfil.ToString());

            if (perfilDAL == null)
            {
                throw new OBMCateringException(string.Format(Resources.UsuariosBL_Validaciones_PerfilInvalido, usuario.Perfil));
            }

            Datos.Usuario usuarioDAL = new Datos.Usuario
            {
                Nick = usuario.Nick,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                Password = usuario.Password,
                Perfil = perfilDAL,
                CambiarPassword = usuario.CambiarPassword
            };

            dalUsuarios.Crear(usuarioDAL);
            dal.Guardar();
        }

        public void Actualizar(Usuario usuario)
        {
            ValidarUsuario(usuario);

            Datos.UsuariosDAL dalUsuarios = dal.ObtenerUsuariosDAL();
            Datos.PerfilUsuario perfilDAL = dalUsuarios.ObtenerPerfil(usuario.Perfil.ToString());

            if (perfilDAL == null)
            {
                throw new OBMCateringException(string.Format(Resources.UsuariosBL_Validaciones_PerfilInvalido, usuario.Perfil));
            }

            Datos.Usuario usuarioDAL = dalUsuarios.Obtener(usuario.Nick);

            if (usuarioDAL == null)
            {
                throw new OBMCateringException(string.Format(Resources.UsuariosBL_Validaciones_UsuarioInvalido, usuario.Nick));
            }

            usuarioDAL.Nombre = usuario.Nombre;
            usuarioDAL.Email = usuario.Email;
            usuarioDAL.Password = usuario.Password;
            usuarioDAL.Perfil = perfilDAL;
            usuarioDAL.CambiarPassword = usuario.CambiarPassword;

            dalUsuarios.Actualizar(usuarioDAL);
            dal.Guardar();
        }

        public void Eliminar(Usuario usuario)
        {
            ValidarUsuario(usuario);

            Datos.UsuariosDAL dalUsuarios = dal.ObtenerUsuariosDAL();
            Datos.Usuario usuarioDAL = dalUsuarios.Obtener(usuario.Nick);

            if (usuarioDAL == null)
            {
                throw new OBMCateringException(string.Format(Resources.UsuariosBL_Validaciones_UsuarioInvalido, usuario.Nick));
            }

            dalUsuarios.Eliminar(usuarioDAL);
            dal.Guardar();
        }

        public bool Autenticar(string nick, string password)
        {
            if (string.IsNullOrEmpty(nick))
            {
                throw new OBMCateringException(Resources.UsuariosBL_Validaciones_NombreNull);
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new OBMCateringException(Resources.UsuariosBL_Validaciones_PasswordNull);
            }

            Datos.UsuariosDAL dalUsuarios = dal.ObtenerUsuariosDAL();
            Datos.Usuario usuarioDAL = dalUsuarios.Obtener(nick);

            if (usuarioDAL == null)
            {
                throw new OBMCateringException(string.Format(Resources.UsuariosBL_Validaciones_UsuarioInvalido, nick));
            }

            bool autenticado = usuarioDAL != null && usuarioDAL.Password == password;

            if(autenticado)
            {
                Usuario usuario = Obtener(usuarioDAL);

                contexto.AsignarUsuarioAutenticado(usuario);
            }

            return autenticado;
        }

        public IEnumerable<Usuario> Obtener()
        {
            Datos.UsuariosDAL dalUsuarios = dal.ObtenerUsuariosDAL();
            IEnumerable<Datos.Usuario> usuariosDAL = dalUsuarios.Obtener();

            return Obtener(usuariosDAL);
        }

        public IEnumerable<Usuario> Obtener(PerfilUsuario perfil)
        {
            Datos.UsuariosDAL dalUsuarios = dal.ObtenerUsuariosDAL();
            IEnumerable<Datos.Usuario> usuariosDAL = dalUsuarios.ObtenerPorPerfil(perfil.ToString());

            return Obtener(usuariosDAL);
        }

        public bool Existe(string nick)
        {
            if (string.IsNullOrEmpty(nick))
            {
                throw new OBMCateringException(Resources.UsuariosBL_Validaciones_NickNull);
            }

            Datos.UsuariosDAL dalUsuarios = dal.ObtenerUsuariosDAL();
            Datos.Usuario usuarioDAL = dalUsuarios.Obtener(nick);

            return usuarioDAL != null;
        }

        public Usuario Obtener(string nick)
        {
            if (string.IsNullOrEmpty(nick))
            {
                throw new OBMCateringException(Resources.UsuariosBL_Validaciones_NickNull);
            }

            Datos.UsuariosDAL dalUsuarios = dal.ObtenerUsuariosDAL();
            Datos.Usuario usuarioDAL = dalUsuarios.Obtener(nick);

            return Obtener(usuarioDAL);
        }

        internal Usuario Obtener(Datos.Usuario usuarioDAL)
        {
            PerfilUsuario perfil = (PerfilUsuario)Enum.Parse(typeof(PerfilUsuario), usuarioDAL.Perfil.Nombre);

            return new Usuario
            {
                Nick = usuarioDAL.Nick,
                Nombre = usuarioDAL.Nombre,
                Email = usuarioDAL.Email,
                Password = usuarioDAL.Password,
                Perfil = perfil,
                CambiarPassword = usuarioDAL.CambiarPassword
            };
        }

        void ValidarUsuario(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new OBMCateringException(Resources.UsuariosBL_Validaciones_UsuarioNull);
            }

            if (string.IsNullOrEmpty(usuario.Nick))
            {
                throw new OBMCateringException(Resources.UsuariosBL_Validaciones_NickNull);
            }

            if (string.IsNullOrEmpty(usuario.Nombre))
            {
                throw new OBMCateringException(Resources.UsuariosBL_Validaciones_NombreNull);
            }

            if (string.IsNullOrEmpty(usuario.Password))
            {
                throw new OBMCateringException(Resources.UsuariosBL_Validaciones_PasswordNull);
            }

            if (string.IsNullOrEmpty(usuario.Email))
            {
                throw new OBMCateringException(Resources.BL_Validaciones_EmailNull);
            }
        }

        IEnumerable<Usuario> Obtener(IEnumerable<Datos.Usuario> usuariosDAL)
        {
            List<Usuario> usuarios = new List<Usuario>();

            foreach (Datos.Usuario usuarioDAL in usuariosDAL)
            {
                Usuario usuario = Obtener(usuarioDAL);

                usuarios.Add(usuario);
            }

            return usuarios;
        }
    }
}
