﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DriversEntities : DbContext
    {
        public DriversEntities()
            : base("name=DriversEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ColanderToDriver> ColanderToDrivers { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<kavim> kavims { get; set; }
        public virtual DbSet<KavimToColander> KavimToColanders { get; set; }
        public virtual DbSet<KavTime> KavTimes { get; set; }
        public virtual DbSet<Preference> Preferences { get; set; }
        public virtual DbSet<TypeOfColander> TypeOfColanders { get; set; }
        public virtual DbSet<SchedularView> SchedularViews { get; set; }
    }
}