using System;
using System.Collections.Generic;

namespace OBMCatering.Negocio
{
    public class ClientesBL
    {
        Datos.OBMCateringDAL dal;
        LocalidadesBL localidadesBL;

        public ClientesBL(ContextoNegocio contexto, LocalidadesBL localidadesBL)
        {
            dal = contexto.ObtenerDatos();
            this.localidadesBL = localidadesBL;
        }

        public void Crear(Cliente cliente)
        {
            Datos.LocalidadesDAL dalLocalidades = dal.ObtenerLocalidadesDAL();
            Datos.Localidad localidadDAL = dalLocalidades.Obtener(cliente.Localidad.Id);
            Datos.ClientesDAL dalClientes = dal.ObtenerClientesDAL();
            Datos.TipoCliente tipoClienteDAL = dalClientes.ObtenerTipo(cliente.Tipo.ToString());
            Datos.Cliente clienteDAL = new Datos.Cliente
            {
                CUIT = cliente.CUIT,
                Nombre = cliente.Nombre,
                Domicilio = cliente.Domicilio,
                Localidad = localidadDAL,
                CodigoPostal = cliente.CodigoPostal,
                Telefono = cliente.Telefono,
                Email = cliente.Email,
                Tipo = tipoClienteDAL,
                FechaAlta = cliente.FechaAlta,
                Activo = cliente.Activo
            };

            dalClientes.Crear(clienteDAL);
            dal.Guardar();
        }

        public void Actualizar(Cliente cliente)
        {
            Datos.ClientesDAL dalClientes = dal.ObtenerClientesDAL();
            Datos.Cliente clienteDAL = dalClientes.Obtener(cliente.CUIT);
            Datos.LocalidadesDAL dalLocalidades = dal.ObtenerLocalidadesDAL();
            Datos.Localidad localidadDAL = dalLocalidades.Obtener(cliente.Localidad.Id);

            clienteDAL.Domicilio = cliente.Domicilio;
            clienteDAL.Localidad = localidadDAL;
            clienteDAL.CodigoPostal = cliente.CodigoPostal;
            clienteDAL.Telefono = cliente.Telefono;
            clienteDAL.Email = cliente.Email;
            clienteDAL.Activo = cliente.Activo;

            dalClientes.Actualizar(clienteDAL);
            dal.Guardar();
        }

        public void Eliminar(Cliente cliente)
        {
            Datos.ClientesDAL dalClientes = dal.ObtenerClientesDAL();
            Datos.Cliente clienteDAL = dalClientes.Obtener(cliente.CUIT);

            dalClientes.Eliminar(clienteDAL);
            dal.Guardar();
        }

        public IEnumerable<Cliente> Obtener()
        {
            Datos.ClientesDAL dalClientes = dal.ObtenerClientesDAL();
            IEnumerable<Datos.Cliente> clientesDAL = dalClientes.Obtener();

            return Obtener(clientesDAL);
        }

        public IEnumerable<Cliente> Obtener(TipoCliente tipo)
        {
            Datos.ClientesDAL dalClientes = dal.ObtenerClientesDAL();
            Datos.TipoCliente tipoClienteDAL = dalClientes.ObtenerTipo(tipo.ToString());
            IEnumerable<Datos.Cliente> clientesDAL = dalClientes.Obtener(tipoClienteDAL);

            return Obtener(clientesDAL);
        }

        public IEnumerable<Cliente> ObtenerActivos()
        {
            Datos.ClientesDAL dalClientes = dal.ObtenerClientesDAL();
            IEnumerable<Datos.Cliente> clientesDAL = dalClientes.Obtener(activos: true);

            return Obtener(clientesDAL);
        }

        public bool Existe(string cuit)
        {
            Datos.ClientesDAL dalClientes = dal.ObtenerClientesDAL();
            Datos.Cliente clienteDAL = dalClientes.Obtener(cuit);

            return clienteDAL != null;
        }

        public Cliente ObtenerPorCUIT(string cuit)
        {
            Datos.ClientesDAL dalClientes = dal.ObtenerClientesDAL();
            Datos.Cliente clienteDAL = dalClientes.Obtener(cuit);

            return Obtener(clienteDAL);
        }

        public Cliente ObtenerPorNombre(string nombre)
        {
            Datos.ClientesDAL dalClientes = dal.ObtenerClientesDAL();
            Datos.Cliente clienteDAL = dalClientes.ObtenerPorNombre(nombre);

            return Obtener(clienteDAL);
        }

        internal Cliente Obtener(Datos.Cliente clienteDAL)
        {
            Localidad localidad = localidadesBL.ObtenerLocalidad(clienteDAL.Localidad);
            TipoCliente tipo = (TipoCliente)Enum.Parse(typeof(TipoCliente), clienteDAL.Tipo.Tipo);

            return new Cliente
            {
                CUIT = clienteDAL.CUIT,
                Nombre = clienteDAL.Nombre,
                Domicilio = clienteDAL.Domicilio,
                Localidad = localidad,
                CodigoPostal = clienteDAL.CodigoPostal,
                Telefono = clienteDAL.Telefono,
                Email = clienteDAL.Email,
                Tipo = tipo,
                FechaAlta = clienteDAL.FechaAlta,
                Activo = clienteDAL.Activo
            };
        }

        IEnumerable<Cliente> Obtener(IEnumerable<Datos.Cliente> clientesDAL)
        {
            List<Cliente> clientes = new List<Cliente>();

            foreach (Datos.Cliente clienteDAL in clientesDAL)
            {
                Cliente cliente = Obtener(clienteDAL);

                clientes.Add(cliente);
            }

            return clientes;
        }
    }
}
