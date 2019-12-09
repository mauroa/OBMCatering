using System;

namespace OBMCatering.Negocio
{
    public class Bitacora
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public string Mensaje { get; set; }

        public TipoMensajeBitacora Tipo { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
