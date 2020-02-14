using OBMCatering.Presentacion;
using System.Threading;

namespace System.Windows.Forms
{
    public static class Extensiones
    {
        public static void CargarLenguaje(this Form form)
        {
            Thread.CurrentThread.CurrentCulture = ContextoPresentacion.Instancia.Lenguaje;
            Thread.CurrentThread.CurrentUICulture = ContextoPresentacion.Instancia.Lenguaje;
        }
    }
}
