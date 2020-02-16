namespace OBMCatering.Negocio
{
    /// <summary>
    /// Estados posibles que puede tener una orden de compra
    /// </summary>
    public enum EstadoOrdenCompra
    {
        /// <summary>
        /// Orden de compra creada, disponible para aprobacion
        /// </summary>
        Generada = 1,
        /// <summary>
        /// Orden de compra aprobada, apta para realizar las compras de sus items
        /// </summary>
        Aprobada = 2,
        /// <summary>
        /// Orden de compra ejecutada y lista para controlar y generar la orden de pago
        /// </summary>
        Realizada = 3
    }
}
