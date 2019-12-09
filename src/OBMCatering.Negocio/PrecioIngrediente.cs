namespace OBMCatering.Negocio
{
    public class PrecioIngrediente
    {
        public int Id { get; set; }

        public Ingrediente Ingrediente { get; set; }

        public decimal? Precio { get; set; }

        public decimal? Cantidad { get; set; }

        public UnidadMedida Unidad { get; set; }
    }
}
