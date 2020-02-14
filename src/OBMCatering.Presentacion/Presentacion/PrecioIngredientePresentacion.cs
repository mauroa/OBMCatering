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

            if(precioIngrediente.Precio.HasValue)
            {
                Precio = precioIngrediente.Precio.Value.ToString("N2");
            }
            else
            {
                Precio = string.Empty;
            }

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
