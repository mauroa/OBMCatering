using OBMCatering.Negocio;
using System;

namespace OBMCatering.Presentacion
{
    /// <summary>
    /// Representacion de la clase <see cref="Cliente"/> en la capa de presentacion
    /// La idea es aplanar los datos y sus tipos, de manera de poder consultarlos mejor 
    /// y tambien mostrarlos de manera mas simple en una grilla 
    /// </summary>
    public class ClientePresentacion
    {
        Cliente cliente;

        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="ClientePresentacion"/>
        /// </summary>
        /// <param name="cliente">Cliente del sistema</param>
        public ClientePresentacion(Cliente cliente)
        {
            this.cliente = cliente;

            CUIT = cliente.CUIT;
            Nombre = cliente.Nombre;
            Domicilio = cliente.Domicilio;
            Localidad = cliente.Localidad.Nombre;
            Provincia = cliente.Localidad.Provincia.Nombre;
            CodigoPostal = cliente.CodigoPostal;
            Telefono = cliente.Telefono;
            Email = cliente.Email;
            Tipo = cliente.Tipo.ToString();
            FechaAlta = cliente.FechaAlta;
            Activo = cliente.Activo;
        }

        /// <summary>
        /// CUIT del cliente
        /// </summary>
        public string CUIT { get; set; }

        /// <summary>
        /// Nombre del cliente
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Domicilio del cliente
        /// </summary>
        public string Domicilio { get; set; }

        /// <summary>
        /// Localidad del cliente
        /// </summary>
        public string Localidad { get; set; }

        /// <summary>
        /// Provincia del cliente
        /// </summary>
        public string Provincia { get; set; }

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
        public string Tipo { get; set; }

        /// <summary>
        /// Fecha de alta del cliente en el sistema
        /// </summary>
        public DateTime FechaAlta { get; set; }

        /// <summary>
        /// Valor que indica si el cliente esta activo en el sistema o no
        /// </summary>
        public bool Activo { get; set; }

        /// <summary>
        /// Obtiene la instancia de <see cref="Cliente"/> de la capa de negocio asociada
        /// </summary>
        /// <returns>Cliente asociado</returns>
        public Cliente ObtenerCliente()
        {
            return cliente;
        }
    }
}
