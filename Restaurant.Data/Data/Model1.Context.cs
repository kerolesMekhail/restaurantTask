﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Restaurant.Data.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RestaurantEntities1 : DbContext
    {
        public RestaurantEntities1()
            : base("name=RestaurantEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<orderDetaile> orderDetailes { get; set; }
        public virtual DbSet<order> orders { get; set; }
    }
}