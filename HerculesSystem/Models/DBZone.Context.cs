﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HerculesSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class hercules_dbEntities : DbContext
    {
        public hercules_dbEntities()
            : base("name=hercules_dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<zone> zones2 { get; set; }
        public virtual DbSet<sites> sites { get; set; }
        public virtual DbSet<company> company { get; set; }
        public virtual DbSet<loggers> loggers { get; set; }
        public virtual DbSet<alarms> alarms { get; set; }
        public virtual DbSet<alarmTypes> alarmTypes { get; set; }
    }
}
