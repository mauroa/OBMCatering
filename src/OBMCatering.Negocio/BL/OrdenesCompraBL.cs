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
                throw new OBMCateringException("La orden de venta no puede ser nula");
            }

            if(ordenVenta.Comensales <= 0)
            {
                throw new OBMCateringException("La orden de venta debe tener al menos un comensal");
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
                        throw new OBMCateringException(string.Format("La cantidad del ingrediente '{0}' para la receta '{1}' tienen que ser mayor a cero", ingrediente.Nombre, receta.Nombre));
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
                            throw new OBMCateringException(string.Format("El ingredinte '{0}' es incorrecto o no es valido en el sistema para la receta '{1}'", ingrediente.Nombre, receta.Nombre));
                        }

                        Datos.RecetasDAL dalRecetas = dal.ObtenerRecetasDAL();
                        Datos.UnidadMedida unidadDAL = dalRecetas.ObtenerUnidad(ingredienteReceta.Unidad.ToString());

                        if (unidadDAL == null)
                        {
                            throw new OBMCateringException(string.Format("La unidad '{0}' es incorrecta o no es valida en el sistema", ingredienteReceta.Unidad));
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
                throw new OBMCateringException("La orden de venta es incorrecta o no es valida en el sistema");
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
                throw new OBMCateringException("La orden de compra es incorrecta o no es valida en el sistema");
            }

            Datos.EstadoOrdenCompra estadoDAL = dalOrdenesCompra.ObtenerEstado(ordenCompra.Estado.ToString());

            if (estadoDAL == null)
            {
                throw new OBMCateringException(string.Format("El estado '{0}' es incorrecto o no es valido en el sistema", ordenCompra.Estado));
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
                throw new OBMCateringException(string.Format("El estado '{0}' es incorrecto o no es valido en el sistema", estado));
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
                throw new OBMCateringException("La orden de compra no puede ser nula");
            }

            if (ordenCompra.OrdenVenta == null)
            {
                throw new OBMCateringException("La orden de venta asociada a la orden de compra no puede ser nula");
            }

            if (ordenCompra.Items == null || ordenCompra.Items.Count == 0)
            {
                throw new OBMCateringException("La orden de compra debe tener al menos un item");
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
