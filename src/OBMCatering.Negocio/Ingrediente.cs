namespace OBMCatering.Negocio
{
    /// <summary>
    /// Representa los ingredientes dentro del sistema. 
    /// Es la minima unidad que puede tener una receta y que conforma las recetas
    /// </summary>
    public class Ingrediente
    {
        /// <summary>
        /// Identificador del ingrediente
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del ingrediente
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Descripcion del ingrediente
        /// </summary>
        public string Descripcion { get; set; }
    }
}
