//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OBMCatering.Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class ItemOrdenPago
    {
        public int ID { get; set; }
        public int IDOrdenPago { get; set; }
        public int IDItemOrdenCompra { get; set; }
        public decimal Precio { get; set; }
    
        public virtual ItemOrdenCompra ItemOrdenCompra { get; set; }
        public virtual OrdenPago OrdenPago { get; set; }
    }
}
