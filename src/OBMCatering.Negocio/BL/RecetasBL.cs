using OBMCatering.Negocio.Properties;
using System;
using System.Collections.Generic;

namespace OBMCatering.Negocio
{
    /// <summary>
    /// Reponsable de manejar las recetas del sistema dentro de la capa de negocio del mismo
    /// </summary>
    public class RecetasBL
    {
        Datos.OBMCateringDAL dal;
        PreciosIngredientesBL preciosIngredientesBL;

        /// <summary>
        /// Crea una nueva instancia de <see cref="RecetasBL"/>
        /// </summary>
        /// <param name="contexto">Contexto de negocio</param>
        /// <param name="preciosIngredientesBL">Capa de negocio de precios de ingredientes</param>
        public RecetasBL(ContextoNegocio contexto, PreciosIngredientesBL preciosIngredientesBL)
        {
            dal = contexto.ObtenerDatos();
            this.preciosIngredientesBL = preciosIngredientesBL;
        }

        /// <summary>
        /// Crea una nueva receta dentro del sistema
        /// </summary>
        /// <param name="receta">Receta a crear</param>
        public void Crear(Receta receta)
        {
            ValidarReceta(receta);

            Datos.RecetasDAL dalRecetas = dal.ObtenerRecetasDAL();
            Datos.EstadoReceta estadoDAL = dalRecetas.ObtenerEstado(EstadoReceta.SinIngredientes.ToString());

            Datos.Receta recetaDAL = new Datos.Receta
            {
                Nombre = receta.Nombre,
                Detalle = receta.Detalle,
                Estado = estadoDAL
            };

            dalRecetas.Crear(recetaDAL);
            dal.Guardar();
        }

        /// <summary>
        /// Actualiza la informacion de una receta dentro del sistema
        /// Los datos que podran actualizarse son su estado, sus detalles o informacion y sus ingredientes
        /// </summary>
        /// <param name="receta">Receta a actualizar</param>
        public void Actualizar(Receta receta)
        {
            ValidarReceta(receta);

            if (receta.Ingredientes == null || receta.Ingredientes.Count == 0)
            {
                throw new OBMCateringException(Resources.RecetasBL_Validaciones_SinIngredientes);
            }

            EstadoReceta estado;

            if (receta.Ingredientes.Count == 0)
            {
                estado = EstadoReceta.SinIngredientes;
            }
            else
            {
                bool preciosFaltantes = preciosIngredientesBL.HayFaltantes(receta);

                if (preciosFaltantes)
                {
                    estado = EstadoReceta.SinPrecio;
                }
                else
                {
                    estado = EstadoReceta.Activa;
                }
            }

            Datos.RecetasDAL dalRecetas = dal.ObtenerRecetasDAL();
            Datos.Receta recetaDAL = dalRecetas.ObtenerPorNombre(receta.Nombre);

            if (recetaDAL == null)
            {
                throw new OBMCateringException(string.Format(Resources.BL_Validaciones_RecetaInvalida, receta.Nombre));
            }

            Datos.EstadoReceta estadoDAL = dalRecetas.ObtenerEstado(estado.ToString());

            if (estadoDAL == null)
            {
                throw new OBMCateringException(string.Format(Resources.OrdenesCompraBL_Validaciones_EstadoInvalido, estado));
            }

            recetaDAL.Detalle = receta.Detalle;
            recetaDAL.Estado = estadoDAL;

            foreach (IngredienteReceta ingredienteReceta in receta.Ingredientes)
            {
                Datos.IngredienteReceta ingredienteRecetaDAL = BuscarIngredienteReceta(ingredienteReceta.Ingrediente, recetaDAL);
                Datos.UnidadMedida unidadMedidaDAL = dalRecetas.ObtenerUnidad(ingredienteReceta.Unidad.ToString());

                if (ingredienteRecetaDAL == null)
                {
                    Datos.Ingrediente ingredienteDAL = PrepararIngrediente(ingredienteReceta.Ingrediente);

                    ingredienteRecetaDAL = new Datos.IngredienteReceta
                    {
                        Ingrediente = ingredienteDAL,
                        Cantidad = ingredienteReceta.Cantidad,
                        Unidad = unidadMedidaDAL
                    };

                    recetaDAL.Ingredientes.Add(ingredienteRecetaDAL);
                }
                else
                {
                    ingredienteRecetaDAL.Cantidad = ingredienteReceta.Cantidad;
                    ingredienteRecetaDAL.Unidad = unidadMedidaDAL;
                }
            }

            dalRecetas.Actualizar(recetaDAL);
            dal.Guardar();

            if (estado == EstadoReceta.SinPrecio)
            {
                preciosIngredientesBL.CrearFaltantes(receta);
            }
        }

