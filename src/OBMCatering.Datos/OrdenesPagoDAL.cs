using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OBMCatering.Datos
{
    /// <summary>
    /// Responsable de manejar las ordenes de pago dentro de la capa de acceso a datos del sistema
    /// </summary>
    public class OrdenesPagoDAL
    {
        OBMCateringEntities modelo;

        public OrdenesPagoDAL(OBMCateringEntities modelo)
        {
            this.modelo = modelo;
        }

        public void Crear(OrdenPago ordenPago)
        {
            modelo.OrdenesPago.Add(ordenPago);
        }

        public void Actualizar(OrdenPago ordenPago)
        {
            modelo.OrdenesPago.Attach(ordenPago);
            modelo.Entry(ordenPago).State = EntityState.Modified;
        }

        public IEnumerable<OrdenPago> Obtener()
        {
            return modelo.OrdenesPago.ToList();
        }

        public IEnumerable<OrdenPago> Obtener(bool pagadas)
        {
            List<OrdenPago> ordenesPago = new List<OrdenPago>();

            foreach(OrdenPago ordenPago in modelo.OrdenesPago)
            {
                if(ordenPago.Pagada == pagadas)
                {
                    ordenesPago.Add(ordenPago);
                }
            }

            return ordenesPago;
        }

        public IEnumerable<OrdenPago> Obtener(Proveedor proveedor)
        {
            List<OrdenPago> ordenesPago = new List<OrdenPago>();

            foreach (OrdenPago ordenPago in modelo.OrdenesPago)
            {
                if (ordenPago.Proveedor.CUIT == proveedor.CUIT)
                {
                    ordenesPago.Add(ordenPago);
                }
            }

            return ordenesPago;
        }

        public OrdenPago Obtener(int id)
        {
            return modelo.OrdenesPago.Find(id);
        }
    }
}
