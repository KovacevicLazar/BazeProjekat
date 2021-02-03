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
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
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
    
        public virtual int DodeliAlatVozilu(Nullable<int> alatID, Nullable<int> voziloID, ObjectParameter success, ObjectParameter outputMessage)
        {
            var alatIDParameter = alatID.HasValue ?
                new ObjectParameter("alatID", alatID) :
                new ObjectParameter("alatID", typeof(int));
    
            var voziloIDParameter = voziloID.HasValue ?
                new ObjectParameter("voziloID", voziloID) :
                new ObjectParameter("voziloID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DodeliAlatVozilu", alatIDParameter, voziloIDParameter, success, outputMessage);
        }
    
        public virtual int UkloniAlateIzVozila(Nullable<int> voziloID, ObjectParameter success, ObjectParameter outputMessage)
        {
            var voziloIDParameter = voziloID.HasValue ?
                new ObjectParameter("voziloID", voziloID) :
                new ObjectParameter("voziloID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UkloniAlateIzVozila", voziloIDParameter, success, outputMessage);
        }
    
        public virtual int PostaviNavalnoVoziloNaIntervenciju(Nullable<int> voziloID, Nullable<int> intervencijaID, ObjectParameter success, ObjectParameter outputMessage)
        {
            var voziloIDParameter = voziloID.HasValue ?
                new ObjectParameter("voziloID", voziloID) :
                new ObjectParameter("voziloID", typeof(int));
    
            var intervencijaIDParameter = intervencijaID.HasValue ?
                new ObjectParameter("intervencijaID", intervencijaID) :
                new ObjectParameter("intervencijaID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PostaviNavalnoVoziloNaIntervenciju", voziloIDParameter, intervencijaIDParameter, success, outputMessage);
        }
    
        public virtual int PostaviTehnickoVoziloNaTehnickuIntervenciju(Nullable<int> voziloID, Nullable<int> intervencijaID, ObjectParameter success, ObjectParameter outputMessage)
        {
            var voziloIDParameter = voziloID.HasValue ?
                new ObjectParameter("voziloID", voziloID) :
                new ObjectParameter("voziloID", typeof(int));
    
            var intervencijaIDParameter = intervencijaID.HasValue ?
                new ObjectParameter("intervencijaID", intervencijaID) :
                new ObjectParameter("intervencijaID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PostaviTehnickoVoziloNaTehnickuIntervenciju", voziloIDParameter, intervencijaIDParameter, success, outputMessage);
        }
    
        public virtual int UkloniNavalnaVozilaSaIntervencije(Nullable<int> intervencijaID, ObjectParameter success, ObjectParameter outputMessage)
        {
            var intervencijaIDParameter = intervencijaID.HasValue ?
                new ObjectParameter("intervencijaID", intervencijaID) :
                new ObjectParameter("intervencijaID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UkloniNavalnaVozilaSaIntervencije", intervencijaIDParameter, success, outputMessage);
        }
    
        public virtual int UkloniTehnickaVozilaSaIntervencije(Nullable<int> intervencijaID, ObjectParameter success, ObjectParameter outputMessage)
        {
            var intervencijaIDParameter = intervencijaID.HasValue ?
                new ObjectParameter("intervencijaID", intervencijaID) :
                new ObjectParameter("intervencijaID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UkloniTehnickaVozilaSaIntervencije", intervencijaIDParameter, success, outputMessage);
        }
    
        public virtual int DodajSmenuNaIntervenciju(Nullable<int> smenaID, Nullable<int> intervencijaID, ObjectParameter success, ObjectParameter outputMessage)
        {
            var smenaIDParameter = smenaID.HasValue ?
                new ObjectParameter("smenaID", smenaID) :
                new ObjectParameter("smenaID", typeof(int));
    
            var intervencijaIDParameter = intervencijaID.HasValue ?
                new ObjectParameter("intervencijaID", intervencijaID) :
                new ObjectParameter("intervencijaID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DodajSmenuNaIntervenciju", smenaIDParameter, intervencijaIDParameter, success, outputMessage);
        }
    
        public virtual int UkloniSmeneSaIntervencije(Nullable<int> intervencijaID, ObjectParameter success, ObjectParameter outputMessage)
        {
            var intervencijaIDParameter = intervencijaID.HasValue ?
                new ObjectParameter("intervencijaID", intervencijaID) :
                new ObjectParameter("intervencijaID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UkloniSmeneSaIntervencije", intervencijaIDParameter, success, outputMessage);
        }
    }
}
