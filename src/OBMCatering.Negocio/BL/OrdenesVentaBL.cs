using OBMCatering.Negocio.Properties;
using System.Collections.Generic;

namespace OBMCatering.Negocio
{
    /// <summary>
    /// Reponsable de manejar las ordenes de venta del sistema dentro de la capa de negocio del mismo
    /// </summary>
    public class OrdenesVentaBL
    {
        Datos.OBMCateringDAL dal;
        RecetasBL recetasBL;
        ClientesBL clientesBL;

        /// <summary>
        /// Crea una nueva instancia de <see cref="OrdenesVentaBL"/>
        /// </summary>
        /// <param name="contexto">Contexto de negocio</param>
        /// <param name="recetasBL">Capa de negocio de recetas</param>
        /// <param name="clientesBL">Capa de negocio de clientes</param>
        public OrdenesVentaBL(ContextoNegocio contexto, RecetasBL recetasBL, ClientesBL clientesBL)
        {
            dal = contexto.ObtenerDatos();
            this.recetasBL = recetasBL;
            this.clientesBL = clientesBL;
        }

        /// <summary>
        /// Crea una nueva orden de venta o pedido en el sistema
        /// Las ordenes de venta son la informacion central del sistema ya que a partir de ellas se mueve el negocio,
        /// se preparan recetas, se generan ordenes de compra, facturas, ordenes de pago, etc.
        /// </summary>
        /// <param name="ordenVenta">Orden de venta a crear</param>
        public void Crear(OrdenVenta ordenVenta)
        {
            ValidarOrdenVenta(ordenVenta);

            Datos.ClientesDAL dalClientes = dal.ObtenerClientesDAL();
            Datos.Cliente clienteDAL = dalClientes.Obtener(ordenVenta.Cliente.CUIT);

            if (clienteDAL == null)
            {
                throw new OBMCateringException(string.Format(Resources.BL_Validaciones_ClienteInvalido, ordenVenta.Cliente.CUIT));
            }

            Datos.RecetasDAL dalRecetas = dal.ObtenerRecetasDAL();
            List<Datos.Receta> recetasDAL = new List<Datos.Receta>();

            foreach(Receta receta in ordenVenta.Recetas)
            {
                Datos.Receta recetaDAL = dalRecetas.Obtener(receta.Id);

                if (recetaDAL == null)
                {
                    throw new OBMCateringException(string.Format(Resources.OrdenesVentaBL_Validaciones_RecetaInvalida, receta.Nombre));
                }

                recetasDAL.Add(recetaDAL);
            }

            Datos.OrdenVenta ordenVentaDAL = new Datos.OrdenVenta
            {
                FechaInicio = ordenVenta.FechaInicio,
                FechaFin = ordenVenta.FechaFin,
                Comensales = ordenVenta.Comensales,
                Precio = ordenVenta.Precio,
                Aprobada = ordenVenta.Aprobada,
                Cliente = clienteDAL,
                Recetas = recetasDAL
            };

            Datos.OrdenesVentaDAL dalOrdenesVenta = dal.ObtenerOrdenesVentaDAL();

            dalOrdenesVenta.Crear(ordenVentaDAL);
            dal.Guardar();
        }

        /// <summary>
        /// Actualiza los datos de una determinada orden de venta o pedido
        /// Los datos que se permiten actualizar son los comensales, precio y si esta aprobada o no
        /// </summary>
        /// <param name="ordenVenta">Orden de venta a actualizar</param>
        public void Actualizar(OrdenVenta ordenVenta)
        {
            ValidarOrdenVenta(ordenVenta);

            Datos.OrdenesVentaDAL dalOrdenesVenta = dal.ObtenerOrdenesVentaDAL();
            Datos.OrdenVenta ordenVentaDAL = dalOrdenesVenta.Obtener(ordenVenta.Id);

            if (ordenVentaDAL == null)
            {
                throw new OBMCateringException(Resources.BL_Validaciones_OrdenVentaInvalida);
            }

            ordenVentaDAL.Comensales = ordenVenta.Comensales;
            ordenVentaDAL.Precio = ordenVenta.Precio;
            ordenVentaDAL.Aprobada = ordenVenta.Aprobada;

            dalOrdenesVenta.Actualizar(ordenVentaDAL);
            dal.Guardar();
        }

        /// <summary>
        /// Calcula el precio total de una orden de venta o pedido
        /// El precio se calcula mediante calcular el precio de cada receta incluida en la orden,
        /// multiplicandolo por la cantidad de comensales de la misma.
        /// A ese precio calculado se le agrega un porcentaje extra que representa la ganancia de la empresa
        /// </summary>
        /// <param name="ordenVenta">Orden de venta a calcular su precio</param>
        /// <returns>El precio total de la orden</returns>
        public decimal CalcularPrecio(OrdenVenta ordenVenta)
        {
            ValidarOrdenVenta(ordenVenta);

            decimal precio = 0m;

            foreach(Receta receta in ordenVenta.Recetas)
            {
                decimal precioReceta = recetasBL.CalularPrecio(receta);

                precio += precioReceta * ordenVenta.Comensales;
            }

            //Se suma un 25% de ganancia al precio calculado en base al precio actual de cada receta de la orden por la cantidad de comensales
            precio *= 1.25m;

            return precio;
        }

