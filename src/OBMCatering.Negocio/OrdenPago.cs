using System;
using System.Collections.Generic;

namespace OBMCatering.Negocio
{
    /// <summary>
    /// Representa una orden de pago dentro del sistema
    /// Significa lo que se le debe pagar a un proveedor determinado por haber cumplido con la orden de compra
    /// </summary>
    public class OrdenPago
    {
        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="OrdenPago"/>
        /// </summary>
        public OrdenPago()
        {
            Items = new List<ItemOrdenPago>();
        }

        /// <summary>
        /// Identificador de la orden de pago
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Fecha de generacion de la orden de pago
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Indica si ya la orden ha sido abonada o no
        /// </summary>
        public bool Pagada { get; set; }

        /// <summary>
        /// Proveedor asociado, es decir quien cumplio con la orden de compra
        /// </summary>
        public Proveedor Proveedor { get; set; }

        /// <summary>
        /// Items que conforman la orden de pago
        /// </summary>
        public ICollection<ItemOrdenPago> Items { get; set; }
    }
}
