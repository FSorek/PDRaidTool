﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PDRaidToolDataAccessLayer.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ToolEntities : DbContext
    {
        public ToolEntities()
            : base("name=ToolEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Entry> Entries { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Profession> Professions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Specialization> Specializations { get; set; }
    }
}
