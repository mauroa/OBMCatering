using OBMCatering.Negocio.Properties;
using System;
using System.Collections.Generic;

namespace OBMCatering.Negocio
{
    public class OrdenesCompraBL
    {
        Datos.OBMCateringDAL dal;
        OrdenesVentaBL ordenesVentaBL;
        IngredientesBL ingredientesBL;

        public OrdenesCompraBL(ContextoNegocio contexto, OrdenesVentaBL ordenesVentaBL, IngredientesBL ingredientesBL)
        {
            dal = contexto.ObtenerDatos();
            this.ordenesVentaBL = ordenesVentaBL;
            this.ingredientesBL = ingredientesBL;
        }

        public void Crear(OrdenVenta ordenVenta)
        {
            if(ordenVenta == null)
            {
                throw new OBMCateringException(Resources.BL_Validaciones_OrdenVentaNull);
            }

            if(ordenVenta.Comensales <= 0)
            {
                throw new OBMCateringException(Resources.BL_Validaciones_OrdenVentaSinComensales);
            }

            Datos.OrdenCompra ordenCompraDAL = new Datos.OrdenCompra();
            Dictionary<string, Datos.ItemOrdenCompra> itemsDALPorIngrediente = new Dictionary<string, Datos.ItemOrdenCompra>();

            foreach (Receta receta in ordenVenta.Recetas)
            {
                foreach (IngredienteReceta ingredienteReceta in receta.Ingredientes)
                {
                    Datos.ItemOrdenCompra itemOrdenCompraDAL;
                    Ingrediente ingrediente = ingredienteReceta.Ingrediente;

                    if (ingredienteReceta.Cantidad <= 0)
                    {
                        throw new OBMCateringException(string.Format(Resources.OrdenesCompraBL_Validaciones_RecetaSinIngredientes, ingrediente.Nombre, receta.Nombre));
                    }

                    decimal cantidad = ingredienteReceta.Cantidad * ordenVenta.Comensales;

                    if (itemsDALPorIngrediente.ContainsKey(ingrediente.Nombre))
                    {
                        itemOrdenCompraDAL = itemsDALPorIngrediente[ingrediente.Nombre];
                        itemOrdenCompraDAL.Cantidad = itemOrdenCompraDAL.Cantidad + cantidad;
                    }
                    else
                    {
                        itemOrdenCompraDAL = new Datos.ItemOrdenCompra();

                        Datos.IngredientesDAL dalIngredientes = dal.ObtenerIngredientesDAL();
                        Datos.Ingrediente ingredienteDAL = dalIngredientes.Obtener(ingrediente.Nombre);

                        if (ingredienteDAL == null)
                        {
                            throw new OBMCateringException(string.Format(Resources.OrdenesCompraBL_Validaciones_IngredienteInvalido, ingrediente.Nombre, receta.Nombre));
                        }

                        Datos.RecetasDAL dalRecetas = dal.ObtenerRecetasDAL();
                        Datos.UnidadMedida unidadDAL = dalRecetas.ObtenerUnidad(ingredienteReceta.Unidad.ToString());

                        if (unidadDAL == null)
                        {
                            throw new OBMCateringException(string.Format(Resources.BL_Validaciones_UnidadMedidaInvalida, ingredienteReceta.Unidad));
                        }

                        itemOrdenCompraDAL.Ingrediente = ingredienteDAL;
                        itemOrdenCompraDAL.Cantidad = cantidad;
                        itemOrdenCompraDAL.Unidad = unidadDAL;
                    }

                    itemsDALPorIngrediente[ingrediente.Nombre] = itemOrdenCompraDAL;
                }
            }

            Datos.OrdenesVentaDAL dalOrdenesVenta = dal.ObtenerOrdenesVentaDAL();
            Datos.OrdenVenta ordenVentaDAL = dalOrdenesVenta.Obtener(ordenVenta.Id);

            if (ordenVentaDAL == null)
            {
                throw new OBMCateringException(Resources.BL_Validaciones_OrdenVentaInvalida);
            }

            Datos.OrdenesCompraDAL dalOrdenesCompra = dal.ObtenerOrdenesCompraDAL();
            Datos.EstadoOrdenCompra estadoDAL = dalOrdenesCompra.ObtenerEstado(EstadoOrdenCompra.Generada.ToString());

            ordenCompraDAL.Fecha = DateTime.Now;
            ordenCompraDAL.Estado = estadoDAL;
            ordenCompraDAL.OrdenVenta = ordenVentaDAL;

            foreach (Datos.ItemOrdenCompra itemOrdenCompra in itemsDALPorIngrediente.Values)
            {
                ordenCompraDAL.ItemsOrdenesCompra.Add(itemOrdenCompra);
            }

            dalOrdenesCompra.Crear(ordenCompraDAL);
            dal.Guardar();
        }

