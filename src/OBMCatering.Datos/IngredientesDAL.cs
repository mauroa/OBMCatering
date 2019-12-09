using System.Collections.Generic;
using System.Linq;

namespace OBMCatering.Datos
{
    public class IngredientesDAL
    {
        OBMCateringEntities modelo;

        public IngredientesDAL(OBMCateringEntities modelo)
        {
            this.modelo = modelo;
        }

        public IEnumerable<Ingrediente> Obtener()
        {
            return modelo.Ingredientes.ToList();
        }

        public Ingrediente Obtener(int id)
        {
            return modelo.Ingredientes.Find(id);
        }

        public Ingrediente Obtener(string nombre)
        {
            Ingrediente resultado = null;

            foreach(Ingrediente ingrediente in modelo.Ingredientes)
            {
                if(ingrediente.Nombre == nombre)
                {
                    resultado = ingrediente;
                    break;
                }
            }

            return resultado;
        }
    }
}
