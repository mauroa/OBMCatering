namespace OBMCatering.Negocio
{
    /// <summary>
    /// Representa a una localidad dentro del sistema
    /// </summary>
    public class Localidad
    {
        /// <summary>
        /// Identificador de la localidad
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Nombre de la localidad
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Provincia a la cual pertenece la localidad
        /// </summary>
        public Provincia Provincia { get; set; }
    }
}
