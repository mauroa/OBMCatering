using OBMCatering.Negocio.Properties;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace OBMCatering.Negocio
{
    /// <summary>
    /// Reponsable de manejar los usuarios del sistema dentro de la capa de negocio del mismo
    /// </summary>
    public class UsuariosBL
    {
        ContextoNegocio contexto;
        Datos.OBMCateringDAL dal;

        /// <summary>
        /// Crea una nueva instancia de <see cref="UsuariosBL"/>
        /// </summary>
        /// <param name="contexto">Contexto de negocio</param>
        public UsuariosBL(ContextoNegocio contexto)
        {
            this.contexto = contexto;
            dal = contexto.ObtenerDatos();
        }

        /// <summary>
        /// Crea un hash para un password determinado
        /// Como medida de seguridad no se guardan passwords en texto claro en la base de datos,
        /// con lo cual se utiliza una funcion hash conocida (MD5) que convierte al texto en otro texto con longitud fija
        /// y cuyo valor sera unico por cada valor de texto original.
        /// Esto segura que cada hash sera unico para cada valor de texto, con lo cual
        /// calculando el hash de un texto y comparandolo con el hash guardado en la base de datos sera suficiente para asegurar
        /// que son el mismo valor y sera prueba suficiente para autenticar al usuario
        /// </summary>
        /// <param name="password">Password para crear su hash</param>
        /// <returns>El hash del password</returns>
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

        /// <summary>
        /// Crea un nuevo usuario en el sistema
        /// </summary>
        /// <param name="usuario">Usuario a crear</param>
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

        /// <summary>
        /// Actualiza la informacion de un determinado usuario en el sistema
        /// </summary>
        /// <param name="usuario">usuario a actualizar</param>
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

        /// <summary>
        /// Autentica al usuario en el sistema, lo cual permite determinar si las credenciales (usuario y password)
        /// son correctas y estan registradas y autorizadas.
        /// </summary>
        /// <param name="nick">Nombre de usuario a autenticar</param>
        /// <param name="password">Password del usuario a autenticar. Se asume que el valor del password ya esta hasheado, con lo
        /// cual no se calculara su hash y se comparara su valor directamente con el de la base de datos</param>
        /// <returns>Valor que determina si el usuario ha sido autenticado o no</returns>
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

        /// <summary>
        /// Obtiene el listado completo de usuarios del sistema
        /// </summary>
        /// <returns>Listado de usuarios</returns>
        public IEnumerable<Usuario> Obtener()
        {
            Datos.UsuariosDAL dalUsuarios = dal.ObtenerUsuariosDAL();
            IEnumerable<Datos.Usuario> usuariosDAL = dalUsuarios.Obtener();

            return Obtener(usuariosDAL);
        }

        /// <summary>
        /// Obtiene un listado de usuarios para determinado perfil
        /// </summary>
        /// <param name="perfil">Perfil de los usuarios a obtener</param>
        /// <returns>Listado de usuarios con ese perfil</returns>
        public IEnumerable<Usuario> Obtener(PerfilUsuario perfil)
        {
            Datos.UsuariosDAL dalUsuarios = dal.ObtenerUsuariosDAL();
            IEnumerable<Datos.Usuario> usuariosDAL = dalUsuarios.ObtenerPorPerfil(perfil.ToString());

            return Obtener(usuariosDAL);
        }

        /// <summary>
        /// Determina si un usuario existe en el sistema segun su nombre de usuario
        /// </summary>
        /// <param name="nick">Nombre de usuario</param>
        /// <returns>Valor que determina si el usuario existe o no</returns>
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

        /// <summary>
        /// Obtiene un usuario segun su nombre de usuario
        /// </summary>
        /// <param name="nick">Nombre de usuario</param>
        /// <returns>Usuario encontrado</returns>
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
