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
    
    public partial class Empleado
    {
        public string CUIT { get; set; }
        public string Nombre { get; set; }
        public System.DateTime FechaNacimiento { get; set; }
        public string Domicilio { get; set; }
        public string CodigoPostal { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public System.DateTime FechaAlta { get; set; }
        public Nullable<System.DateTime> FechaBaja { get; set; }
    
        public virtual Localidad Localidad { get; set; }
    }
}