using System;

namespace OBMCatering.Negocio
{
    /// <summary>
    /// Representa a una factura dentro del sistema
    /// </summary>
    public class Factura
    {
        /// <summary>
        /// Identificador de la factura
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Fecha de facturacion
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Indica si la factura ha sido cobrada, es decir si el cliente ha pagado el pedido
        /// </summary>
        public bool Cobrada { get; set; }

        /// <summary>
        /// Orden de venta asociada a la factura, es decir el pedido del cliente
        /// </summary>
        public OrdenVenta OrdenVenta { get; set; }
    }
}
