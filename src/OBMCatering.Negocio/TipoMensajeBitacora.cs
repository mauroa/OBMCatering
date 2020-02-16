namespace OBMCatering.Negocio
{
    /// <summary>
    /// Tipos de eventos posibles dentro del sistema
    /// </summary>
    public enum TipoMensajeBitacora
    {
        /// <summary>
        /// Evento informativo
        /// </summary>
        Informacion = 1,
        /// <summary>
        /// Evento de alerta o aviso
        /// </summary>
        Alerta = 2,
        /// <summary>
        /// Evento de falla o error
        /// </summary>
        Error = 3
    }
}
