using System;

namespace OBMCatering.Negocio
{
    /// <summary>
    /// Representa la informacion que se guarda en el sistema en cada accion importante
    /// </summary>
    public class Bitacora
    {
        /// <summary>
        /// Identificador
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Fecha del evento
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Mensaje del evento
        /// </summary>
        public string Mensaje { get; set; }

        /// <summary>
        /// Tipo de mensaje
        /// </summary>
        public TipoMensajeBitacora Tipo { get; set; }

        /// <summary>
        /// Usuario que realizo la accion que desencadeno el evento
        /// </summary>
        public Usuario Usuario { get; set; }
    }
}
