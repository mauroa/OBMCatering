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
            ValidarCliente(cliente);

            Datos.LocalidadesDAL dalLocalidades = dal.ObtenerLocalidadesDAL();
            Datos.Localidad localidadDAL = dalLocalidades.Obtener(cliente.Localidad.Id);

            if(localidadDAL == null)
            {
                throw new OBMCateringException(string.Format("La localidad '{0}' es incorrecta o no es valida en el sistema", cliente.Localidad.Nombre));
            }

            Datos.ClientesDAL dalClientes = dal.ObtenerClientesDAL();
            Datos.TipoCliente tipoClienteDAL = dalClientes.ObtenerTipo(cliente.Tipo.ToString());

            if (tipoClienteDAL == null)
            {
                throw new OBMCateringException(string.Format("El tipo '{0}' es incorrecto o no es valido en el sistema", cliente.Tipo));
            }

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
            ValidarCliente(cliente);

            Datos.ClientesDAL dalClientes = dal.ObtenerClientesDAL();
            Datos.Cliente clienteDAL = dalClientes.Obtener(cliente.CUIT);

            if (clienteDAL == null)
            {
                throw new OBMCateringException(string.Format("El cliente con CUIT '{0}' no existe", cliente.CUIT));
            }

            Datos.LocalidadesDAL dalLocalidades = dal.ObtenerLocalidadesDAL();
            Datos.Localidad localidadDAL = dalLocalidades.Obtener(cliente.Localidad.Id);

            if (localidadDAL == null)
            {
                throw new OBMCateringException(string.Format("La localidad '{0}' es incorrecta o no es valida en el sistema", cliente.Localidad.Nombre));
            }

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
            ValidarCliente(cliente);

            Datos.ClientesDAL dalClientes = dal.ObtenerClientesDAL();
            Datos.Cliente clienteDAL = dalClientes.Obtener(cliente.CUIT);

            if (clienteDAL == null)
            {
                throw new OBMCateringException(string.Format("El cliente con CUIT '{0}' no existe", cliente.CUIT));
            }

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

            if (tipoClienteDAL == null)
            {
                throw new OBMCateringException(string.Format("El tipo '{0}' es incorrecto o no es valido en el sistema", tipo));
            }

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
            if (string.IsNullOrEmpty(cuit))
            {
                throw new OBMCateringException("El CUIT del cliente no puede ser nulo o vacio");
            }

            Datos.ClientesDAL dalClientes = dal.ObtenerClientesDAL();
            Datos.Cliente clienteDAL = dalClientes.Obtener(cuit);

            return clienteDAL != null;
        }

        public Cliente ObtenerPorCUIT(string cuit)
        {
            if (string.IsNullOrEmpty(cuit))
            {
                throw new OBMCateringException("El CUIT del cliente no puede ser nulo o vacio");
            }

            Datos.ClientesDAL dalClientes = dal.ObtenerClientesDAL();
            Datos.Cliente clienteDAL = dalClientes.Obtener(cuit);

            return Obtener(clienteDAL);
        }

        public Cliente ObtenerPorNombre(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new OBMCateringException("El nombre del cliente no puede ser nulo o vacio");
            }

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

        void ValidarCliente(Cliente cliente)
        {
            if(cliente == null)
            {
                throw new OBMCateringException("El cliente no puede ser nulo");
            }

            if (string.IsNullOrEmpty(cliente.CUIT))
            {
                throw new OBMCateringException("El CUIT del cliente no puede ser nulo o vacio");
            }

            if (string.IsNullOrEmpty(cliente.Nombre))
            {
                throw new OBMCateringException("El nombre del cliente no puede ser nulo o vacio");
            }

            if (string.IsNullOrEmpty(cliente.Domicilio))
            {
                throw new OBMCateringException("El domicilio del cliente no puede ser nulo o vacio");
            }

            if (cliente.Localidad == null)
            {
                throw new OBMCateringException("La localidad del cliente no puede ser nula");
            }

            if (string.IsNullOrEmpty(cliente.CodigoPostal))
            {
                throw new OBMCateringException("El codigo postal del cliente no puede ser nulo o vacio");
            }

            if (string.IsNullOrEmpty(cliente.Telefono))
            {
                throw new OBMCateringException("El telefono del cliente no puede ser nulo o vacio");
            }

            if (string.IsNullOrEmpty(cliente.Email))
            {
                throw new OBMCateringException("El email del cliente no puede ser nulo o vacio");
            }
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
