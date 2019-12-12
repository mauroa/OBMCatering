using OBMCatering.Negocio;
using System;

namespace OBMCatering.Presentacion
{
    public class BitacoraPresentacion
    {
        public BitacoraPresentacion(Bitacora bitacora)
        {
            Fecha = bitacora.Fecha;
            Mensaje = bitacora.Mensaje;
            Tipo = bitacora.Tipo.ToString();

            if(bitacora.Usuario != null)
            {
                Usuario = bitacora.Usuario.Nick;
                Perfil = bitacora.Usuario.Perfil.ToString();
            }
        }

        public DateTime Fecha { get; set; }

        public string Mensaje { get; set; }

        public string Tipo { get; set; }

        public string Usuario { get; set; }

        public string Perfil { get; set; }
    }
}
