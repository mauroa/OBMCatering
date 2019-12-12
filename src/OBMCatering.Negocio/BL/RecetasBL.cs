using System;
using System.Collections.Generic;

namespace OBMCatering.Negocio
{
    public class RecetasBL
    {
        Datos.OBMCateringDAL dal;
        PreciosIngredientesBL preciosIngredientesBL;

        public RecetasBL(ContextoNegocio contexto, PreciosIngredientesBL preciosIngredientesBL)
        {
            dal = contexto.ObtenerDatos();
            this.preciosIngredientesBL = preciosIngredientesBL;
        }

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

        public void Actualizar(Receta receta)
        {
            ValidarReceta(receta);

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
                throw new OBMCateringException(string.Format("La receta '{0}' no existe", receta.Nombre));
            }

            Datos.EstadoReceta estadoDAL = dalRecetas.ObtenerEstado(estado.ToString());

            if (estadoDAL == null)
            {
                throw new OBMCateringException(string.Format("El estado '{0}' es incorrecto o no es valido en el sistema", estado));
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

        public IEnumerable<Receta> Obtener()
        {
            Datos.RecetasDAL dalRecetas = dal.ObtenerRecetasDAL();
            IEnumerable<Datos.Receta> recetasDAL = dalRecetas.Obtener();

            return Obtener(recetasDAL);
        }

        public IEnumerable<Receta> Obtener(EstadoReceta estado)
        {
            Datos.RecetasDAL dalRecetas = dal.ObtenerRecetasDAL();
            IEnumerable<Datos.Receta> recetasDAL = dalRecetas.Obtener(estado.ToString());

            return Obtener(recetasDAL);
        }

        public IEnumerable<Receta> Obtener(Ingrediente ingrediente)
        {
            if (ingrediente == null)
            {
                throw new OBMCateringException("El ingrediente no puede ser nulo");
            }

            Datos.IngredientesDAL dalIngredientes = dal.ObtenerIngredientesDAL();
            Datos.Ingrediente ingredienteDAL = dalIngredientes.Obtener(ingrediente.Nombre);

            if (ingredienteDAL == null)
            {
                throw new OBMCateringException(string.Format("El ingrediente '{0}' no existe", ingrediente.Nombre));
            }

            Datos.RecetasDAL dalRecetas = dal.ObtenerRecetasDAL();
            IEnumerable<Datos.Receta> recetasDAL = dalRecetas.Obtener(ingredienteDAL);

            return Obtener(recetasDAL);
        }

        public Receta Obtener(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new OBMCateringException("El nombre de la receta no puede ser nulo o vacio");
            }

            Datos.RecetasDAL dalRecetas = dal.ObtenerRecetasDAL();
            Datos.Receta recetaDAL = dalRecetas.ObtenerPorNombre(nombre);

            return Obtener(recetaDAL);
        }

        public bool Existe(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new OBMCateringException("El nombre de la receta no puede ser nulo o vacio");
            }

            Datos.RecetasDAL dalRecetas = dal.ObtenerRecetasDAL();
            Datos.Receta recetaDAL = dalRecetas.ObtenerPorNombre(nombre);

            return recetaDAL != null;
        }

        public decimal CalularPrecio(Receta receta)
        {
            if (receta == null)
            {
                throw new OBMCateringException("La receta no puede ser nula");
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
                throw new OBMCateringException("La receta no puede ser nula");
            }

            if (receta.Ingredientes == null || receta.Ingredientes.Count == 0)
            {
                throw new OBMCateringException("La receta debe tener al menos un ingrediente");
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
