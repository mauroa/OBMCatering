using OBMCatering.Negocio;

namespace OBMCatering.Presentacion
{
    /// <summary>
    /// Representacion de la clase <see cref="ItemOrdenPago"/> en la capa de presentacion
    /// La idea es aplanar los datos y sus tipos, de manera de poder consultarlos mejor 
    /// y tambien mostrarlos de manera mas simple en una grilla 
    /// </summary>
    public class ItemOrdenPagoPresentacion
    {
        int id;
        ItemOrdenPago itemOrdenPago;

        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="ItemOrdenPagoPresentacion"/>
        /// </summary>
        /// <param name="itemOrdenPago">Item de una orden de pago del sistema</param>
        public ItemOrdenPagoPresentacion(ItemOrdenPago itemOrdenPago)
        {
            this.itemOrdenPago = itemOrdenPago;
            id = itemOrdenPago.Id;

            Ingrediente = itemOrdenPago.ItemOrdenCompra.Ingrediente.Nombre;
            Cantidad = itemOrdenPago.ItemOrdenCompra.Cantidad.ToString();
            Unidad = itemOrdenPago.ItemOrdenCompra.Unidad.ToString();
            Precio = itemOrdenPago.Precio.ToString();
        }

        /// <summary>
        /// Nombre del ingrediente del item de la orden de pago
        /// </summary>
        public string Ingrediente { get; set; }

        /// <summary>
        /// Cantidad del ingrediente del item de la orden de pago
        /// </summary>
        public string Cantidad { get; set; }

        /// <summary>
        /// Unidad de medida del ingrediente del item de la orden de pago
        /// </summary>
        public string Unidad { get; set; }

        /// <summary>
        /// Precio del item de la orden de pago
        /// </summary>
        public string Precio { get; set; }

        /// <summary>
        /// Obtiene el identificador del item
        /// </summary>
        /// <returns>Identificador del item</returns>
        public int ObtenerId()
        {
            return id;
        }

        /// <summary>
        /// Obtiene la instancia de <see cref="ItemOrdenPago"/> de la capa de negocio asociada
        /// </summary>
        /// <returns>Item de la orden pago asociado</returns>
        public ItemOrdenPago ObtenerItemOrdenPago()
        {
            return itemOrdenPago;
        }
    }
}
