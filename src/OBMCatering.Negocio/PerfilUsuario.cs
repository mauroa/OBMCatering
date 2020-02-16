namespace OBMCatering.Negocio
{
    /// <summary>
    /// Perfiles posibles que puede tener un usuario en el sistema
    /// </summary>
    public enum PerfilUsuario
    {
        /// <summary>
        /// Perfil administrador, podra realizar cualquier actividad en el sistema
        /// </summary>
        Admin = 1,
        /// <summary>
        /// Perfil de cocina, solo podra administrar recetas, ingredientes y precios
        /// </summary>
        Cocina = 2,
        /// <summary>
        /// Perfil de ventas, solo podra administrar las ordenes de venta (pedidos) y la facturacion
        /// </summary>
        Ventas = 3,
        /// <summary>
        /// Perfil de compras, solo podra administrar las ordenes de compra y los pagos a proveedores
        /// </summary>
        Compras = 4
    }
}
