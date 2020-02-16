using OBMCatering.Negocio;

namespace OBMCatering.Presentacion
{
    /// <summary>
    /// Representacion de la clase <see cref="PrecioIngrediente"/> en la capa de presentacion
    /// La idea es aplanar los datos y sus tipos, de manera de poder consultarlos mejor 
    /// y tambien mostrarlos de manera mas simple en una grilla 
    /// </summary>
    public class PrecioIngredientePresentacion
    {
        PrecioIngrediente precioIngrediente;

        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="PrecioIngredientePresentacion"/>
        /// </summary>
        /// <param name="precioIngrediente">Precio de un ingrediente del sistema</param>
        public PrecioIngredientePresentacion(PrecioIngrediente precioIngrediente)
        {
            this.precioIngrediente = precioIngrediente;

            Ingrediente = precioIngrediente.Ingrediente.Nombre;

            if(precioIngrediente.Precio.HasValue)
            {
                Precio = precioIngrediente.Precio.Value.ToString("N2");
            }
            else
            {
                Precio = string.Empty;
            }

            Cantidad = precioIngrediente.Cantidad.ToString();
            Unidad = precioIngrediente.Unidad.ToString();
        }

        /// <summary>
        /// Ingrediente del listado de precios
        /// </summary>
        public string Ingrediente { get; set; }

        /// <summary>
        /// Precio asignado al ingrediente
        /// </summary>
        public string Precio { get; set; }

        /// <summary>
        /// Cantidad del ingrediente por la cual se estima ese precio
        /// </summary>
        public string Cantidad { get; set; }

        /// <summary>
        /// Unidad de medida del ingrediente para la cual se calcula su cantidad
        /// </summary>
        public string Unidad { get; set; }

        /// <summary>
        /// Obtiene la instancia de <see cref="PrecioIngrediente"/> de la capa de negocio asociada
        /// </summary>
        /// <returns>Precio del ingrediente asociado</returns>
        public PrecioIngrediente ObtenerPrecioIngrediente()
        {
            return precioIngrediente;
        }
    }
}
