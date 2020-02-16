using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OBMCatering.Datos
{
    /// <summary>
    /// Responsable de manejar las facturas dentro de la capa de acceso a datos del sistema
    /// </summary>
    public class FacturasDAL
    {
        OBMCateringEntities modelo;

        public FacturasDAL(OBMCateringEntities modelo)
        {
            this.modelo = modelo;
        }

        public void Crear(Factura factura)
        {
            modelo.Facturas.Add(factura);
        }

        public void Actualizar(Factura factura)
        {
            modelo.Facturas.Attach(factura);
            modelo.Entry(factura).State = EntityState.Modified;
        }

        public IEnumerable<Factura> Obtener()
        {
            return modelo.Facturas.ToList();
        }

        public IEnumerable<Factura> Obtener(bool cobradas)
        {
            List<Factura> facturas = new List<Factura>();

            foreach(Factura factura in modelo.Facturas)
            {
                if(factura.Cobrada == cobradas)
                {
                    facturas.Add(factura);
                }
            }

            return facturas;
        }

        public IEnumerable<Factura> Obtener(Cliente cliente)
        {
            List<Factura> facturas = new List<Factura>();

            foreach (Factura factura in modelo.Facturas)
            {
                if (factura.OrdenVenta.Cliente.CUIT == cliente.CUIT)
                {
                    facturas.Add(factura);
                }
            }

            return facturas;
        }

        public Factura Obtener(int id)
        {
            return modelo.Facturas.Find(id);
        }

        public Factura Obtener(OrdenVenta ordenVenta)
        {
            Factura resultado = null;

            foreach (Factura factura in modelo.Facturas)
            {
                if (factura.OrdenVenta.ID == ordenVenta.ID)
                {
                    resultado = factura;
                    break;
                }
            }

            return resultado;
        }
    }
}
