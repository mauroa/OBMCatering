using OBMCatering.Negocio;

namespace OBMCatering.Presentacion
{
    public class ItemOrdenCompraPresentacion
    {
        public ItemOrdenCompraPresentacion(ItemOrdenCompra item)
        {
            Ingrediente = item.Ingrediente.Nombre;
            Cantidad = item.Cantidad.ToString();
            Unidad = item.Unidad.ToString();
        }

        public string Ingrediente { get; set; }

        public string Cantidad { get; set; }

        public string Unidad { get; set; }
    }
}
