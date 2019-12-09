using System;

namespace OBMCatering.Negocio
{
    public class Factura
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public bool Cobrada { get; set; }

        public OrdenVenta OrdenVenta { get; set; }
    }
}
