using OBMCatering.Negocio.Properties;
using System;
using System.Collections.Generic;

namespace OBMCatering.Negocio
{
    /// <summary>
    /// Reponsable de manejar el listado de precios de los ingredientes del sistema dentro de la capa de negocio del mismo
    /// </summary>
    public class PreciosIngredientesBL
    {
        Datos.OBMCateringDAL dal;

        /// <summary>
        /// Crea una nueva instancia de <see cref="PreciosIngredientesBL"/>
        /// </summary>
        /// <param name="contexto">Contexto de negocio</param>
        public PreciosIngredientesBL(ContextoNegocio contexto)
        {
            dal = contexto.ObtenerDatos();
        }

        /// <summary>
        /// Determina si dentro de una receta hay ingredientes a los que le falta asignar el precio
        /// Esto indica si una receta esta apta para utilizarse o debe quedar inactiva
        /// </summary>
        /// <param name="receta">Receta a consultar</param>
        /// <returns>Valor que indica si hay ingredientes con faltante de precio</returns>
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

        /// <summary>
        /// Crea entradas en el listado de precios para los ingredientes que aun no figuren en el mismo,
        /// es decir para nuevos ingredientes de una receta.
        /// Las entradas se crearan con el precio como faltante, ya que solo los usuarios autorizados podran asignar precios a los ingredientes
        /// </summary>
        /// <param name="receta">Receta para analizar sus ingredientes y crear precios faltantes si es necesario</param>
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

        /// <summary>
        /// Actualiza la informacion de una entrada en el listado de precios
        /// Pueden actualizarse el precio del ingrediente, su cantidad o su unidad
        /// </summary>
        /// <param name="precioIngrediente">Unidad dentro la lista de precios a actualizar</param>
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

        /// <summary>
        /// Obtiene el listado completo de precios de los ingredientes del sistema
        /// </summary>
        /// <returns>Listado de precios de los ingredientes</returns>
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

        /// <summary>
        /// Obtiene un precio en particular para un ingrediente dado
        /// </summary>
        /// <param name="ingrediente">Ingrediente para obtener su precio y caracteristicas</param>
        /// <returns>Entrada en el listado de precios para ese ingrediente</returns>
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
