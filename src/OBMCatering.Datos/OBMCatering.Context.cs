﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OBMCateringEntities : DbContext
    {
        public OBMCateringEntities()
            : base("name=OBMCateringEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bitacora> Bitacora { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<EstadoReceta> EstadosRecetas { get; set; }
        public virtual DbSet<Factura> Facturas { get; set; }
        public virtual DbSet<Ingrediente> Ingredientes { get; set; }
        public virtual DbSet<IngredienteReceta> IngredientesRecetas { get; set; }
        public virtual DbSet<ItemOrdenCompra> ItemsOrdenesCompra { get; set; }
        public virtual DbSet<ItemOrdenPago> ItemsOrdenesPago { get; set; }
        public virtual DbSet<Localidad> Localidades { get; set; }
        public virtual DbSet<OrdenCompra> OrdenesCompra { get; set; }
        public virtual DbSet<OrdenPago> OrdenesPago { get; set; }
        public virtual DbSet<OrdenVenta> OrdenesVenta { get; set; }
        public virtual DbSet<PerfilUsuario> PerfilesUsuario { get; set; }
        public virtual DbSet<PrecioIngrediente> PreciosIngredientes { get; set; }
        public virtual DbSet<Proveedor> Proveedores { get; set; }
        public virtual DbSet<Provincia> Provincias { get; set; }
        public virtual DbSet<Receta> Recetas { get; set; }
        public virtual DbSet<TipoCliente> TiposClientes { get; set; }
        public virtual DbSet<TipoMensajeBitacora> TiposMensajesBitacora { get; set; }
        public virtual DbSet<UnidadMedida> UnidadesMedida { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<EstadoOrdenCompra> EstadosOrdenesCompra { get; set; }
    }
}
