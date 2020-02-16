using OBMCatering.Negocio;
using System;
using System.Collections.Generic;

namespace OBMCatering.Presentacion
{
    /// <summary>
    /// Representacion de la clase <see cref="OrdenCompra"/> en la capa de presentacion
    /// La idea es aplanar los datos y sus tipos, de manera de poder consultarlos mejor 
    /// y tambien mostrarlos de manera mas simple en una grilla 
    /// </summary>
    public class OrdenCompraPresentacion
    {
        OrdenCompra ordenCompra;
        int id;
        List<ItemOrdenCompraPresentacion> items;

        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="OrdenCompraPresentacion"/>
        /// </summary>
        /// <param name="ordenCompra">Orden de compra del sistema</param>
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

        /// <summary>
        /// Fecha de la orden de compra
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Cliente que realizo el pedido asociado a la orden de compra
        /// </summary>
        public string Cliente { get; set; }

        /// <summary>
        /// Estado de la orden de compra
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// Obtiene el identificador de la orden de compra
        /// </summary>
        /// <returns>Identificador de la orden de compra</returns>
        public int ObtenerId()
        {
            return id;
        }

        /// <summary>
        /// Obtiene los items de presentacion de la orden de compra
        /// </summary>
        /// <returns>Items de presentacion de la orden compra</returns>
        public IEnumerable<ItemOrdenCompraPresentacion> ObtenerItems()
        {
            return items;
        }

        /// <summary>
        /// Obtiene la instancia de <see cref="OrdenCompra"/> de la capa de negocio asociada
        /// </summary>
        /// <returns>Orden de compra asociada</returns>
        public OrdenCompra ObtenerOrdenCompra()
        {
            return ordenCompra;
        }
    }
}
