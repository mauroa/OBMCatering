using OBMCatering.Negocio;
using OBMCatering.Presentacion.Properties;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace OBMCatering.Presentacion
{
    /// <summary>
    /// Representa el contexto de informacion de la capa de presentacion y vistas del sistema
    /// </summary>
    public class ContextoPresentacion
    {
        static ContextoPresentacion instancia;
        static string lenguajeDefault = "es-AR";

        private ContextoPresentacion()
        {
            Negocio = ContextoNegocio.Instancia;
            Lenguaje = CultureInfo.GetCultureInfo(lenguajeDefault);

            Negocio.DatosInicializados += Negocio_DatosInicializados;
        }

        /// <summary>
        /// Devuelve una instancia compartida de <see cref="ContextoPresentacion"/>
        /// Esta clase no puede instanciarse ya que esta creada para representar un contexto de ejecucion unico dentro del sistema
        /// </summary>
        public static ContextoPresentacion Instancia
        {
            //Esta clase tiene aplicado el patron Singleton, para poder tener solo una instancia compartida en el sitema y accesible por todos
            get
            {
                if (instancia == null)
                {
                    instancia = new ContextoPresentacion();
                }

                return instancia;
            }
        }

        /// <summary>
        /// Contexto de negocio del sistema, el cual expone informacion de la capa de negocio del mismo
        /// </summary>
        public ContextoNegocio Negocio { get; }

        /// <summary>
        /// Lenguaje actual configurado en el sistema
        /// </summary>
        public CultureInfo Lenguaje { get; private set; }

        /// <summary>
        /// Permite definir el lenguaje del sistema pasandole el valor de la cultura
        /// </summary>
        /// <param name="cultura">
        /// Valor de la cultura. 
        /// Valores posibles: <see href="https://docs.microsoft.com/en-us/openspecs/windows_protocols/ms-lcid/926e694f-1797-4418-a922-343d1c5e91a6"/>
        /// </param>
        public void DefinirLenguaje(string cultura)
        {
            try
            {
                Lenguaje = CultureInfo.GetCultureInfo(cultura);
            }
            catch(Exception ex)
            {
                Lenguaje = CultureInfo.GetCultureInfo(lenguajeDefault);
                RegistrarError(ex);
            }
        }

        /// <summary>
        /// Registra un evento del sistema como informacion y a su vez muestra una ventana de mensaje
        /// </summary>
        /// <param name="informacion">Mensaje a informar</param>
        /// <param name="argumentos">Parametros del mensaje si es que contiene</param>
        public void MostrarEvento(string informacion, params string[] argumentos)
        {
            RegistrarEvento(informacion, argumentos);
            MessageBox.Show(string.Format(informacion, argumentos), Resources.ContextoPresentacion_Informacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Registra un evento del sistema como informacion
        /// </summary>
        /// <param name="informacion">Mensaje a informar</param>
        /// <param name="argumentos">Parametros del mensaje si es que contiene</param>
        public void RegistrarEvento(string informacion, params string[] argumentos)
        {
            Negocio.Bitacora.Registrar(string.Format(informacion, argumentos), TipoMensajeBitacora.Informacion);
        }

        /// <summary>
        /// Registra un evento del sistema como alerta y a su vez muestra una ventana de mensaje
        /// </summary>
        /// <param name="alerta">Mensaje de alerta</param>
        /// <param name="argumentos">Parametros del mensaje si es que contiene</param>
        public void RegistrarAlerta(string alerta, params string[] argumentos)
        {
            string mensaje = string.Format(alerta, argumentos);

            Negocio.Bitacora.Registrar(mensaje, TipoMensajeBitacora.Alerta);
            MessageBox.Show(mensaje, Resources.ContextoPresentacion_Alerta, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Registra un evento del sistema como error y a su vez muestra una ventana de mensaje
        /// </summary>
        /// <param name="excepcion">Excepcion del sistema que se mostrara como un error</param>
        public void RegistrarError(Exception excepcion)
        {
            RegistrarError(excepcion, mensaje: null);
        }

        /// <summary>
        /// Registra un evento del sistema como error y a su vez muestra una ventana de mensaje
        /// </summary>
        /// <param name="excepcion">Excepcion del sistema que se mostrara como un error</param>
        /// <param name="mensaje">Mensaje de error</param>
        /// <param name="argumentos">Parametros del mensaje si es que contiene</param>
        public void RegistrarError(Exception excepcion, string mensaje, params string[] argumentos)
        {
            string error;

            if (excepcion is OBMCateringException)
            {
                if(string.IsNullOrEmpty(mensaje))
                {
                    error = excepcion.Message;
                }
                else
                {
                    mensaje = string.Format(mensaje, argumentos);
                    error = string.Format("{0}. {1}", mensaje, excepcion.Message);
                }
            }
            else
            {
                if (string.IsNullOrEmpty(mensaje))
                {
                    error = Resources.ContextoPresentacion_Error_Mensaje;
                }
                else
                {
                    mensaje = string.Format(mensaje, argumentos);
                    error = mensaje;
                }

                error = string.Format(Resources.ContextoPresentacion_Error_Detalle, error, excepcion.Message);
            }

            RegistrarError(error);
        }

        /// <summary>
        /// Registra un evento del sistema como error y a su vez muestra una ventana de mensaje
        /// </summary>
        /// <param name="error">Mensaje de error</param>
        /// <param name="argumentos">Parametros del mensaje si es que contiene</param>
        public void RegistrarError(string error, params string[] argumentos)
        {
            string mensaje = string.Format(error, argumentos);

            Negocio.Bitacora.Registrar(mensaje, TipoMensajeBitacora.Error);
            MessageBox.Show(mensaje, Resources.ContextoPresentacion_Error_Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void Negocio_DatosInicializados(object sender, EventArgs e)
        {
            MostrarEvento(Resources.ContextoPresentacion_InicializacionFinalizada);
        }
    }
}
