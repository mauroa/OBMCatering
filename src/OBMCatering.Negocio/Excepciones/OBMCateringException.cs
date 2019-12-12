using System;

namespace OBMCatering.Negocio
{
    public class OBMCateringException : Exception
    {
        public OBMCateringException(string mensaje) : base(mensaje)
        {
        }
    }
}