        public void Actualizar(OrdenCompra ordenCompra)
        {
            ValidarOrdenCompra(ordenCompra);

            Datos.OrdenesCompraDAL dalOrdenesCompra = dal.ObtenerOrdenesCompraDAL();
            Datos.OrdenCompra ordenCompraDAL = dalOrdenesCompra.Obtener(ordenCompra.Id);

            if (ordenCompraDAL == null)
            {
                throw new OBMCateringException(Resources.BL_Validaciones_OrdenCompraInvalida);
            }

            Datos.EstadoOrdenCompra estadoDAL = dalOrdenesCompra.ObtenerEstado(ordenCompra.Estado.ToString());

            if (estadoDAL == null)
            {
                throw new OBMCateringException(string.Format(Resources.OrdenesCompraBL_Validaciones_EstadoInvalido, ordenCompra.Estado));
            }

            ordenCompraDAL.Estado = estadoDAL;

            dalOrdenesCompra.Actualizar(ordenCompraDAL);
            dal.Guardar();
        }

        public IEnumerable<OrdenCompra> Obtener()
        {
            Datos.OrdenesCompraDAL dalOrdenesCompra = dal.ObtenerOrdenesCompraDAL();
            IEnumerable<Datos.OrdenCompra> ordenesCompraDAL = dalOrdenesCompra.Obtener();

            return Obtener(ordenesCompraDAL);
        }

        public IEnumerable<OrdenCompra> Obtener(EstadoOrdenCompra estado)
        {
            Datos.OrdenesCompraDAL dalOrdenesCompra = dal.ObtenerOrdenesCompraDAL();
            Datos.EstadoOrdenCompra estadoDAL = dalOrdenesCompra.ObtenerEstado(estado.ToString());

            if (estadoDAL == null)
            {
                throw new OBMCateringException(string.Format(Resources.OrdenesCompraBL_Validaciones_EstadoInvalido, estado));
            }

            IEnumerable<Datos.OrdenCompra> ordenesCompraDAL = dalOrdenesCompra.Obtener(estadoDAL);

            return Obtener(ordenesCompraDAL);
        }

        public OrdenCompra Obtener(int id)
        {
            Datos.OrdenesCompraDAL dalOrdenesCompra = dal.ObtenerOrdenesCompraDAL();
            Datos.OrdenCompra ordenCompraDAL = dalOrdenesCompra.Obtener(id);

            return Obtener(ordenCompraDAL);
        }

        internal OrdenCompra Obtener(Datos.OrdenCompra ordenCompraDAL)
        {
            List<ItemOrdenCompra> items = new List<ItemOrdenCompra>();

            foreach (Datos.ItemOrdenCompra itemDAL in ordenCompraDAL.ItemsOrdenesCompra)
            {
                ItemOrdenCompra item = ObtenerItem(itemDAL);

                items.Add(item);
            }

            OrdenVenta ordenVenta = ordenesVentaBL.Obtener(ordenCompraDAL.OrdenVenta);
            EstadoOrdenCompra estado = (EstadoOrdenCompra)Enum.Parse(typeof(EstadoOrdenCompra), ordenCompraDAL.Estado.Estado);

            return new OrdenCompra
            {
                Id = ordenCompraDAL.ID,
                Fecha = ordenCompraDAL.Fecha,
                Estado = estado,
                OrdenVenta = ordenVenta,
                Items = items
            };
        }

        internal ItemOrdenCompra ObtenerItem(Datos.ItemOrdenCompra itemDAL)
        {
            Ingrediente ingrediente = ingredientesBL.Obtener(itemDAL.Ingrediente);
            UnidadMedida unidad = (UnidadMedida)Enum.Parse(typeof(UnidadMedida), itemDAL.Unidad.Unidad);
            ItemOrdenCompra item = new ItemOrdenCompra
            {
                Id = itemDAL.ID,
                Ingrediente = ingrediente,
                Cantidad = itemDAL.Cantidad,
                Unidad = unidad
            };

            return item;
        }

        void ValidarOrdenCompra(OrdenCompra ordenCompra)
        {
            if (ordenCompra == null)
            {
                throw new OBMCateringException(Resources.BL_Validaciones_OrdenCompraNull);
            }

            if (ordenCompra.OrdenVenta == null)
            {
                throw new OBMCateringException(Resources.OrdenesCompraBL_Validaciones_OrdenVentaNull);
            }

            if (ordenCompra.Items == null || ordenCompra.Items.Count == 0)
            {
                throw new OBMCateringException(Resources.OrdenesCompraBL_Validaciones_OrdenCompraSinItems);
            }
        }

        IEnumerable<OrdenCompra> Obtener(IEnumerable<Datos.OrdenCompra> ordenesCompraDAL)
        {
            List<OrdenCompra> ordenesCompra = new List<OrdenCompra>();

            foreach (Datos.OrdenCompra ordenCompraDAL in ordenesCompraDAL)
            {
                OrdenCompra ordenCompra = Obtener(ordenCompraDAL);

                ordenesCompra.Add(ordenCompra);
            }

            return ordenesCompra;
        }
    }
}
