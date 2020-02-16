using System;

namespace OBMCatering.Negocio
{
    /// <summary>
    /// Representa un cliente dentro del sistema
    /// </summary>
    public class Cliente
    {
        /// <summary>
        /// CUIT del cliente
        /// </summary>
        public string CUIT { get; set; }

        /// <summary>
        /// Nombre completo del cliente
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Domicilio del cliente
        /// </summary>
        public string Domicilio { get; set; }

        /// <summary>
        /// Localidad del cliente
        /// </summary>
        public Localidad Localidad { get; set; }

        /// <summary>
        /// Codigo Postal del cliente
        /// </summary>
        public string CodigoPostal { get; set; }

        /// <summary>
        /// Telefono del cliente
        /// </summary>
        public string Telefono { get; set; }

        /// <summary>
        /// Email del cliente
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Tipo de cliente
        /// </summary>
        public TipoCliente Tipo { get; set; }

        /// <summary>
        /// Fecha de alta del cliente en el sistema
        /// </summary>
        public DateTime FechaAlta { get; set; }

        /// <summary>
        /// Indica si el cliente esta activo en el sistema, es decir si puede realizar pedidos
        /// </summary>
        public bool Activo { get; set; }
    }
}
