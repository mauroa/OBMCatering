using System;

namespace OBMCatering.Negocio
{
    /// <summary>
    /// Representa una exception particular de la capa de negocio del sistema
    /// </summary>
    public class OBMCateringException : Exception
    {
        /// <summary>
        /// Crea una nueva instancia de <see cref="OBMCateringException"/>
        /// </summary>
        /// <param name="mensaje">Mensaje de error</param>
        public OBMCateringException(string mensaje) : base(mensaje)
        {
        }
    }
}