        /// <summary>
        /// Analiza todas las recetas cuyo estado es "Sin Precio",
        /// y recorre nuevamente todos sus ingredientes para saber si ya fueron actualizados y si se les ha asignado un precio
        /// A cada receta que ahora contenga un precio calculable, se le actualizara su estado a "Activa"
        /// Mediante este metodo se activaran las recetas que se encontraban inactivas por falta de precio calculable
        /// </summary>
        public void ActualizarRecetasSinPrecio()
        {
            Datos.RecetasDAL dalRecetas = dal.ObtenerRecetasDAL();
            IEnumerable<Receta> recetasSinPrecio = Obtener(EstadoReceta.SinPrecio);

            foreach(Receta receta in recetasSinPrecio)
            {
                bool preciosFaltantes = preciosIngredientesBL.HayFaltantes(receta);

                if (!preciosFaltantes)
                {
                    Datos.Receta recetaDAL = dalRecetas.Obtener(receta.Id);
                    Datos.EstadoReceta estadoDAL = dalRecetas.ObtenerEstado(EstadoReceta.Activa.ToString());

                    recetaDAL.Estado = estadoDAL;
                    dalRecetas.Actualizar(recetaDAL);
                }
            }

            dal.Guardar();
        }

        /// <summary>
        /// Obtiene el listado completo de recetas del sistema
        /// </summary>
        /// <returns>Listado de recetas</returns>
        public IEnumerable<Receta> Obtener()
        {
            Datos.RecetasDAL dalRecetas = dal.ObtenerRecetasDAL();
            IEnumerable<Datos.Receta> recetasDAL = dalRecetas.Obtener();

            return Obtener(recetasDAL);
        }

        /// <summary>
        /// Obtiene el listado de recetas segun su estado
        /// </summary>
        /// <param name="estado">Estado de las recetas a obtener</param>
        /// <returns>Listado de recetas</returns>
        public IEnumerable<Receta> Obtener(EstadoReceta estado)
        {
            Datos.RecetasDAL dalRecetas = dal.ObtenerRecetasDAL();
            IEnumerable<Datos.Receta> recetasDAL = dalRecetas.Obtener(estado.ToString());

            return Obtener(recetasDAL);
        }

        /// <summary>
        /// Obtiene todas las recetas que contengan determinado ingrediente en su composicion
        /// </summary>
        /// <param name="ingrediente">Ingrediente a buscar dentro de las recetas</param>
        /// <returns>Listado de recetas</returns>
        public IEnumerable<Receta> Obtener(Ingrediente ingrediente)
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

            Datos.RecetasDAL dalRecetas = dal.ObtenerRecetasDAL();
            IEnumerable<Datos.Receta> recetasDAL = dalRecetas.Obtener(ingredienteDAL);

            return Obtener(recetasDAL);
        }

        /// <summary>
        /// Obtiene una receta determinada segun su nombre
        /// </summary>
        /// <param name="nombre">Nombre de la receta a obtener</param>
        /// <returns>Receta encontrada</returns>
        public Receta Obtener(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new OBMCateringException(Resources.RecetasBL_Validaciones_NombreNull);
            }

            Datos.RecetasDAL dalRecetas = dal.ObtenerRecetasDAL();
            Datos.Receta recetaDAL = dalRecetas.ObtenerPorNombre(nombre);

