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
    
    public partial class ItemOrdenCompra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ItemOrdenCompra()
        {
            this.ItemsOrdenesPago = new HashSet<ItemOrdenPago>();
        }
    
        public int ID { get; set; }
        public decimal Cantidad { get; set; }
    
        public virtual Ingrediente Ingrediente { get; set; }
        public virtual OrdenCompra OrdenCompra { get; set; }
        public virtual UnidadMedida Unidad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemOrdenPago> ItemsOrdenesPago { get; set; }
    }
}
