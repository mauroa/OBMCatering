using OBMCatering.Negocio;
using System;
using System.Collections.Generic;

namespace OBMCatering.Presentacion
{
    public class OrdenCompraPresentacion
    {
        OrdenCompra ordenCompra;
        int id;
        List<ItemOrdenCompraPresentacion> items;

        public OrdenCompraPresentacion(OrdenCompra ordenCompra)
        {
            this.ordenCompra = ordenCompra;
            id = ordenCompra.Id;
            items = new List<ItemOrdenCompraPresentacion>();

            foreach (ItemOrdenCompra item in ordenCompra.Items)
            {
                items.Add(new ItemOrdenCompraPresentacion(item));
            }

            Fecha = ordenCompra.Fecha;
            Cliente = ordenCompra.OrdenVenta.Cliente.Nombre;
            Estado = ordenCompra.Estado.ToString();
        }

        public DateTime Fecha { get; set; }

        public string Cliente { get; set; }

        public string Estado { get; set; }

        public int ObtenerId()
        {
            return id;
        }

        public IEnumerable<ItemOrdenCompraPresentacion> ObtenerItems()
        {
            return items;
        }

        public OrdenCompra ObtenerOrdenCompra()
        {
            return ordenCompra;
        }
    }
}
