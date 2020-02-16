using OBMCatering.Negocio;

namespace OBMCatering.Presentacion
{
    /// <summary>
    /// Representacion de la clase <see cref="Receta"/> en la capa de presentacion
    /// La idea es aplanar los datos y sus tipos, de manera de poder consultarlos mejor 
    /// y tambien mostrarlos de manera mas simple en una grilla 
    /// </summary>
    public class RecetaPresentacion
    {
        Receta receta;

        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="RecetaPresentacion"/>
        /// </summary>
        /// <param name="receta">Receta del sistema</param>
        public RecetaPresentacion(Receta receta)
        {
            this.receta = receta;

            Nombre = receta.Nombre;
            Detalle = receta.Detalle;
            Estado = receta.Estado.ToString();
        }

        /// <summary>
        /// Nombre de la receta
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Detalle o informacion de la receta
        /// </summary>
        public string Detalle { get; set; }

        /// <summary>
        /// Estado de la receta
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// Obtiene la instancia de <see cref="Receta"/> de la capa de negocio asociada
        /// </summary>
        /// <returns>Receta asociada</returns>
        public Receta ObtenerReceta()
        {
            return receta;
        }
    }
}
