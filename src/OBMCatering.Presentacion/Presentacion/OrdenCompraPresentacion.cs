using OBMCatering.Negocio;
using System;
using System.Collections.Generic;

namespace OBMCatering.Presentacion
{
    public class OrdenCompraPresentacion
    {
        int id;
        List<ItemOrdenCompraPresentacion> items;

        public OrdenCompraPresentacion(OrdenCompra ordenCompra)
        {
            Fecha = ordenCompra.Fecha;
            Cliente = ordenCompra.OrdenVenta.Cliente.Nombre;
            Ejecutada = ordenCompra.Ejecutada;
            id = ordenCompra.Id;
            items = new List<ItemOrdenCompraPresentacion>();

            foreach(ItemOrdenCompra item in ordenCompra.Items)
            {
                items.Add(new ItemOrdenCompraPresentacion(item));
            }
        }

        public DateTime Fecha { get; set; }

        public string Cliente { get; set; }

        public bool Ejecutada { get; set; }

        public int ObtenerId()
        {
            return id;
        }

        public IEnumerable<ItemOrdenCompraPresentacion> ObtenerItems()
        {
            return items;
        }
    }
}
