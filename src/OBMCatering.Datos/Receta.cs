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
    
    public partial class Receta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Receta()
        {
            this.Ingredientes = new HashSet<IngredienteReceta>();
            this.OrdenesVenta = new HashSet<OrdenVenta>();
        }
    
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Detalle { get; set; }
    
        public virtual EstadoReceta Estado { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IngredienteReceta> Ingredientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdenVenta> OrdenesVenta { get; set; }
    }
}
