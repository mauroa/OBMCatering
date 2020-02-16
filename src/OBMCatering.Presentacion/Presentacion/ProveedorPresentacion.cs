using OBMCatering.Negocio;
using System;

namespace OBMCatering.Presentacion
{
    /// <summary>
    /// Representacion de la clase <see cref="Proveedor"/> en la capa de presentacion
    /// La idea es aplanar los datos y sus tipos, de manera de poder consultarlos mejor 
    /// y tambien mostrarlos de manera mas simple en una grilla 
    /// </summary>
    public class ProveedorPresentacion
    {
        Proveedor proveedor;

        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="ProveedorPresentacion"/>
        /// </summary>
        /// <param name="proveedor">Proveedor del sistema</param>
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

        /// <summary>
        /// CUIT del proveedor
        /// </summary>
        public string CUIT { get; set; }

        /// <summary>
        /// Nombre del proveedor
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Domicilio del proveedor
        /// </summary>
        public string Domicilio { get; set; }

        /// <summary>
        /// Localidad del proveedor
        /// </summary>
        public string Localidad { get; set; }

        /// <summary>
        /// Provincia del proveedor
        /// </summary>
        public string Provincia { get; set; }

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
        /// Fecha de baja del proveedor en el sistema
        /// </summary>
        public DateTime? FechaBaja { get; set; }

        /// <summary>
        /// Obtiene la instancia de <see cref="Proveedor"/> de la capa de negocio asociada
        /// </summary>
        /// <returns>Proveedor asociado</returns>
        public Proveedor ObtenerProveedor()
        {
            return proveedor;
        }
    }
}