        /// <summary>
        /// Obtiene el listado completo de ordenes de venta del sistema
        /// </summary>
        /// <returns>Listado de ordenes de venta</returns>
        public IEnumerable<OrdenVenta> Obtener()
        {
            Datos.OrdenesVentaDAL dalOrdenesVenta = dal.ObtenerOrdenesVentaDAL();
            IEnumerable<Datos.OrdenVenta> ordenesVentaDAL = dalOrdenesVenta.Obtener();

            return Obtener(ordenesVentaDAL);
        }

        /// <summary>
        /// Obtiene el listado de ordenes de venta segun si ya fueron aprobadas o no
        /// </summary>
        /// <param name="aprobadas">Determina si se quiere consultar las ordenes de venta aprobadas o no aprobadas</param>
        /// <returns>Listado de ordenes de venta</returns>
        public IEnumerable<OrdenVenta> Obtener(bool aprobadas)
        {
            Datos.OrdenesVentaDAL dalOrdenesVenta = dal.ObtenerOrdenesVentaDAL();
            IEnumerable<Datos.OrdenVenta> ordenesVentaDAL = dalOrdenesVenta.Obtener(aprobadas);

            return Obtener(ordenesVentaDAL);
        }

        /// <summary>
        /// Obtiene el listado de ordenes de venta para un determinado cliente
        /// </summary>
        /// <param name="cliente">Cliente a obtener sus ordenes de venta</param>
        /// <returns>Listado de ordenes de venta</returns>
        public IEnumerable<OrdenVenta> Obtener(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new OBMCateringException(Resources.BL_Validaciones_ClienteNull);
            }

            Datos.ClientesDAL dalClientes = dal.ObtenerClientesDAL();
            Datos.Cliente clienteDAL = dalClientes.Obtener(cliente.CUIT);

            if (clienteDAL == null)
            {
                throw new OBMCateringException(string.Format(Resources.BL_Validaciones_ClienteInvalido, cliente.CUIT));
            }

            Datos.OrdenesVentaDAL dalOrdenesVenta = dal.ObtenerOrdenesVentaDAL();
            IEnumerable<Datos.OrdenVenta> ordenesVentaDAL = dalOrdenesVenta.Obtener(clienteDAL);

            return Obtener(ordenesVentaDAL);
        }

        /// <summary>
        /// Obtiene una orden de venta determinada segun su identificador
        /// </summary>
        /// <param name="id">Identificador de la orden de venta</param>
        /// <returns>Orden de venta encontrada</returns>
        public OrdenVenta Obtener(int id)
        {
            Datos.OrdenesVentaDAL dalOrdenesVenta = dal.ObtenerOrdenesVentaDAL();
            Datos.OrdenVenta ordenVentaDAL = dalOrdenesVenta.Obtener(id);

            return Obtener(ordenVentaDAL);
        }

        /// <summary>
        /// Determina si una orden de venta existe, buscandola por su identificador
        /// </summary>
        /// <param name="id">Identificador de la orden de venta</param>
        /// <returns>Valor que indica si la orden existe o no</returns>
        public bool Existe(int id)
        {
            Datos.OrdenesVentaDAL dalOrdenesVenta = dal.ObtenerOrdenesVentaDAL();
            Datos.OrdenVenta ordenVentaDAL = dalOrdenesVenta.Obtener(id);

            return ordenVentaDAL != null;
        }

        internal OrdenVenta Obtener(Datos.OrdenVenta ordenVentaDAL)
        {
            List<Receta> recetas = new List<Receta>();

            foreach(Datos.Receta recetaDAL in ordenVentaDAL.Recetas)
            {
                Receta receta = recetasBL.Obtener(recetaDAL);

                recetas.Add(receta);
            }

            Cliente cliente = clientesBL.Obtener(ordenVentaDAL.Cliente);

            return new OrdenVenta
            {
                Id = ordenVentaDAL.ID,
                FechaInicio = ordenVentaDAL.FechaInicio,
                FechaFin = ordenVentaDAL.FechaFin,
                Comensales = ordenVentaDAL.Comensales,
                Precio = ordenVentaDAL.Precio,
                Aprobada = ordenVentaDAL.Aprobada,
                Cliente = cliente,
                Recetas = recetas
            };
        }

        void ValidarOrdenVenta(OrdenVenta ordenVenta)
        {
            if (ordenVenta == null)
            {
                throw new OBMCateringException(Resources.BL_Validaciones_OrdenVentaNull);
            }

            if (ordenVenta.Cliente == null)
            {
                throw new OBMCateringException(Resources.BL_Validaciones_ClienteNull);
            }

            if (ordenVenta.Comensales <= 0)
            {
                throw new OBMCateringException(Resources.BL_Validaciones_OrdenVentaSinComensales);
            }

            if (ordenVenta.Recetas == null || ordenVenta.Recetas.Count == 0)
            {
                throw new OBMCateringException(Resources.BL_Validaciones_OrdenVentaSinRecetas);
            }
        }

        IEnumerable<OrdenVenta> Obtener(IEnumerable<Datos.OrdenVenta> ordenesVentaDAL)
        {
            List<OrdenVenta> ordenesVenta = new List<OrdenVenta>();

            foreach (Datos.OrdenVenta ordenVentaDAL in ordenesVentaDAL)
            {
                OrdenVenta ordenVenta = Obtener(ordenVentaDAL);

                ordenesVenta.Add(ordenVenta);
            }

            return ordenesVenta;
        }
    }
}
