using OBMCatering.Datos;
using OBMCatering.Negocio.Properties;
using System.IO;

namespace OBMCatering.Negocio
{
    public class ContextoNegocio
    {
        static ContextoNegocio instancia;
        OBMCateringDAL dal;
        Usuario usuarioAutenticado;

        private ContextoNegocio()
        {
            dal = new OBMCateringDAL(new OBMCateringEntities());
            Bitacora = new BitacoraBL(this, new UsuariosBL(this));
        }

        public static ContextoNegocio Instancia
        {
            get
            {
                if(instancia == null)
                {
                    instancia = new ContextoNegocio();
                }

                return instancia;
            }
        }

        public BitacoraBL Bitacora { get; }

        public OBMCateringDAL ObtenerDatos()
        {
            return dal;
        }

        public bool Backup (string nombreArchivo)
        {
            dal.Backup(nombreArchivo);

            return File.Exists(nombreArchivo);
        }

        public void Restaurar(string nombreArchivo)
        {
            if(!File.Exists(nombreArchivo))
            {
                throw new FileNotFoundException(string.Format(Resources.ContextoNegocio_Restaurar_BDNoExiste, nombreArchivo));
            }

            dal.Restaurar(nombreArchivo);
        }

        public void AsignarUsuarioAutenticado(Usuario usuario)
        {
            usuarioAutenticado = usuario;
        }

        public Usuario ObtenerUsuarioAutenticado()
        {
            return usuarioAutenticado;
        }
    }
}
