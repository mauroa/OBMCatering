using OBMCatering.Negocio;
using System;

namespace OBMCatering.Presentacion
{
    public class EmpleadoPresentacion
    {
        public EmpleadoPresentacion(Empleado empleado)
        {
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

        public string CUIT { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Domicilio { get; set; }

        public string Localidad { get; set; }

        public string Provincia { get; set; }

        public string CodigoPostal { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public DateTime FechaAlta { get; set; }

        public DateTime? FechaBaja { get; set; }
    }
}
