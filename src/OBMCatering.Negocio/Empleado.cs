using System;

namespace OBMCatering.Negocio
{
    public class Empleado
    {
        public string CUIT { get; set; }

        public string Nombre { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public string Domicilio { get; set; }

        public Localidad Localidad { get; set; }

        public string CodigoPostal { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public DateTime FechaAlta { get; set; }

        public DateTime? FechaBaja { get; set; }
    }
}
