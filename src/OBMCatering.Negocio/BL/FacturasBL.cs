using OBMCatering.Negocio.Properties;
using System.Collections.Generic;

namespace OBMCatering.Negocio
{
    /// <summary>
    /// Reponsable de manejar las facturas del sistema dentro de la capa de negocio del mismo
    /// </summary>
    public class FacturasBL
    {
        Datos.OBMCateringDAL dal;
        OrdenesVentaBL ordenesVentaBL;

        /// <summary>
        /// Crea una nueva instancia de <see cref="FacturasBL"/>
        /// </summary>
        /// <param name="contexto">Contexto de negocio</param>
        /// <param name="ordenesVentaBL">Capa de negocio de ordenes de venta</param>
        public FacturasBL(ContextoNegocio contexto, OrdenesVentaBL ordenesVentaBL)
        {
            dal = contexto.ObtenerDatos();
            this.ordenesVentaBL = ordenesVentaBL;
        }

        /// <summary>
        /// Crea una nueva factura en el sistema, lo que implica que una determinada orden de venta ha sido aprobada
        /// Por cada orden de venta o pedido debera crearse una factura que la respalde
        /// </summary>
        /// <param name="factura">Factura a crear</param>
        public void Crear(Factura factura)
        {
            ValidarFactura(factura);

            Datos.OrdenesVentaDAL dalOrdenesVenta = dal.ObtenerOrdenesVentaDAL();
            Datos.OrdenVenta ordenVentaDAL = dalOrdenesVenta.Obtener(factura.OrdenVenta.Id);

            if (ordenVentaDAL == null)
            {
                throw new OBMCateringException(Resources.BL_Validaciones_OrdenVentaInvalida);
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

        /// <summary>
        /// Actualiza los datos de una determinada factura
        /// Solo se permite actualizar el estado de la factura, es decir si fue cobrada o no
        /// </summary>
        /// <param name="factura">Factura a actualizar</param>
        public void Actualizar(Factura factura)
        {
            ValidarFactura(factura);

            Datos.FacturasDAL dalFacturas = dal.ObtenerFacturasDAL();
            Datos.Factura facturaDAL = dalFacturas.Obtener(factura.Id);

            if (facturaDAL == null)
            {
                throw new OBMCateringException(Resources.FacturasBL_Validaciones_FacturaInvalida);
            }

            facturaDAL.Cobrada = factura.Cobrada;

            dalFacturas.Actualizar(facturaDAL);
            dal.Guardar();
        }

        /// <summary>
        /// Obtiene el listado completo de facturas del sistema
        /// </summary>
        /// <returns>Listado de facturas</returns>
        public IEnumerable<Factura> Obtener()
        {
            Datos.FacturasDAL dalFacturas = dal.ObtenerFacturasDAL();
            IEnumerable<Datos.Factura> facturasDAL = dalFacturas.Obtener();

            return Obtener(facturasDAL);
        }

        /// <summary>
        /// Obtiene el listado de facturas segun si fueron cobradas o no
        /// </summary>
        /// <param name="cobradas">Indica si se quiere obtener las facturas pagas o impagas</param>
        /// <returns>Listado de facturas</returns>
        public IEnumerable<Factura> Obtener(bool cobradas)
        {
            Datos.FacturasDAL dalFacturas = dal.ObtenerFacturasDAL();
            IEnumerable<Datos.Factura> facturasDAL = dalFacturas.Obtener(cobradas);

            return Obtener(facturasDAL);
        }

        /// <summary>
        /// Obtiene el listado de facturas de determinado cliente
        /// </summary>
        /// <param name="cliente">Cliente para consultar sus facturas</param>
        /// <returns>Listado de facturas del cliente</returns>
        public IEnumerable<Factura> Obtener(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new OBMCateringException(Resources.FacturasBL_Validaciones_ClienteNull);
            }

            Datos.ClientesDAL dalClientes = dal.ObtenerClientesDAL();
            Datos.Cliente clienteDAL = dalClientes.Obtener(cliente.CUIT);

            if (clienteDAL == null)
            {
                throw new OBMCateringException(string.Format(Resources.BL_Validaciones_ClienteInvalido, cliente.CUIT));
            }

            Datos.FacturasDAL dalFacturas = dal.ObtenerFacturasDAL();
            IEnumerable<Datos.Factura> facturasDAL = dalFacturas.Obtener(clienteDAL);

            return Obtener(facturasDAL);
        }

        /// <summary>
        /// Obtiene una factura determinada segun su identificador
        /// </summary>
        /// <param name="id">Identificador de la factura</param>
        /// <returns>Factura encontrada</returns>
        public Factura Obtener(int id)
        {
            Datos.FacturasDAL dalFacturas = dal.ObtenerFacturasDAL();
            Datos.Factura facturaDAL = dalFacturas.Obtener(id);

            return Obtener(facturaDAL);
        }

        /// <summary>
        /// Obtiene la factura asociada a determinado pedido u orden de venta
        /// </summary>
        /// <param name="ordenVenta">Orden de venta para buscar su factura</param>
        /// <returns>Factura encontrada</returns>
        public Factura Obtener(OrdenVenta ordenVenta)
        {
            if (ordenVenta == null)
            {
                throw new OBMCateringException(Resources.BL_Validaciones_OrdenVentaNull);
            }

            Datos.OrdenesVentaDAL dalOrdenesVenta = dal.ObtenerOrdenesVentaDAL();
            Datos.OrdenVenta ordenVentaDAL = dalOrdenesVenta.Obtener(ordenVenta.Id);

            if (ordenVentaDAL == null)
            {
                throw new OBMCateringException(Resources.BL_Validaciones_OrdenVentaInvalida);
            }

            Datos.FacturasDAL dalFacturas = dal.ObtenerFacturasDAL();
            Datos.Factura facturaDAL = dalFacturas.Obtener(ordenVentaDAL);

           return Obtener(facturaDAL);
        }

        void ValidarFactura(Factura factura)
        {
            if (factura == null)
            {
                throw new OBMCateringException(Resources.FacturasBL_Validaciones_FacturaNull);
            }

            if (factura.OrdenVenta == null)
            {
                throw new OBMCateringException(Resources.BL_Validaciones_OrdenVentaNull);
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
