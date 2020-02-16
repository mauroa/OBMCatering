using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OBMCatering.Datos
{
    /// <summary>
    /// Responsable de manejar los usuarios dentro de la capa de acceso a datos del sistema
    /// </summary>
    public class UsuariosDAL
    {
        OBMCateringEntities modelo;

        public UsuariosDAL(OBMCateringEntities modelo)
        {
            this.modelo = modelo;
        }

        public void Crear(Usuario usuario)
        {
            modelo.Usuarios.Add(usuario);
        }

        public void Actualizar(Usuario usuario)
        {
            modelo.Usuarios.Attach(usuario);
            modelo.Entry(usuario).State = EntityState.Modified;
        }

        public void Eliminar(Usuario usuario)
        {
            modelo.Usuarios.Remove(usuario);
        }

        public IEnumerable<Usuario> Obtener()
        {
            return modelo.Usuarios.ToList();
        }

        public IEnumerable<Usuario> ObtenerPorPerfil(string perfil)
        {
            List<Usuario> usuarios = new List<Usuario>();

            foreach(Usuario usuario in modelo.Usuarios)
            {
                if(usuario.Perfil.Nombre == perfil)
                {
                    usuarios.Add(usuario);
                }
            }

            return usuarios;
        }

        public Usuario Obtener(string nick)
        {
            return modelo.Usuarios.Find(nick);
        }

        public IEnumerable<PerfilUsuario> ObtenerPerfiles()
        {
            return modelo.PerfilesUsuario.ToList();
        }

        public PerfilUsuario ObtenerPerfil(string perfil)
        {
            PerfilUsuario resultado = null;

            foreach(PerfilUsuario perfilUsuario in modelo.PerfilesUsuario)
            {
                if(perfilUsuario.Nombre == perfil)
                {
                    resultado = perfilUsuario;
                    break;
                }
            }

            return resultado;
        }
    }
}
