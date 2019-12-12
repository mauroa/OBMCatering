using OBMCatering.Negocio;
using System;
using System.Collections.Generic;

namespace OBMCatering.Presentacion
{
    public class OrdenPagoPresentacion
    {
        OrdenPago ordenPago;
        int id;
        List<ItemOrdenPagoPresentacion> items;

        public OrdenPagoPresentacion(OrdenPago ordenPago)
        {
            this.ordenPago = ordenPago;
            id = ordenPago.Id;
            items = new List<ItemOrdenPagoPresentacion>();

            foreach (ItemOrdenPago item in ordenPago.Items)
            {
                items.Add(new ItemOrdenPagoPresentacion(item));
            }

            Fecha = ordenPago.Fecha;
            Pagada = ordenPago.Pagada;
            Proveedor = ordenPago.Proveedor.Nombre;
        }

        public DateTime Fecha { get; set; }

        public bool Pagada { get; set; }

        public string Proveedor { get; set; }

        public int ObtenerId()
        {
            return id;
        }

        public IEnumerable<ItemOrdenPagoPresentacion> ObtenerItems()
        {
            return items;
        }

        public OrdenPago ObtenerOrdenPago()
        {
            return ordenPago;
        }
    }
}
