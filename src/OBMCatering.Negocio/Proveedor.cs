using System;

namespace OBMCatering.Negocio
{
    /// <summary>
    /// Representa un proveedor de materias primas dentro del sistema
    /// </summary>
    public class Proveedor
    {
        /// <summary>
        /// CUIT del proveedor
        /// </summary>
        public string CUIT { get; set; }

        /// <summary>
        /// Nombre completo del proveedor
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Domicilio del proveedor
        /// </summary>
        public string Domicilio { get; set; }

        /// <summary>
        /// Localidad del proveedor
        /// </summary>
        public Localidad Localidad { get; set; }

        /// <summary>
        /// Codigo Postal del proveedor
        /// </summary>
        public string CodigoPostal { get; set; }

        /// <summary>
        /// Telefono del proveedor
        /// </summary>
        public string Telefono { get; set; }

        /// <summary>
        /// Email del proveedor
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Fecha de alta del proveedor en el sistema
        /// </summary>
        public DateTime FechaAlta { get; set; }

        /// <summary>
        /// Fecha de baja del proveedor dentro del sistema
        /// </summary>
        public DateTime? FechaBaja { get; set; }
    }
}
