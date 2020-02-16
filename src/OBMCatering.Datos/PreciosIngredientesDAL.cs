using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace OBMCatering.Datos
{
    /// <summary>
    /// Responsable de manejar los precios de los ingredientes dentro de la capa de acceso a datos del sistema
    /// </summary>
    public class PreciosIngredientesDAL
    {
        OBMCateringEntities modelo;

        public PreciosIngredientesDAL(OBMCateringEntities modelo)
        {
            this.modelo = modelo;
        }

        public void Crear(PrecioIngrediente precioIngrediente)
        {
            modelo.PreciosIngredientes.Add(precioIngrediente);
        }

        public void Actualizar(PrecioIngrediente precioIngrediente)
        {
            modelo.PreciosIngredientes.Attach(precioIngrediente);
            modelo.Entry(precioIngrediente).State = EntityState.Modified;
        }

        public IEnumerable<PrecioIngrediente> Obtener()
        {
            return modelo.PreciosIngredientes.ToList();
        }

        public PrecioIngrediente Obtener(int id)
        {
            return modelo.PreciosIngredientes.Find(id);
        }

        public PrecioIngrediente Obtener(Ingrediente ingrediente)
        {
            PrecioIngrediente resultado = null;

            foreach (PrecioIngrediente precioIngrediente in modelo.PreciosIngredientes)
            {
                if (precioIngrediente.Ingrediente.Nombre == ingrediente.Nombre)
                {
                    resultado = precioIngrediente;
                    break;
                }
            }

            return resultado;
        }
    }
}
