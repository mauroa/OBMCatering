using OBMCatering.Negocio;

namespace OBMCatering.Presentacion
{
    /// <summary>
    /// Representacion de la clase <see cref="IngredienteReceta"/> en la capa de presentacion
    /// La idea es aplanar los datos y sus tipos, de manera de poder consultarlos mejor 
    /// y tambien mostrarlos de manera mas simple en una grilla 
    /// </summary>
    public class IngredientePresentacion
    {
        IngredienteReceta ingrediente;

        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="IngredientePresentacion"/>
        /// </summary>
        /// <param name="ingrediente">Ingrediente de una receta del sistema</param>
        public IngredientePresentacion(IngredienteReceta ingrediente)
        {
            this.ingrediente = ingrediente;

            Nombre = ingrediente.Ingrediente.Nombre;
            Cantidad = ingrediente.Cantidad.ToString();
            Unidad = ingrediente.Unidad.ToString();
        }

        /// <summary>
        /// Nombre del ingrediente
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Cantidad del ingrediente para la receta asociada
        /// </summary>
        public string Cantidad { get; set; }

        /// <summary>
        /// Unidad de medida del ingrediente para la receta asociadas
        /// </summary>
        public string Unidad { get; set; }

        /// <summary>
        /// Obtiene la instancia de <see cref="IngredienteReceta"/> de la capa de negocio asociada
        /// </summary>
        /// <returns>Ingrediente de la receta asociado</returns>
        public IngredienteReceta ObtenerIngrediente()
        {
            return ingrediente;
        }
    }
}
