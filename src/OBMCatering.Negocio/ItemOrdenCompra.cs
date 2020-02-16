namespace OBMCatering.Negocio
{
    /// <summary>
    /// Representa un item dentro de una orden de compra, es decir una cantidad y unidad especifica a comprar de un ingrediente en particular
    /// </summary>
    public class ItemOrdenCompra
    {
        /// <summary>
        /// Identificador del item
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ingrediente a comprar
        /// </summary>
        public Ingrediente Ingrediente { get; set; }
        
        /// <summary>
        /// Cantidad a comprar
        /// </summary>
        public decimal Cantidad { get; set; }

        /// <summary>
        /// Unidad de medida para la cantidad a comprar
        /// </summary>
        public UnidadMedida Unidad { get; set; }
    }
}
