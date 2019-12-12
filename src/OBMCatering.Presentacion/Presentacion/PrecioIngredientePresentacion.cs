using OBMCatering.Negocio;

namespace OBMCatering.Presentacion
{
    public class PrecioIngredientePresentacion
    {
        PrecioIngrediente precioIngrediente;

        public PrecioIngredientePresentacion(PrecioIngrediente precioIngrediente)
        {
            this.precioIngrediente = precioIngrediente;

            Ingrediente = precioIngrediente.Ingrediente.Nombre;
            Precio = precioIngrediente.Precio.ToString();
            Cantidad = precioIngrediente.Cantidad.ToString();
            Unidad = precioIngrediente.Unidad.ToString();
        }

        public string Ingrediente { get; set; }

        public string Precio { get; set; }

        public string Cantidad { get; set; }

        public string Unidad { get; set; }

        public PrecioIngrediente ObtenerPrecioIngrediente()
        {
            return precioIngrediente;
        }
    }
}
