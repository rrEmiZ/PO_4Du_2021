﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Ten kod źródłowy został wygenerowany na podstawie szablonu.
//
//    Ręczne modyfikacje tego pliku mogą spowodować nieoczekiwane zachowanie aplikacji.
//    Ręczne modyfikacje tego pliku zostaną zastąpione w przypadku ponownego wygenerowania kodu.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApp17
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BikeStoresEntities1 : DbContext
    {
        public BikeStoresEntities1()
            : base("name=BikeStoresEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<brand> brands { get; set; }
        public DbSet<category> categories { get; set; }
        public DbSet<product> products { get; set; }
        public DbSet<stock> stocks { get; set; }
        public DbSet<customer> customers { get; set; }
        public DbSet<order_items> order_items { get; set; }
        public DbSet<order> orders { get; set; }
        public DbSet<staff> staffs { get; set; }
        public DbSet<store> stores { get; set; }
    }
}
