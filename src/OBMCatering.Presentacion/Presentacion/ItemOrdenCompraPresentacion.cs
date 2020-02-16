using OBMCatering.Negocio;

namespace OBMCatering.Presentacion
{
    /// <summary>
    /// Representacion de la clase <see cref="ItemOrdenCompra"/> en la capa de presentacion
    /// La idea es aplanar los datos y sus tipos, de manera de poder consultarlos mejor 
    /// y tambien mostrarlos de manera mas simple en una grilla 
    /// </summary>
    public class ItemOrdenCompraPresentacion
    {
        int id;
        ItemOrdenCompra itemOrdenCompra;

        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="ItemOrdenCompraPresentacion"/>
        /// </summary>
        /// <param name="itemOrdenCompra">Item de una orden de compra del sistema</param>
        public ItemOrdenCompraPresentacion(ItemOrdenCompra itemOrdenCompra)
        {
            this.itemOrdenCompra = itemOrdenCompra;
            id = itemOrdenCompra.Id;

            Ingrediente = itemOrdenCompra.Ingrediente.Nombre;
            Cantidad = itemOrdenCompra.Cantidad.ToString();
            Unidad = itemOrdenCompra.Unidad.ToString();
        }

        /// <summary>
        /// Nombre del ingrediente del item de la orden de compra
        /// </summary>
        public string Ingrediente { get; set; }

        /// <summary>
        /// Cantidad del ingrediente del item de la orden de compra
        /// </summary>
        public string Cantidad { get; set; }

        /// <summary>
        /// Unidad de medida del ingrediente del item de la orden de compra
        /// </summary>
        public string Unidad { get; set; }

        /// <summary>
        /// Obtiene el identificador del item
        /// </summary>
        /// <returns>Identificador del item</returns>
        public int ObtenerId()
        {
            return id;
        }

        /// <summary>
        /// Obtiene la instancia de <see cref="ItemOrdenCompra"/> de la capa de negocio asociada
        /// </summary>
        /// <returns>Item de la orden compra asociado</returns>
        public ItemOrdenCompra ObtenerItemOrdenCompra()
        {
            return itemOrdenCompra;
        }
    }
}
