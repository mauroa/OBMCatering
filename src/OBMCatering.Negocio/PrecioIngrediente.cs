namespace OBMCatering.Negocio
{
    /// <summary>
    /// Representa una unidad de precio asociada a un ingrediente dado
    /// Son utiles para conformar el listado de precios del sistema
    /// </summary>
    public class PrecioIngrediente
    {
        /// <summary>
        /// Identificador de la unidad de precio
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ingrediente asociado a la unidad de precio
        /// </summary>
        public Ingrediente Ingrediente { get; set; }

        /// <summary>
        /// Precio correspondiente al ingrediente en cuestion segun cantidad y unidad de medida
        /// </summary>
        public decimal? Precio { get; set; }

        /// <summary>
        /// Cantidad del ingrediente asociado a la unidad de precio
        /// </summary>
        public decimal? Cantidad { get; set; }

        /// <summary>
        /// Unidad de medida del ingrediente asociado a la unidad de precio
        /// </summary>
        public UnidadMedida Unidad { get; set; }
    }
}
