using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OBMCatering.Datos
{
    public class ClientesDAL
    {
        OBMCateringEntities modelo;

        public ClientesDAL(OBMCateringEntities modelo)
        {
            this.modelo = modelo;
        }

        public void Crear(Cliente cliente)
        {
            modelo.Clientes.Add(cliente);
        }

        public void Actualizar(Cliente cliente)
        {
            modelo.Clientes.Attach(cliente);
            modelo.Entry(cliente).State = EntityState.Modified;
        }

        public void Eliminar(Cliente cliente)
        {
            modelo.Clientes.Remove(cliente);
        }

        public IEnumerable<Cliente> Obtener()
        {
            return modelo.Clientes.ToList();
        }

        public IEnumerable<Cliente> Obtener(bool activos)
        {
            List<Cliente> clientes = new List<Cliente>();

            foreach(Cliente cliente in modelo.Clientes)
            {
                if(cliente.Activo == activos)
                {
                    clientes.Add(cliente);
                }
            }

            return clientes;
        }

        public IEnumerable<Cliente> Obtener(TipoCliente tipo)
        {
            List<Cliente> clientes = new List<Cliente>();

            foreach (Cliente cliente in modelo.Clientes)
            {
                if (cliente.Tipo.Tipo == tipo.Tipo)
                {
                    clientes.Add(cliente);
                }
            }

            return clientes;
        }

        public Cliente Obtener(string cuit)
        {
            return modelo.Clientes.Find(cuit);
        }

        public Cliente ObtenerPorNombre(string nombre)
        {
            Cliente resultado = null;

            foreach (Cliente cliente in modelo.Clientes)
            {
                if (cliente.Nombre == nombre)
                {
                    resultado = cliente;
                    break;
                }
            }

            return resultado;
        }

        public TipoCliente ObtenerTipo(string tipo)
        {
            TipoCliente resultado = null;

            foreach (TipoCliente tipoCliente in modelo.TiposClientes)
            {
                if (tipoCliente.Tipo == tipo)
                {
                    resultado = tipoCliente;
                    break;
                }
            }

            return resultado;
        }
    }
}
