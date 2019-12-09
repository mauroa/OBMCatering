using System;
using System.Collections.Generic;

namespace OBMCatering.Negocio
{
    public class OrdenPago
    {
        public OrdenPago()
        {
            Items = new List<ItemOrdenPago>();
        }

        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public bool Pagada { get; set; }

        public Proveedor Proveedor { get; set; }

        public ICollection<ItemOrdenPago> Items { get; set; }
    }
}
