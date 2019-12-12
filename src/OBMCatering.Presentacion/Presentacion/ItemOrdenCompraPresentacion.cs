using OBMCatering.Negocio;

namespace OBMCatering.Presentacion
{
    public class ItemOrdenCompraPresentacion
    {
        int id;
        ItemOrdenCompra itemOrdenCompra;

        public ItemOrdenCompraPresentacion(ItemOrdenCompra itemOrdenCompra)
        {
            this.itemOrdenCompra = itemOrdenCompra;
            id = itemOrdenCompra.Id;

            Ingrediente = itemOrdenCompra.Ingrediente.Nombre;
            Cantidad = itemOrdenCompra.Cantidad.ToString();
            Unidad = itemOrdenCompra.Unidad.ToString();
        }

        public string Ingrediente { get; set; }

        public string Cantidad { get; set; }

        public string Unidad { get; set; }

        public int ObtenerId()
        {
            return id;
        }

        public ItemOrdenCompra ObtenerItemOrdenCompra()
        {
            return itemOrdenCompra;
        }
    }
}
