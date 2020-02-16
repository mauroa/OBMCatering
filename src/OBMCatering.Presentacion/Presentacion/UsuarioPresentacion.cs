using OBMCatering.Negocio;

namespace OBMCatering.Presentacion
{
    /// <summary>
    /// Representacion de la clase <see cref="Usuario"/> en la capa de presentacion
    /// La idea es aplanar los datos y sus tipos, de manera de poder consultarlos mejor 
    /// y tambien mostrarlos de manera mas simple en una grilla 
    /// </summary>
    public class UsuarioPresentacion
    {
        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="UsuarioPresentacion"/>
        /// </summary>
        /// <param name="usuario">Usuario del sistema</param>
        public UsuarioPresentacion(Usuario usuario)
        {
            Nick = usuario.Nick;
            Nombre = usuario.Nombre;
            Email = usuario.Email;
            Password = usuario.Password;
            Perfil = usuario.Perfil.ToString();
            Resetear = usuario.CambiarPassword;
        }

        /// <summary>
        /// Nombre de usuario
        /// </summary>
        public string Nick { get; set; }

        /// <summary>
        /// Nombre completo del usuario
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Email del usuario
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Password del usuario
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Perfil del usuario
        /// </summary>
        public string Perfil { get; set; }

        /// <summary>
        /// Indica si se debe resetear el password del usuario la proxima vez que se loguea
        /// </summary>
        public bool Resetear { get; set; }
    }
}
