namespace OBMCatering.Negocio
{
    public class ItemOrdenPago
    {
        public int Id { get; set; }

        public ItemOrdenCompra ItemOrdenCompra { get; set; }

        public decimal Precio { get; set; }
    }
}
