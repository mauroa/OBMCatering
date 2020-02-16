using OBMCatering.Datos;
using OBMCatering.Negocio.Properties;
using System;
using System.IO;

namespace OBMCatering.Negocio
{
    /// <summary>
    /// Representa el contexto de informacion de la capa de negocio del sistema
    /// </summary>
    public class ContextoNegocio
    {
        static ContextoNegocio instancia;
        OBMCateringDAL dal;
        Usuario usuarioAutenticado;

        private ContextoNegocio()
        {
            dal = new OBMCateringDAL(new OBMCateringEntities());
            dal.DatosInicializados += Dal_DatosInicializados;

            Bitacora = new BitacoraBL(this, new UsuariosBL(this));
        }

        /// <summary>
        /// Devuelve una instancia compartida de <see cref="ContextoNegocio"/>
        /// Esta clase no puede instanciarse ya que esta creada para representar un contexto de ejecucion unico dentro del sistema
        /// </summary>
        public static ContextoNegocio Instancia
        {
            //Esta clase tiene aplicado el patron Singleton, para poder tener solo una instancia compartida en el sitema y accesible por todos
            get
            {
                if(instancia == null)
                {
                    instancia = new ContextoNegocio();
                }

                return instancia;
            }
        }

        /// <summary>
        /// Evento que notifica cuando la carga inicial de datos ha finalizado
        /// </summary>
        public event EventHandler DatosInicializados;

        /// <summary>
        /// Indica si el sistema se esta inicializando, lo cual indica mayormente que los datos se estan cargando por primera vez
        /// </summary>
        public bool EstaInicializando
        {
            get
            {
                return dal.EstaInicializando;
            }
        }

        /// <summary>
        /// Provee la bitacora del sistema para poder registrar eventos
        /// </summary>
        public BitacoraBL Bitacora { get; }

        /// <summary>
        /// Realiza el backup de los datos del sistema en el archivo indicado
        /// </summary>
        /// <param name="nombreArchivo">Archivo donde se guardara el backup realizado</param>
        /// <returns>Indica si el backup se realizo correctamente</returns>
        public bool Backup (string nombreArchivo)
        {
            dal.Backup(nombreArchivo);

            return File.Exists(nombreArchivo);
        }

        /// <summary>
        /// Realiza la restauracion de los datos del sistema desde el archivo indicado
        /// </summary>
        /// <param name="nombreArchivo">Archivo desde donde se restauraran los datos</param>
        public void Restaurar(string nombreArchivo)
        {
            if(!File.Exists(nombreArchivo))
            {
                throw new FileNotFoundException(string.Format(Resources.ContextoNegocio_Restaurar_BDNoExiste, nombreArchivo));
            }

            dal.Restaurar(nombreArchivo);
        }

        /// <summary>
        /// Asigna el usuario autenticado en el sistema para dejarlo disponible de consultar
        /// </summary>
        /// <param name="usuario"></param>
        public void AsignarUsuarioAutenticado(Usuario usuario)
        {
            usuarioAutenticado = usuario;
        }

        /// <summary>
        /// Devuelve el usuario autenticado en el sistema para poder accederlo desde cualquier lado
        /// </summary>
        /// <returns>Usuario autenticado</returns>
        public Usuario ObtenerUsuarioAutenticado()
        {
            return usuarioAutenticado;
        }

        /// <summary>
        /// Provee acceso a la capa de datos
        /// El metodo es interno para preservar la separacion de capas y que desde afuera de la capa de negocio no pueda accederse a los datos
        /// </summary>
        internal OBMCateringDAL ObtenerDatos()
        {
            return dal;
        }

        void Dal_DatosInicializados(object sender, EventArgs e)
        {
            if (DatosInicializados != null)
            {
                DatosInicializados(this, EventArgs.Empty);
            }
        }
    }
}
