﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ParkingApp.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class bdParkingEntities : DbContext
    {
        public bdParkingEntities()
            : base("name=bdParkingEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Archive> Archive { get; set; }
        public virtual DbSet<ClientData> ClientData { get; set; }
        public virtual DbSet<Parking> Parking { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}