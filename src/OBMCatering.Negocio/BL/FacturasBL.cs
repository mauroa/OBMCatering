using System.Collections.Generic;

namespace OBMCatering.Negocio
{
    public class FacturasBL
    {
        Datos.OBMCateringDAL dal;
        OrdenesVentaBL ordenesVentaBL;

        public FacturasBL(ContextoNegocio contexto, OrdenesVentaBL ordenesVentaBL)
        {
            dal = contexto.ObtenerDatos();
            this.ordenesVentaBL = ordenesVentaBL;
        }

        public void Crear(Factura factura)
        {
            ValidarFactura(factura);

            Datos.OrdenesVentaDAL dalOrdenesVenta = dal.ObtenerOrdenesVentaDAL();
            Datos.OrdenVenta ordenVentaDAL = dalOrdenesVenta.Obtener(factura.OrdenVenta.Id);

            if (ordenVentaDAL == null)
            {
                throw new OBMCateringException("La orden de venta asociada a la factura es incorrecta o no es valida en el sistema");
            }

            Datos.Factura facturaDAL = new Datos.Factura
            {
                Fecha = factura.Fecha,
                Cobrada = factura.Cobrada,
                OrdenVenta = ordenVentaDAL
            };

            Datos.FacturasDAL dalFacturas = dal.ObtenerFacturasDAL();

            dalFacturas.Crear(facturaDAL);
            dal.Guardar();
        }

        public void Actualizar(Factura factura)
        {
            ValidarFactura(factura);

            Datos.FacturasDAL dalFacturas = dal.ObtenerFacturasDAL();
            Datos.Factura facturaDAL = dalFacturas.Obtener(factura.Id);

            if (facturaDAL == null)
            {
                throw new OBMCateringException("La factura a actualizar no existe en el sistema");
            }

            facturaDAL.Cobrada = factura.Cobrada;

            dalFacturas.Actualizar(facturaDAL);
            dal.Guardar();
        }

        public IEnumerable<Factura> Obtener()
        {
            Datos.FacturasDAL dalFacturas = dal.ObtenerFacturasDAL();
            IEnumerable<Datos.Factura> facturasDAL = dalFacturas.Obtener();

            return Obtener(facturasDAL);
        }

        public IEnumerable<Factura> Obtener(bool cobradas)
        {
            Datos.FacturasDAL dalFacturas = dal.ObtenerFacturasDAL();
            IEnumerable<Datos.Factura> facturasDAL = dalFacturas.Obtener(cobradas);

            return Obtener(facturasDAL);
        }

        public IEnumerable<Factura> Obtener(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new OBMCateringException("El cliente no puede ser nulo");
            }

            Datos.ClientesDAL dalClientes = dal.ObtenerClientesDAL();
            Datos.Cliente clienteDAL = dalClientes.Obtener(cliente.CUIT);

            if (clienteDAL == null)
            {
                throw new OBMCateringException(string.Format("El cliente con CUIT '{0}' no existe", cliente.CUIT));
            }

            Datos.FacturasDAL dalFacturas = dal.ObtenerFacturasDAL();
            IEnumerable<Datos.Factura> facturasDAL = dalFacturas.Obtener(clienteDAL);

            return Obtener(facturasDAL);
        }

        public Factura Obtener(int id)
        {
            Datos.FacturasDAL dalFacturas = dal.ObtenerFacturasDAL();
            Datos.Factura facturaDAL = dalFacturas.Obtener(id);

            return Obtener(facturaDAL);
        }

        public Factura Obtener(OrdenVenta ordenVenta)
        {
            if (ordenVenta == null)
            {
                throw new OBMCateringException("La orden de venta no puede ser nula");
            }

            Datos.OrdenesVentaDAL dalOrdenesVenta = dal.ObtenerOrdenesVentaDAL();
            Datos.OrdenVenta ordenVentaDAL = dalOrdenesVenta.Obtener(ordenVenta.Id);

            if (ordenVentaDAL == null)
            {
                throw new OBMCateringException("La orden de venta es incorrecta o no es valida en el sistema");
            }

            Datos.FacturasDAL dalFacturas = dal.ObtenerFacturasDAL();
            Datos.Factura facturaDAL = dalFacturas.Obtener(ordenVentaDAL);

           return Obtener(facturaDAL);
        }

        void ValidarFactura(Factura factura)
        {
            if (factura == null)
            {
                throw new OBMCateringException("La factura no puede ser nula");
            }

            if (factura.OrdenVenta == null)
            {
                throw new OBMCateringException("La orden de venta asociada a la factura no puede ser nula");
            }
        }

        IEnumerable<Factura> Obtener(IEnumerable<Datos.Factura> facturasDAL)
        {
            List<Factura> facturas = new List<Factura>();

            foreach (Datos.Factura facturaDAL in facturasDAL)
            {
                Factura factura = Obtener(facturaDAL);

                facturas.Add(factura);
            }

            return facturas;
        }

        Factura Obtener(Datos.Factura facturaDAL)
        {
            OrdenVenta ordenVenta = ordenesVentaBL.Obtener(facturaDAL.OrdenVenta);

            return new Factura
            {
                Id = facturaDAL.ID,
                Fecha = facturaDAL.Fecha,
                Cobrada = facturaDAL.Cobrada,
                OrdenVenta = ordenVenta
            };
        }
    }
}
