﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PittmarkProject.DbMain
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PittmarkStoreEntities : DbContext
    {
        public PittmarkStoreEntities()
            : base("name=PittmarkStoreEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<Password> Passwords { get; set; }
        public virtual DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Facebook> Facebooks { get; set; }
        public virtual DbSet<SanPhamTrungBay> SanPhamTrungBays { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }
    }
}
