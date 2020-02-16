using OBMCatering.Negocio;
using System;

namespace OBMCatering.Presentacion
{
    /// <summary>
    /// Representacion de la clase <see cref="Bitacora"/> en la capa de presentacion
    /// La idea es aplanar los datos y sus tipos, de manera de poder consultarlos mejor 
    /// y tambien mostrarlos de manera mas simple en una grilla 
    /// </summary>
    public class BitacoraPresentacion
    {
        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="BitacoraPresentacion"/>
        /// </summary>
        /// <param name="bitacora">Bitacora del sistema</param>
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

        /// <summary>
        /// Fecha del evento
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Mensaje del evento
        /// </summary>
        public string Mensaje { get; set; }

        /// <summary>
        /// Tipo de evento
        /// </summary>
        public string Tipo { get; set; }

        /// <summary>
        /// Usuario que genero el evento
        /// </summary>
        public string Usuario { get; set; }

        /// <summary>
        /// Perfil del usuario que genero el evento
        /// </summary>
        public string Perfil { get; set; }
    }
}
