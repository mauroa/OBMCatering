namespace OBMCatering.Negocio
{
    public class Localidad
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public Provincia Provincia { get; set; }
    }
}
