﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Intervencije_VatrogasnihJedinica
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Model_Intervencije_VatrogasnihJedinicaContainer : DbContext
    {
        public Model_Intervencije_VatrogasnihJedinicaContainer()
            : base("name=Model_Intervencije_VatrogasnihJedinicaContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Opstina> Opstine { get; set; }
        public virtual DbSet<VatrogasnaJedinica> Vatrogasne_Jedinice { get; set; }
        public virtual DbSet<Vozilo> Vozila { get; set; }
        public virtual DbSet<Intervencija> Intervencije { get; set; }
        public virtual DbSet<Inspektor> Inspektori { get; set; }
        public virtual DbSet<Alat> Alati { get; set; }
        public virtual DbSet<Smena> Smene { get; set; }
        public virtual DbSet<Radnik> Radnici { get; set; }
        public virtual DbSet<Uvidjaj> Uvidjaji { get; set; }
        public virtual DbSet<Komandir> Komandiri { get; set; }
    }
}
