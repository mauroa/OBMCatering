using System.Collections.Generic;

namespace OBMCatering.Negocio
{
    /// <summary>
    /// Representa a una receta dentro del sistema
    /// </summary>
    public class Receta
    {
        /// <summary>
        /// Crea una nueva instancia de <see cref="Receta"/>
        /// </summary>
        public Receta()
        {
            Ingredientes = new List<IngredienteReceta>();
        }

        /// <summary>
        /// Identificador de la receta
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre de la receta
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Detalle y datos de la receta
        /// </summary>
        public string Detalle { get; set; }

        /// <summary>
        /// Estado actual de la receta en el sistema
        /// </summary>
        public EstadoReceta Estado { get; set; }

        /// <summary>
        /// Ingredientes que conforman la receta
        /// </summary>
        public ICollection<IngredienteReceta> Ingredientes { get; set; }
    }
}
