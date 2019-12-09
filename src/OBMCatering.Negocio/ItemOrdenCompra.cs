namespace OBMCatering.Negocio
{
    public class ItemOrdenCompra
    {
        public int Id { get; set; }

        public Ingrediente Ingrediente { get; set; }

        public decimal Cantidad { get; set; }

        public UnidadMedida Unidad { get; set; }
    }
}
