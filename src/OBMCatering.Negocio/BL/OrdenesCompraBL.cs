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
            Datos.OrdenCompra ordenCompraDAL = new Datos.OrdenCompra();
            Dictionary<string, Datos.ItemOrdenCompra> itemsDALPorIngrediente = new Dictionary<string, Datos.ItemOrdenCompra>();

            foreach (Receta receta in ordenVenta.Recetas)
            {
                foreach (IngredienteReceta ingredienteReceta in receta.Ingredientes)
                {
                    Ingrediente ingrediente = ingredienteReceta.Ingrediente;
                    Datos.ItemOrdenCompra itemOrdenCompraDAL;

                    if (itemsDALPorIngrediente.ContainsKey(ingrediente.Nombre))
                    {
                        itemOrdenCompraDAL = itemsDALPorIngrediente[ingrediente.Nombre];
                        itemOrdenCompraDAL.Cantidad = itemOrdenCompraDAL.Cantidad + ingredienteReceta.Cantidad;
                    }
                    else
                    {
                        itemOrdenCompraDAL = new Datos.ItemOrdenCompra();

                        Datos.IngredientesDAL dalIngredientes = dal.ObtenerIngredientesDAL();
                        Datos.Ingrediente ingredienteDAL = dalIngredientes.Obtener(ingrediente.Nombre);
                        Datos.RecetasDAL dalRecetas = dal.ObtenerRecetasDAL();
                        Datos.UnidadMedida unidadDAL = dalRecetas.ObtenerUnidad(ingredienteReceta.Unidad.ToString());

                        itemOrdenCompraDAL.Ingrediente = ingredienteDAL;
                        itemOrdenCompraDAL.Cantidad = ingredienteReceta.Cantidad;
                        itemOrdenCompraDAL.Unidad = unidadDAL;
                    }

                    itemsDALPorIngrediente[ingrediente.Nombre] = itemOrdenCompraDAL;
                }
            }

            Datos.OrdenesVentaDAL dalOrdenesVenta = dal.ObtenerOrdenesVentaDAL();
            Datos.OrdenVenta ordenVentaDAL = dalOrdenesVenta.Obtener(ordenVenta.Id);

            ordenCompraDAL.Fecha = DateTime.Now;
            ordenCompraDAL.Ejecutada = false;
            ordenCompraDAL.OrdenVenta = ordenVentaDAL;

            foreach (Datos.ItemOrdenCompra itemOrdenCompra in itemsDALPorIngrediente.Values)
            {
                ordenCompraDAL.ItemsOrdenesCompra.Add(itemOrdenCompra);
            }

            Datos.OrdenesCompraDAL dalOrdenesCompra = dal.ObtenerOrdenesCompraDAL();

            dalOrdenesCompra.Crear(ordenCompraDAL);
            dal.Guardar();
        }

        public void Actualizar(OrdenCompra ordenCompra)
        {
            Datos.OrdenesCompraDAL dalOrdenesCompra = dal.ObtenerOrdenesCompraDAL();
            Datos.OrdenCompra ordenCompraDAL = dalOrdenesCompra.Obtener(ordenCompra.Id);

            ordenCompraDAL.Ejecutada = ordenCompra.Ejecutada;

            dalOrdenesCompra.Actualizar(ordenCompraDAL);
            dal.Guardar();
        }

        public IEnumerable<OrdenCompra> Obtener()
        {
            Datos.OrdenesCompraDAL dalOrdenesCompra = dal.ObtenerOrdenesCompraDAL();
            IEnumerable<Datos.OrdenCompra> ordenesCompraDAL = dalOrdenesCompra.Obtener();

            return Obtener(ordenesCompraDAL);
        }

        public IEnumerable<OrdenCompra> Obtener(bool ejecutadas)
        {
            Datos.OrdenesCompraDAL dalOrdenesCompra = dal.ObtenerOrdenesCompraDAL();
            IEnumerable<Datos.OrdenCompra> ordenesCompraDAL = dalOrdenesCompra.Obtener(ejecutadas);

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

            return new OrdenCompra
            {
                Id = ordenCompraDAL.ID,
                Fecha = ordenCompraDAL.Fecha,
                Ejecutada = ordenCompraDAL.Ejecutada,
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
