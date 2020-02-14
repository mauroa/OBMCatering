using OBMCatering.Negocio.Properties;
using System;
using System.Collections.Generic;

namespace OBMCatering.Negocio
{
    public class PreciosIngredientesBL
    {
        Datos.OBMCateringDAL dal;

        public PreciosIngredientesBL(ContextoNegocio contexto)
        {
            dal = contexto.ObtenerDatos();
        }

        public bool HayFaltantes(Receta receta)
        {
            if (receta == null)
            {
                throw new OBMCateringException(Resources.BL_Validaciones_RecetaNull);
            }

            bool faltantes = false;

            Datos.IngredientesDAL dalIngredientes = dal.ObtenerIngredientesDAL();
            Datos.PreciosIngredientesDAL dalPreciosIngredientes = dal.ObtenerPreciosIngredientesDAL();

            foreach (IngredienteReceta ingredienteReceta in receta.Ingredientes)
            {
                Datos.Ingrediente ingredienteDAL = dalIngredientes.Obtener(ingredienteReceta.Ingrediente.Nombre);

                if (ingredienteDAL == null)
                {
                    faltantes = true;
                    break;
                }

                Datos.PrecioIngrediente precioIngredienteDAL = dalPreciosIngredientes.Obtener(ingredienteDAL);

                if (precioIngredienteDAL == null || precioIngredienteDAL.Precio == null)
                {
                    faltantes = true;
                    break;
                }
            }

            return faltantes;
        }

        public void CrearFaltantes(Receta receta)
        {
            if (receta == null)
            {
                throw new OBMCateringException(Resources.BL_Validaciones_RecetaNull);
            }

            Datos.IngredientesDAL dalIngredientes = dal.ObtenerIngredientesDAL();
            Datos.PreciosIngredientesDAL dalPreciosIngredientes = dal.ObtenerPreciosIngredientesDAL();

            foreach (IngredienteReceta ingredienteReceta in receta.Ingredientes)
            {
                Datos.Ingrediente ingredienteDAL = dalIngredientes.Obtener(ingredienteReceta.Ingrediente.Nombre);
                Datos.PrecioIngrediente precioIngredienteDAL = dalPreciosIngredientes.Obtener(ingredienteDAL);

                if(precioIngredienteDAL == null)
                {
                    Datos.RecetasDAL dalRecetas = dal.ObtenerRecetasDAL();
                    Datos.UnidadMedida unidadMedidaDAL = dalRecetas.ObtenerUnidad(ingredienteReceta.Unidad.ToString());

                    if (unidadMedidaDAL == null)
                    {
                        throw new OBMCateringException(string.Format(Resources.BL_Validaciones_UnidadMedidaInvalida, ingredienteReceta.Unidad));
                    }

                    precioIngredienteDAL = new Datos.PrecioIngrediente
                    {
                        Ingrediente = ingredienteDAL,
                        Unidad = unidadMedidaDAL
                    };

                    dalPreciosIngredientes.Crear(precioIngredienteDAL);
                }
            }

            dal.Guardar();
        }

        public void Actualizar(PrecioIngrediente precioIngrediente)
        {
            ValidarPrecioIngrediente(precioIngrediente);

            Datos.PreciosIngredientesDAL dalPreciosIngredientes = dal.ObtenerPreciosIngredientesDAL();
            Datos.PrecioIngrediente precioIngredienteDAL = dalPreciosIngredientes.Obtener(precioIngrediente.Id);

            if (precioIngredienteDAL == null)
            {
                throw new OBMCateringException(Resources.PreciosIngredientesBL_Validaciones_ItemInvalido);
            }

            Datos.RecetasDAL dalRecetas = dal.ObtenerRecetasDAL();
            Datos.UnidadMedida unidadDAL = dalRecetas.ObtenerUnidad(precioIngrediente.Unidad.ToString());

            if (unidadDAL == null)
            {
                throw new OBMCateringException(string.Format(Resources.BL_Validaciones_UnidadMedidaInvalida, precioIngrediente.Unidad));
            }

            precioIngredienteDAL.Precio = precioIngrediente.Precio;
            precioIngredienteDAL.Cantidad = precioIngrediente.Cantidad;
            precioIngredienteDAL.Unidad = unidadDAL;

            dalPreciosIngredientes.Actualizar(precioIngredienteDAL);
            dal.Guardar();
        }

        public IEnumerable<PrecioIngrediente> Obtener()
        {
            Datos.PreciosIngredientesDAL dalPreciosIngredientes = dal.ObtenerPreciosIngredientesDAL();
            IEnumerable<Datos.PrecioIngrediente> preciosIngredientesDAL = dalPreciosIngredientes.Obtener();
            List<PrecioIngrediente> preciosIngredientes = new List<PrecioIngrediente>();

            foreach(Datos.PrecioIngrediente precioIngredienteDAL in preciosIngredientesDAL)
            {
                PrecioIngrediente precioIngrediente = Obtener(precioIngredienteDAL);

                preciosIngredientes.Add(precioIngrediente);
            }

            return preciosIngredientes;
        }

        public PrecioIngrediente Obtener(Ingrediente ingrediente)
        {
            if (ingrediente == null)
            {
                throw new OBMCateringException(Resources.BL_Validaciones_IngredienteNull);
            }

            Datos.IngredientesDAL dalIngredientes = dal.ObtenerIngredientesDAL();
            Datos.Ingrediente ingredienteDAL = dalIngredientes.Obtener(ingrediente.Nombre);

            if (ingredienteDAL == null)
            {
                throw new OBMCateringException(string.Format(Resources.BL_Validaciones_IngredienteInvalido, ingrediente.Nombre));
            }

            Datos.PreciosIngredientesDAL dalPreciosIngredientes = dal.ObtenerPreciosIngredientesDAL();
            Datos.PrecioIngrediente precioIngredienteDAL = dalPreciosIngredientes.Obtener(ingredienteDAL);

            return Obtener(precioIngredienteDAL);
        }

        void ValidarPrecioIngrediente(PrecioIngrediente precioIngrediente)
        {
            if (precioIngrediente == null)
            {
                throw new OBMCateringException(Resources.PreciosIngredientesBL_Validaciones_ItemNull);
            }

            if(precioIngrediente.Ingrediente == null)
            {
                throw new OBMCateringException(Resources.BL_Validaciones_IngredienteNull);
            }
        }

        PrecioIngrediente Obtener(Datos.PrecioIngrediente precioIngredienteDAL)
        {
            UnidadMedida unidad = (UnidadMedida)Enum.Parse(typeof(UnidadMedida), precioIngredienteDAL.Unidad.Unidad);
            Ingrediente ingrediente = new Ingrediente
            {
                Id = precioIngredienteDAL.Ingrediente.ID,
                Nombre = precioIngredienteDAL.Ingrediente.Nombre,
                Descripcion = precioIngredienteDAL.Ingrediente.Descripcion
            };

            return new PrecioIngrediente
            {
                Id = precioIngredienteDAL.ID,
                Ingrediente = ingrediente,
                Precio = precioIngredienteDAL.Precio,
                Cantidad = precioIngredienteDAL.Cantidad,
                Unidad = unidad
            };
        }
    }
}
