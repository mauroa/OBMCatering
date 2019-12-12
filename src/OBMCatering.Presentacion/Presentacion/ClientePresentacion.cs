using OBMCatering.Negocio;
using System;

namespace OBMCatering.Presentacion
{
    public class ClientePresentacion
    {
        Cliente cliente;

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

        public string CUIT { get; set; }

        public string Nombre { get; set; }

        public string Domicilio { get; set; }

        public string Localidad { get; set; }

        public string Provincia { get; set; }

        public string CodigoPostal { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

        public string Tipo { get; set; }

        public DateTime FechaAlta { get; set; }

        public bool Activo { get; set; }

        public Cliente ObtenerCliente()
        {
            return cliente;
        }
    }
}
