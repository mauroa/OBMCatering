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
    
    public partial class Factura
    {
        public int ID { get; set; }
        public System.DateTime Fecha { get; set; }
        public bool Cobrada { get; set; }
    
        public virtual OrdenVenta OrdenVenta { get; set; }
    }
}
