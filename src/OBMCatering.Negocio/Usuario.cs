namespace OBMCatering.Negocio
{
    /// <summary>
    /// Repesenta a un usuario dentro del sistema, es decir quienes manejan sus distintas partes
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Identificador o nombre de usuario
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
        /// Password de la cuenta del usuario
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Perfil asociado al usuario
        /// Esto determina el acceso que tendra al sistema, es decir los permisos para las distintas partes del mismo
        /// </summary>
        public PerfilUsuario Perfil { get; set; }

        /// <summary>
        /// Indica si el password ha sido resetado, lo cual implica cambiarlo la proxima vez que se loguea
        /// </summary>
        public bool CambiarPassword { get; set; }
    }
}
