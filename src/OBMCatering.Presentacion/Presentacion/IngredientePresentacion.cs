using OBMCatering.Negocio;

namespace OBMCatering.Presentacion
{
    public class IngredientePresentacion
    {
        public IngredientePresentacion(IngredienteReceta ingrediente)
        {
            Nombre = ingrediente.Ingrediente.Nombre;
            Cantidad = ingrediente.Cantidad.ToString();
            Unidad = ingrediente.Unidad.ToString();
        }

        public string Nombre { get; set; }

        public string Cantidad { get; set; }

        public string Unidad { get; set; }
    }
}
