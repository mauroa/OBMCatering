using OBMCatering.Negocio;

namespace OBMCatering.Presentacion
{
    public class RecetaPresentacion
    {
        public RecetaPresentacion(Receta receta)
        {
            Nombre = receta.Nombre;
            Detalle = receta.Detalle;
            Estado = receta.Estado.ToString();
        }

        public string Nombre { get; set; }

        public string Detalle { get; set; }

        public string Estado { get; set; }
    }
}
