namespace OBMCatering.Negocio
{
    /// <summary>
    /// Estados posibles que puede tener una receta
    /// </summary>
    public enum EstadoReceta
    {
        /// <summary>
        /// Receta activa y disponible para utilizarse en las ordenes de venta
        /// </summary>
        Activa = 1,
        /// <summary>
        /// Receta no disponible para su preparacion
        /// </summary>
        Inactiva = 2,
        /// <summary>
        /// Receta con alguno de sus ingredientes sin precio, lo cual hace que no pueda utilizarse en los pedidos
        /// </summary>
        SinPrecio = 3,
        /// <summary>
        /// Receta creada pero que aun no contiene ingredientes, con lo cual no podra utilizarse en los pedidos
        /// </summary>
        SinIngredientes = 4
    }
}
