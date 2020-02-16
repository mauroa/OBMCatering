using System;
using System.Collections.Generic;

namespace OBMCatering.Negocio
{
    /// <summary>
    /// Representa una orden de compra de productos o ingredientes dentro del sistema
    /// </summary>
    public class OrdenCompra
    {
        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="OrdenCompra"/>
        /// </summary>
        public OrdenCompra()
        {
            Items = new List<ItemOrdenCompra>();
        }

        /// <summary>
        /// Identificador de la orden de compra
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Fecha en que se creo la orden de compra
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Estado actual de la orden de compra
        /// </summary>
        public EstadoOrdenCompra Estado { get; set; }

        /// <summary>
        /// Orden de venta o pedido asociado a la orden
        /// Por cada pedido se genera una orden de compra, con lo cual se relacionan en forma directa
        /// </summary>
        public OrdenVenta OrdenVenta { get; set; }

        /// <summary>
        /// Items que conforman la orden de compra
        /// </summary>
        public ICollection<ItemOrdenCompra> Items { get; set; }
    }
}
