namespace OBMCatering.Negocio
{
    /// <summary>
    /// Representa un item dentro de una orden de pago directamente relacionado con un item de una orden de compra
    /// Como por cada orden de pago hay una orden de compra, los items estan relacionados tambien
    /// El item de la orden de pago ademas contiene el precio a pagar por el item, que sale de la cantidad del ingrediente y el precio del ingrediente
    /// </summary>
    public class ItemOrdenPago
    {
        /// <summary>
        /// Identificador del item de la orden de pago
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Item de la orden de compra relacionada
        /// </summary>
        public ItemOrdenCompra ItemOrdenCompra { get; set; }

        /// <summary>
        /// Precio a pagar por el item de la orden de compra
        /// </summary>
        public decimal Precio { get; set; }
    }
}
