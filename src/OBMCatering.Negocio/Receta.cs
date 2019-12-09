using System.Collections.Generic;

namespace OBMCatering.Negocio
{
    public class Receta
    {
        public Receta()
        {
            Ingredientes = new List<IngredienteReceta>();
        }

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Detalle { get; set; }

        public EstadoReceta Estado { get; set; }

        public ICollection<IngredienteReceta> Ingredientes { get; set; }
    }
}
