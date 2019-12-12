using OBMCatering.Negocio;
using System;

namespace OBMCatering.Presentacion
{
    public class ProveedorPresentacion
    {
        Proveedor proveedor;

        public ProveedorPresentacion(Proveedor proveedor)
        {
            this.proveedor = proveedor;

            CUIT = proveedor.CUIT;
            Nombre = proveedor.Nombre;
            Domicilio = proveedor.Domicilio;
            Localidad = proveedor.Localidad.Nombre;
            Provincia = proveedor.Localidad.Provincia.Nombre;
            CodigoPostal = proveedor.CodigoPostal;
            Telefono = proveedor.Telefono;
            Email = proveedor.Email;
            FechaAlta = proveedor.FechaAlta;
            FechaBaja = proveedor.FechaBaja;
        }

        public string CUIT { get; set; }

        public string Nombre { get; set; }

        public string Domicilio { get; set; }

        public string Localidad { get; set; }

        public string Provincia { get; set; }

        public string CodigoPostal { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public DateTime FechaAlta { get; set; }

        public DateTime? FechaBaja { get; set; }

        public Proveedor ObtenerProveedor()
        {
            return proveedor;
        }
    }
}
