using OBMCatering.Negocio;
using OBMCatering.Presentacion.Properties;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace OBMCatering.Presentacion
{
    public class ContextoPresentacion
    {
        static ContextoPresentacion instancia;
        static string lenguajeDefault = "es-AR";

        private ContextoPresentacion()
        {
            Negocio = ContextoNegocio.Instancia;
            Lenguaje = CultureInfo.GetCultureInfo(lenguajeDefault);
        }

        public static ContextoPresentacion Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ContextoPresentacion();
                }

                return instancia;
            }
        }

        public ContextoNegocio Negocio { get; }

        public CultureInfo Lenguaje { get; private set; }

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

        public void MostrarEvento(string informacion, params string[] argumentos)
        {
            RegistrarEvento(informacion, argumentos);
            MessageBox.Show(string.Format(informacion, argumentos), Resources.ContextoPresentacion_Informacion, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void RegistrarEvento(string informacion, params string[] argumentos)
        {
            Negocio.Bitacora.Registrar(string.Format(informacion, argumentos), TipoMensajeBitacora.Informacion);
        }

        public void RegistrarAlerta(string alerta, params string[] argumentos)
        {
            string mensaje = string.Format(alerta, argumentos);

            Negocio.Bitacora.Registrar(mensaje, TipoMensajeBitacora.Alerta);
            MessageBox.Show(mensaje, Resources.ContextoPresentacion_Alerta, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void RegistrarError(Exception excepcion)
        {
            RegistrarError(excepcion, mensaje: null);
        }

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
                    error = mensaje;
                }

                error = string.Format(Resources.ContextoPresentacion_Error_Detalle, error, excepcion.Message);
            }

            RegistrarError(error);
        }

        public void RegistrarError(string error, params string[] argumentos)
        {
            string mensaje = string.Format(error, argumentos);

            Negocio.Bitacora.Registrar(mensaje, TipoMensajeBitacora.Error);
            MessageBox.Show(mensaje, Resources.ContextoPresentacion_Error_Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
