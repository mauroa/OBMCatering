using OBMCatering.Negocio;

namespace OBMCatering.Presentacion
{
    public class RecetaPresentacion
    {
        Receta receta;

        public RecetaPresentacion(Receta receta)
        {
            this.receta = receta;

            Nombre = receta.Nombre;
            Detalle = receta.Detalle;
            Estado = receta.Estado.ToString();
        }

        public string Nombre { get; set; }

        public string Detalle { get; set; }

        public string Estado { get; set; }

        public Receta ObtenerReceta()
        {
            return receta;
        }
    }
}
