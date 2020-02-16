using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OBMCatering.Datos
{
    /// <summary>
    /// Responsable de manejar los proveedores dentro de la capa de acceso a datos del sistema
    /// </summary>
    public class ProveedoresDAL
    {
        OBMCateringEntities modelo;

        public ProveedoresDAL(OBMCateringEntities modelo)
        {
            this.modelo = modelo;
        }

        public void Crear(Proveedor proveedor)
        {
            modelo.Proveedores.Add(proveedor);
        }

        public void Actualizar(Proveedor proveedor)
        {
            modelo.Proveedores.Attach(proveedor);
            modelo.Entry(proveedor).State = EntityState.Modified;
        }

        public void Eliminar(Proveedor proveedor)
        {
            modelo.Proveedores.Remove(proveedor);
        }

        public IEnumerable<Proveedor> Obtener()
        {
            return modelo.Proveedores.ToList();
        }

        public IEnumerable<Proveedor> ObtenerActivos()
        {
            List<Proveedor> proveedores = new List<Proveedor>();

            foreach(Proveedor proveedor in modelo.Proveedores)
            {
                if(proveedor.FechaBaja == null)
                {
                    proveedores.Add(proveedor);
                }
            }

            return proveedores;
        }

        public Proveedor Obtener(string cuit)
        {
            return modelo.Proveedores.Find(cuit);
        }

        public Proveedor ObtenerPorNombre(string nombre)
        {
            Proveedor resultado = null;

            foreach(Proveedor proveedor in modelo.Proveedores)
            {
                if(proveedor.Nombre == nombre)
                {
                    resultado = proveedor;
                    break;
                }
            }

            return resultado;
        }
    }
}
