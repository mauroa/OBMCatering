using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OBMCatering.Datos
{
    public class OrdenesVentaDAL
    {
        OBMCateringEntities modelo;

        public OrdenesVentaDAL(OBMCateringEntities modelo)
        {
            this.modelo = modelo;
        }

        public void Crear(OrdenVenta ordenVenta)
        {
            modelo.OrdenesVenta.Add(ordenVenta);
        }

        public void Actualizar(OrdenVenta ordenVenta)
        {
            modelo.OrdenesVenta.Attach(ordenVenta);
            modelo.Entry(ordenVenta).State = EntityState.Modified;
        }

        public void Eliminar(OrdenVenta ordenVenta)
        {
            modelo.OrdenesVenta.Remove(ordenVenta);
        }

        public IEnumerable<OrdenVenta> Obtener()
        {
            return modelo.OrdenesVenta.ToList();
        }

        public IEnumerable<OrdenVenta> Obtener(bool aprobadas)
        {
            List<OrdenVenta> ordenesVentas = new List<OrdenVenta>();

            foreach (OrdenVenta ordenVenta in modelo.OrdenesVenta)
            {
                if (ordenVenta.Aprobada == aprobadas)
                {
                    ordenesVentas.Add(ordenVenta);
                }
            }

            return ordenesVentas;
        }

        public IEnumerable<OrdenVenta> Obtener(Cliente cliente)
        {
            List<OrdenVenta> ordenesVentas = new List<OrdenVenta>();

            foreach(OrdenVenta ordenVenta in modelo.OrdenesVenta)
            {
                if(ordenVenta.Cliente.CUIT == cliente.CUIT)
                {
                    ordenesVentas.Add(ordenVenta);
                }
            }

            return ordenesVentas;
        }

        public IEnumerable<OrdenVenta> Obtener(Receta receta)
        {
            List<OrdenVenta> ordenesVentas = new List<OrdenVenta>();

            foreach (OrdenVenta ordenVenta in modelo.OrdenesVenta)
            {
                foreach(Receta recetaOrdenVenta in ordenVenta.Recetas)
                {
                    if(recetaOrdenVenta.ID == receta.ID)
                    {
                        ordenesVentas.Add(ordenVenta);
                    }
                }
            }

            return ordenesVentas;
        }

        public OrdenVenta Obtener(int id)
        {
            return modelo.OrdenesVenta.Find(id);
        }
    }
}
