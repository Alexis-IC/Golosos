﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LosGolosos.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BDGolososEntities : DbContext
    {
        public BDGolososEntities()
            : base("name=BDGolososEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<DetalleVentas> DetalleVentas { get; set; }
        public virtual DbSet<Empleados> Empleados { get; set; }
        public virtual DbSet<Personas> Personas { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Promociones> Promociones { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Ventas> Ventas { get; set; }
    }
}
