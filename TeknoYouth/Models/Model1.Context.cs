﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeknoYouth.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBTYouthEntities : DbContext
    {
        public DBTYouthEntities()
            : base("name=DBTYouthEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<CvBilgi> CvBilgi { get; set; }
        public virtual DbSet<İletisim> İletisim { get; set; }
        public virtual DbSet<KategoriT> KategoriT { get; set; }
        public virtual DbSet<Projeler> Projeler { get; set; }
        public virtual DbSet<SiteKimlik> SiteKimlik { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Yorum> Yorum { get; set; }
        public virtual DbSet<YorumsT> YorumsT { get; set; }
    }
}