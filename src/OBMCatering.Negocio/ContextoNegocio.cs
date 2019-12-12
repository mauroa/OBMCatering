using OBMCatering.Datos;

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
