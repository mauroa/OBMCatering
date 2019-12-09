
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OBMCatering.Datos
{
    public class RecetasDAL
    {
        OBMCateringEntities modelo;

        public RecetasDAL(OBMCateringEntities modelo)
        {
            this.modelo = modelo;
        }

        public void Crear(Receta receta)
        {
            modelo.Recetas.Add(receta);
        }

        public void Actualizar(Receta receta)
        {
            modelo.Recetas.Attach(receta);
            modelo.Entry(receta).State = EntityState.Modified;
        }

        public void Eliminar(Receta receta)
        {
            modelo.Recetas.Remove(receta);
        }

        public IEnumerable<Receta> Obtener()
        {
            return modelo.Recetas.ToList();
        }

        public IEnumerable<Receta> Obtener(string estado)
        {
            List<Receta> recetas = new List<Receta>();

            foreach(Receta receta in modelo.Recetas)
            {
                if(receta.Estado.Estado == estado)
                {
                    recetas.Add(receta);
                }
            }

            return recetas;
        }

        public IEnumerable<Receta> Obtener(Ingrediente ingrediente)
        {
            List<Receta> recetas = new List<Receta>();

            foreach (Receta receta in modelo.Recetas)
            {
                foreach(IngredienteReceta ingredienteReceta in receta.Ingredientes)
                {
                    if(ingredienteReceta.Ingrediente.ID == ingrediente.ID)
                    {
                        recetas.Add(receta);
                    }
                }
            }

            return recetas;
        }

        public Receta Obtener(int id)
        {
            return modelo.Recetas.Find(id);
        }

        public Receta ObtenerPorNombre(string nombre)
        {
            Receta resultado = null;

            foreach(Receta receta in modelo.Recetas)
            {
                if(receta.Nombre == nombre)
                {
                    resultado = receta;
                    break;
                }
            }

            return resultado;
        }

        public UnidadMedida ObtenerUnidad(string unidad)
        {
            UnidadMedida resultado = null;

            foreach(UnidadMedida unidadMedida in modelo.UnidadesMedida)
            {
                if(unidadMedida.Unidad == unidad)
                {
                    resultado = unidadMedida;
                    break;
                }
            }

            return resultado;
        }

        public EstadoReceta ObtenerEstado(string estado)
        {
            EstadoReceta resultado = null;

            foreach (EstadoReceta estadoReceta in modelo.EstadosRecetas)
            {
                if (estadoReceta.Estado == estado)
                {
                    resultado = estadoReceta;
                    break;
                }
            }

            return resultado;
        }
    }
}
