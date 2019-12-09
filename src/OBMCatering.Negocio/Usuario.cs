namespace OBMCatering.Negocio
{
    public class Usuario
    {
        public string Nick { get; set; }

        public string Nombre { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public PerfilUsuario Perfil { get; set; }
    }
}