            return Obtener(recetaDAL);
        }

        /// <summary>
        /// Determina si existe una receta segun su nombre
        /// </summary>
        /// <param name="nombre">Nombre de la receta a buscar</param>
        /// <returns>Valor que determina si la receta fue encontrada o no</returns>
        public bool Existe(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new OBMCateringException(Resources.RecetasBL_Validaciones_NombreNull);
            }

            Datos.RecetasDAL dalRecetas = dal.ObtenerRecetasDAL();
            Datos.Receta recetaDAL = dalRecetas.ObtenerPorNombre(nombre);

            return recetaDAL != null;
        }

        /// <summary>
        /// Calcula el precio total de una receta, que consta de consultar cada ingrediente de la receta en el listado
        /// de precios y calcular cuanto vale la cantidad que lleva ese ingrediente dentro de la receta
        /// El precio del ingrediente en el listado de precios tiene asignada una cantidad y unidad, que
        /// no necesariamente sera la misma que lleve la receta a preparar
        /// </summary>
        /// <param name="receta">Receta a calcular su precio</param>
        /// <returns>Precio total de la receta</returns>
        public decimal CalularPrecio(Receta receta)
        {
            if (receta == null)
            {
                throw new OBMCateringException(Resources.BL_Validaciones_RecetaNull);
            }

            decimal precioTotal = 0m;

            foreach(IngredienteReceta ingredienteReceta in receta.Ingredientes)
            {
                Ingrediente ingrediente = ingredienteReceta.Ingrediente;
                PrecioIngrediente precioIngrediente = preciosIngredientesBL.Obtener(ingrediente);

                if(precioIngrediente.Precio != null && ingredienteReceta.Unidad == precioIngrediente.Unidad)
                {
                    //Regla de tres simple
                    decimal precio = (ingredienteReceta.Cantidad * precioIngrediente.Precio.Value) / precioIngrediente.Cantidad.Value;

                    precioTotal = precioTotal + precio;
                }
            }

            return precioTotal;
        }

        internal Receta Obtener(Datos.Receta recetaDAL)
        {
            EstadoReceta estado = (EstadoReceta)Enum.Parse(typeof(EstadoReceta), recetaDAL.Estado.Estado);
            ICollection<IngredienteReceta> ingredientes = ObtenerIngredientesReceta(recetaDAL);

            return new Receta
            {
                Id = recetaDAL.ID,
                Nombre = recetaDAL.Nombre,
                Detalle = recetaDAL.Detalle,
                Estado = estado,
                Ingredientes = ingredientes
            };
        }

        void ValidarReceta(Receta receta)
        {
            if (receta == null)
            {
                throw new OBMCateringException(Resources.BL_Validaciones_RecetaNull);
            }
        }

        IEnumerable<Receta> Obtener(IEnumerable<Datos.Receta> recetasDAL)
        {
            List<Receta> recetas = new List<Receta>();

            foreach (Datos.Receta recetaDAL in recetasDAL)
            {
                Receta receta = Obtener(recetaDAL);

                recetas.Add(receta);
            }

            return recetas;
        }

        ICollection<IngredienteReceta> ObtenerIngredientesReceta(Datos.Receta recetaDAL)
        {
            ICollection<IngredienteReceta> ingredientesReceta = new List<IngredienteReceta>();

            foreach (Datos.IngredienteReceta ingredienteRecetaDAL in recetaDAL.Ingredientes)
            {
                UnidadMedida unidad = (UnidadMedida)Enum.Parse(typeof(UnidadMedida), ingredienteRecetaDAL.Unidad.Unidad);

                ingredientesReceta.Add(new IngredienteReceta
                {
                    Ingrediente = new Ingrediente
                    {
                        Id = ingredienteRecetaDAL.Ingrediente.ID,
                        Nombre = ingredienteRecetaDAL.Ingrediente.Nombre,
                        Descripcion = ingredienteRecetaDAL.Ingrediente.Descripcion
                    },
                    Cantidad = ingredienteRecetaDAL.Cantidad,
                    Unidad = unidad
                });
            }

            return ingredientesReceta;
        }

        Datos.IngredienteReceta BuscarIngredienteReceta(Ingrediente ingrediente, Datos.Receta recetaDAL)
        {
            Datos.IngredienteReceta resultado = null;

            foreach (Datos.IngredienteReceta ingredienteRecetaDAL in recetaDAL.Ingredientes)
            {
                if(ingredienteRecetaDAL.Ingrediente.Nombre == ingrediente.Nombre)
                {
                    resultado = ingredienteRecetaDAL;
                    break;
                }
            }

            return resultado;
        }

        Datos.Ingrediente PrepararIngrediente(Ingrediente ingrediente)
        {
            Datos.IngredientesDAL dalIngredientes = dal.ObtenerIngredientesDAL();
            Datos.Ingrediente ingredienteDAL = dalIngredientes.Obtener(ingrediente.Nombre);

            if (ingredienteDAL == null)
            {
                ingredienteDAL = new Datos.Ingrediente
                {
                    Nombre = ingrediente.Nombre,
                    Descripcion = ingrediente.Descripcion
                };
            }

            return ingredienteDAL;
        }
    }
}
