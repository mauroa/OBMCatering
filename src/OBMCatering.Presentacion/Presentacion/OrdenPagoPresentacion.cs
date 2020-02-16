using OBMCatering.Negocio;
using System;
using System.Collections.Generic;

namespace OBMCatering.Presentacion
{
    /// <summary>
    /// Representacion de la clase <see cref="OrdenPago"/> en la capa de presentacion
    /// La idea es aplanar los datos y sus tipos, de manera de poder consultarlos mejor 
    /// y tambien mostrarlos de manera mas simple en una grilla 
    /// </summary>
    public class OrdenPagoPresentacion
    {
        OrdenPago ordenPago;
        int id;
        List<ItemOrdenPagoPresentacion> items;

        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="OrdenPagoPresentacion"/>
        /// </summary>
        /// <param name="ordenPago">Orden de pago del sistema</param>
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

        /// <summary>
        /// Fecha de la orden de pago
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Indica si la orden fue pagada o no
        /// </summary>
        public bool Pagada { get; set; }

        /// <summary>
        /// Proveedor asociado a la orden de pago, es decir quien ha vendido la materia prima de la orden de compra asociada
        /// </summary>
        public string Proveedor { get; set; }

        /// <summary>
        /// Obtiene el identificador de la orden de pago
        /// </summary>
        /// <returns>Identificador de la orden de pago</returns>
        public int ObtenerId()
        {
            return id;
        }

        /// <summary>
        /// Obtiene los items de presentacion de la orden de pago
        /// </summary>
        /// <returns>Items de presentacion de la orden pago</returns>
        public IEnumerable<ItemOrdenPagoPresentacion> ObtenerItems()
        {
            return items;
        }

        /// <summary>
        /// Obtiene la instancia de <see cref="OrdenPago"/> de la capa de negocio asociada
        /// </summary>
        /// <returns>Orden de pago asociada</returns>
        public OrdenPago ObtenerOrdenPago()
        {
            return ordenPago;
        }
    }
}
