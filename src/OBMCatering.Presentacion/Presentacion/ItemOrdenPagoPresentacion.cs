using OBMCatering.Negocio;

namespace OBMCatering.Presentacion
{
    public class ItemOrdenPagoPresentacion
    {
        int id;
        ItemOrdenPago itemOrdenPago;

        public ItemOrdenPagoPresentacion(ItemOrdenPago itemOrdenPago)
        {
            this.itemOrdenPago = itemOrdenPago;
            id = itemOrdenPago.Id;

            Ingrediente = itemOrdenPago.ItemOrdenCompra.Ingrediente.Nombre;
            Cantidad = itemOrdenPago.ItemOrdenCompra.Cantidad.ToString();
            Unidad = itemOrdenPago.ItemOrdenCompra.Unidad.ToString();
            Precio = itemOrdenPago.Precio.ToString();
        }

        public string Ingrediente { get; set; }

        public string Cantidad { get; set; }

        public string Unidad { get; set; }

        public string Precio { get; set; }

        public int ObtenerId()
        {
            return id;
        }

        public ItemOrdenPago ObtenerItemOrdenPago()
        {
            return itemOrdenPago;
        }
    }
}
