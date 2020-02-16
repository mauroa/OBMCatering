using OBMCatering.Presentacion;
using System.Threading;

namespace System.Windows.Forms
{
    /// <summary>
    /// Clase que representa los metodos de extension del sistema
    /// Mas explicacion: <see href="https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods">Metodos de extension</see>
    /// </summary>
    public static class Extensiones
    {
        /// <summary>
        /// Metodo que permitirle cargar el lenguaje seteado en el contexto al formulario
        /// </summary>
        public static void CargarLenguaje(this Form form)
        {
            Thread.CurrentThread.CurrentCulture = ContextoPresentacion.Instancia.Lenguaje;
            Thread.CurrentThread.CurrentUICulture = ContextoPresentacion.Instancia.Lenguaje;
        }
    }
}
