using System;

namespace OBMCatering.Negocio
{
    /// <summary>
    /// Representa un empleado de la empresa dentro del sistema
    /// </summary>
    public class Empleado
    {
        /// <summary>
        /// CUIT del empleado
        /// </summary>
        public string CUIT { get; set; }

        /// <summary>
        /// Nombre completo del empleado
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Fecha de nacimiento del empleado
        /// </summary>
        public DateTime FechaNacimiento { get; set; }

        /// <summary>
        /// Domicilio del empleado
        /// </summary>
        public string Domicilio { get; set; }

        /// <summary>
        /// Localidad del empleado
        /// </summary>
        public Localidad Localidad { get; set; }

        /// <summary>
        /// Codigo Postal del empleado
        /// </summary>
        public string CodigoPostal { get; set; }

        /// <summary>
        /// Telefono del empleado
        /// </summary>
        public string Telefono { get; set; }

        /// <summary>
        /// Email del empleado
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Fecha de alta del empleado en el sistema
        /// </summary>
        public DateTime FechaAlta { get; set; }

        /// <summary>
        /// Fecha de baja del empleado en el sistema, es decir si el empleado fue desvinculado
        /// </summary>
        public DateTime? FechaBaja { get; set; }
    }
}
