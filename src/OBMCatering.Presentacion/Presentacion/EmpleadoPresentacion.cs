using OBMCatering.Negocio;
using System;

namespace OBMCatering.Presentacion
{
    /// <summary>
    /// Representacion de la clase <see cref="Empleado"/> en la capa de presentacion
    /// La idea es aplanar los datos y sus tipos, de manera de poder consultarlos mejor 
    /// y tambien mostrarlos de manera mas simple en una grilla 
    /// </summary>
    public class EmpleadoPresentacion
    {
        Empleado empleado;

        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="EmpleadoPresentacion"/>
        /// </summary>
        /// <param name="empleado">Empleado del sistema</param>
        public EmpleadoPresentacion(Empleado empleado)
        {
            this.empleado = empleado;

            CUIT = empleado.CUIT;
            Nombre = empleado.Nombre;
            FechaNacimiento = empleado.FechaNacimiento;
            Domicilio = empleado.Domicilio;
            Localidad = empleado.Localidad.Nombre;
            Provincia = empleado.Localidad.Provincia.Nombre;
            CodigoPostal = empleado.CodigoPostal;
            Telefono = empleado.Telefono;
            Email = empleado.Email;
            FechaAlta = empleado.FechaAlta;
            FechaBaja = empleado.FechaBaja;
        }

        /// <summary>
        /// CUIT del empleado
        /// </summary>
        public string CUIT { get; set; }

        /// <summary>
        /// Nombre del empleado
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
        public string Localidad { get; set; }

        /// <summary>
        /// Provincia del empleado
        /// </summary>
        public string Provincia { get; set; }

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
        /// Fecha de baja del empleado en el sistema
        /// </summary>
        public DateTime? FechaBaja { get; set; }

        /// <summary>
        /// Obtiene la instancia de <see cref="Empleado"/> de la capa de negocio asociada
        /// </summary>
        /// <returns>Empleado asociado</returns>
        public Empleado ObtenerEmpleado()
        {
            return empleado;
        }
    }
}
