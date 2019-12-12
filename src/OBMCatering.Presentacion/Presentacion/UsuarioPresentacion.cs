using OBMCatering.Negocio;

namespace OBMCatering.Presentacion
{
    public class UsuarioPresentacion
    {
        public UsuarioPresentacion(Usuario usuario)
        {
            Nick = usuario.Nick;
            Nombre = usuario.Nombre;
            Email = usuario.Email;
            Password = usuario.Password;
            Perfil = usuario.Perfil.ToString();
            Resetear = usuario.CambiarPassword;
        }

        public string Nick { get; set; }

        public string Nombre { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Perfil { get; set; }

        public bool Resetear { get; set; }
    }
}
