using OBMCatering.Negocio.Properties;
using System.Collections.Generic;

namespace OBMCatering.Negocio
{
    public class OrdenesVentaBL
    {
        Datos.OBMCateringDAL dal;
        RecetasBL recetasBL;
        ClientesBL clientesBL;

        public OrdenesVentaBL(ContextoNegocio contexto, RecetasBL recetasBL, ClientesBL clientesBL)
        {
            dal = contexto.ObtenerDatos();
            this.recetasBL = recetasBL;
            this.clientesBL = clientesBL;
        }

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

        public IEnumerable<OrdenVenta> Obtener()
        {
            Datos.OrdenesVentaDAL dalOrdenesVenta = dal.ObtenerOrdenesVentaDAL();
            IEnumerable<Datos.OrdenVenta> ordenesVentaDAL = dalOrdenesVenta.Obtener();

            return Obtener(ordenesVentaDAL);
        }

        public IEnumerable<OrdenVenta> Obtener(bool aprobadas)
        {
            Datos.OrdenesVentaDAL dalOrdenesVenta = dal.ObtenerOrdenesVentaDAL();
            IEnumerable<Datos.OrdenVenta> ordenesVentaDAL = dalOrdenesVenta.Obtener(aprobadas);

            return Obtener(ordenesVentaDAL);
        }

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

        public IEnumerable<OrdenVenta> Obtener(Receta receta)
        {
            if (receta == null)
            {
                throw new OBMCateringException(Resources.BL_Validaciones_RecetaNull);
            }

            Datos.RecetasDAL dalRecetas = dal.ObtenerRecetasDAL();
            Datos.Receta recetaDAL = dalRecetas.Obtener(receta.Id);

            if (recetaDAL == null)
            {
                throw new OBMCateringException(string.Format(Resources.BL_Validaciones_RecetaInvalida, receta.Nombre));
            }

            Datos.OrdenesVentaDAL dalOrdenesVenta = dal.ObtenerOrdenesVentaDAL();
            IEnumerable<Datos.OrdenVenta> ordenesVentaDAL = dalOrdenesVenta.Obtener(recetaDAL);

            return Obtener(ordenesVentaDAL);
        }

        public OrdenVenta Obtener(int id)
        {
            Datos.OrdenesVentaDAL dalOrdenesVenta = dal.ObtenerOrdenesVentaDAL();
            Datos.OrdenVenta ordenVentaDAL = dalOrdenesVenta.Obtener(id);

            return Obtener(ordenVentaDAL);
        }

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
