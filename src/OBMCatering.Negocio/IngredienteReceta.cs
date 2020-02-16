namespace OBMCatering.Negocio
{
    /// <summary>
    /// Representa el ingrediente de una receta, es decir el componente y la cantidad para una receta especifica
    /// </summary>
    public class IngredienteReceta
    {
        /// <summary>
        /// Ingrediente involucrado en la receta
        /// </summary>
        public Ingrediente Ingrediente { get; set; }

        /// <summary>
        /// Cantidad necesaria del ingrediente
        /// </summary>
        public decimal Cantidad { get; set; }

        /// <summary>
        /// Unidad de medida del ingrediente para la receta
        /// </summary>
        public UnidadMedida Unidad { get; set; }
    }
}
