using OBMCatering.Negocio;
using System;
using System.Windows.Forms;

namespace OBMCatering.Presentacion
{
    public class ContextoPresentacion
    {
        static ContextoPresentacion instancia;

        private ContextoPresentacion()
        {
            Negocio = ContextoNegocio.Instancia;
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

        public void RegistrarEvento(string mensaje, params string[] argumentos)
        {
            Negocio.Bitacora.Registrar(string.Format(mensaje, argumentos), TipoMensajeBitacora.Informacion);
        }

        public void RegistrarAlerta(string alerta, params string[] argumentos)
        {
            string mensaje = string.Format(alerta, argumentos);

            Negocio.Bitacora.Registrar(mensaje, TipoMensajeBitacora.Alerta);
            MessageBox.Show(mensaje, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void RegistrarError(Exception excepcion)
        {
            RegistrarError(excepcion, mensaje: null);
        }

        public void RegistrarError(Exception excepcion, string mensaje)
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
                    error = "Ocurrio un error inesperado";
                }
                else
                {
                    error = mensaje;
                }

                error = string.Format("{0}. Detalle: {1}", error, excepcion.Message);
            }

            RegistrarError(error);
        }

        public void RegistrarError(string error, params string[] argumentos)
        {
            string mensaje = string.Format(error, argumentos);

            Negocio.Bitacora.Registrar(mensaje, TipoMensajeBitacora.Error);
            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
