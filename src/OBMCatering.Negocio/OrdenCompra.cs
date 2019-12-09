using System;
using System.Collections.Generic;

namespace OBMCatering.Negocio
{
    public class OrdenCompra
    {
        public OrdenCompra()
        {
            Items = new List<ItemOrdenCompra>();
        }

        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public bool Ejecutada { get; set; }

        public OrdenVenta OrdenVenta { get; set; }

        public ICollection<ItemOrdenCompra> Items { get; set; }
    }
}
