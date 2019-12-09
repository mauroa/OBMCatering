using System;
using System.Collections.Generic;

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

        public void Crear(Usuario usuario)
        {
            Datos.UsuariosDAL dalUsuarios = dal.ObtenerUsuariosDAL();
            Datos.PerfilUsuario perfilDAL = dalUsuarios.ObtenerPerfil(usuario.Perfil.ToString());
            Datos.Usuario usuarioDAL = new Datos.Usuario
            {
                Nick = usuario.Nick,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                Password = usuario.Password,
                Perfil = perfilDAL
            };

            dalUsuarios.Crear(usuarioDAL);
            dal.Guardar();
        }

        public void Actualizar(Usuario usuario)
        {
            Datos.UsuariosDAL dalUsuarios = dal.ObtenerUsuariosDAL();
            Datos.PerfilUsuario perfilDAL = dalUsuarios.ObtenerPerfil(usuario.Perfil.ToString());
            Datos.Usuario usuarioDAL = dalUsuarios.Obtener(usuario.Nick);

            usuarioDAL.Nombre = usuario.Nombre;
            usuarioDAL.Email = usuario.Email;
            usuarioDAL.Password = usuario.Password;
            usuarioDAL.Perfil = perfilDAL;

            dalUsuarios.Actualizar(usuarioDAL);
            dal.Guardar();
        }

        public void Eliminar(Usuario usuario)
        {
            Datos.UsuariosDAL dalUsuarios = dal.ObtenerUsuariosDAL();
            Datos.Usuario usuarioDAL = dalUsuarios.Obtener(usuario.Nick);

            dalUsuarios.Eliminar(usuarioDAL);
            dal.Guardar();
        }

        public bool Autenticar(string nick, string password)
        {
            Datos.UsuariosDAL dalUsuarios = dal.ObtenerUsuariosDAL();
            Datos.Usuario usuarioDAL = dalUsuarios.Obtener(nick);
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

        public Usuario Obtener(string nick)
        {
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
                Perfil = perfil
            };
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
