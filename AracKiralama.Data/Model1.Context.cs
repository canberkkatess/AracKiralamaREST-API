﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AracKiralama.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Hastane_RandevuEntities : DbContext
    {
        public Hastane_RandevuEntities()
            : base("name=Hastane_RandevuEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tblArac> tblArac { get; set; }
        public virtual DbSet<tblKiralama> tblKiralama { get; set; }
        public virtual DbSet<tblMusteri> tblMusteri { get; set; }
        public virtual DbSet<tblPuan> tblPuan { get; set; }
        public virtual DbSet<tblSirket> tblSirket { get; set; }
        public virtual DbSet<tblTalep> tblTalep { get; set; }
        public virtual DbSet<tblTeslim> tblTeslim { get; set; }
    
        public virtual ObjectResult<AracKmGor_Result> AracKmGor(Nullable<int> aracID)
        {
            var aracIDParameter = aracID.HasValue ?
                new ObjectParameter("aracID", aracID) :
                new ObjectParameter("aracID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AracKmGor_Result>("AracKmGor", aracIDParameter);
        }
    
        public virtual ObjectResult<ARACLARI_GETIR_Result> ARACLARI_GETIR()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ARACLARI_GETIR_Result>("ARACLARI_GETIR");
        }
    
        public virtual ObjectResult<AylıkKazanc_Result> AylıkKazanc(Nullable<int> sirketID)
        {
            var sirketIDParameter = sirketID.HasValue ?
                new ObjectParameter("sirketID", sirketID) :
                new ObjectParameter("sirketID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AylıkKazanc_Result>("AylıkKazanc", sirketIDParameter);
        }
    
        public virtual ObjectResult<AylıkKazanclar_Result> AylıkKazanclar(Nullable<int> sirketID)
        {
            var sirketIDParameter = sirketID.HasValue ?
                new ObjectParameter("sirketID", sirketID) :
                new ObjectParameter("sirketID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AylıkKazanclar_Result>("AylıkKazanclar", sirketIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> AylıkNetKar(Nullable<int> sirketID)
        {
            var sirketIDParameter = sirketID.HasValue ?
                new ObjectParameter("sirketID", sirketID) :
                new ObjectParameter("sirketID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("AylıkNetKar", sirketIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> AylıkToplamKazanc(Nullable<int> sirketID)
        {
            var sirketIDParameter = sirketID.HasValue ?
                new ObjectParameter("sirketID", sirketID) :
                new ObjectParameter("sirketID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("AylıkToplamKazanc", sirketIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> AylıkVergi(Nullable<int> sirketID)
        {
            var sirketIDParameter = sirketID.HasValue ?
                new ObjectParameter("sirketID", sirketID) :
                new ObjectParameter("sirketID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("AylıkVergi", sirketIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> GunlukKiralamalar(Nullable<System.DateTime> tarih, Nullable<int> sirketID)
        {
            var tarihParameter = tarih.HasValue ?
                new ObjectParameter("tarih", tarih) :
                new ObjectParameter("tarih", typeof(System.DateTime));
    
            var sirketIDParameter = sirketID.HasValue ?
                new ObjectParameter("sirketID", sirketID) :
                new ObjectParameter("sirketID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("GunlukKiralamalar", tarihParameter, sirketIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> GunlukKmSiniriAsanAracSayisi(Nullable<int> sirketID, Nullable<System.DateTime> tarih)
        {
            var sirketIDParameter = sirketID.HasValue ?
                new ObjectParameter("sirketID", sirketID) :
                new ObjectParameter("sirketID", typeof(int));
    
            var tarihParameter = tarih.HasValue ?
                new ObjectParameter("tarih", tarih) :
                new ObjectParameter("tarih", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("GunlukKmSiniriAsanAracSayisi", sirketIDParameter, tarihParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<Nullable<int>> AylıkNetKar1(Nullable<int> sirketID)
        {
            var sirketIDParameter = sirketID.HasValue ?
                new ObjectParameter("sirketID", sirketID) :
                new ObjectParameter("sirketID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("AylıkNetKar1", sirketIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> AylıkVergi1(Nullable<int> sirketID)
        {
            var sirketIDParameter = sirketID.HasValue ?
                new ObjectParameter("sirketID", sirketID) :
                new ObjectParameter("sirketID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("AylıkVergi1", sirketIDParameter);
        }
    
        public virtual ObjectResult<AracKmGor1_Result> AracKmGor1(Nullable<int> aracID)
        {
            var aracIDParameter = aracID.HasValue ?
                new ObjectParameter("aracID", aracID) :
                new ObjectParameter("aracID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AracKmGor1_Result>("AracKmGor1", aracIDParameter);
        }
    
        public virtual ObjectResult<AylıkKazanclar1_Result> AylıkKazanclar1(Nullable<int> sirketID)
        {
            var sirketIDParameter = sirketID.HasValue ?
                new ObjectParameter("sirketID", sirketID) :
                new ObjectParameter("sirketID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<AylıkKazanclar1_Result>("AylıkKazanclar1", sirketIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> AylıkNetKar2(Nullable<int> sirketID)
        {
            var sirketIDParameter = sirketID.HasValue ?
                new ObjectParameter("sirketID", sirketID) :
                new ObjectParameter("sirketID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("AylıkNetKar2", sirketIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> AylıkToplamKazanc1(Nullable<int> sirketID)
        {
            var sirketIDParameter = sirketID.HasValue ?
                new ObjectParameter("sirketID", sirketID) :
                new ObjectParameter("sirketID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("AylıkToplamKazanc1", sirketIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> AylıkVergi2(Nullable<int> sirketID)
        {
            var sirketIDParameter = sirketID.HasValue ?
                new ObjectParameter("sirketID", sirketID) :
                new ObjectParameter("sirketID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("AylıkVergi2", sirketIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> GunlukKiralamalar1(Nullable<System.DateTime> tarih, Nullable<int> sirketID)
        {
            var tarihParameter = tarih.HasValue ?
                new ObjectParameter("tarih", tarih) :
                new ObjectParameter("tarih", typeof(System.DateTime));
    
            var sirketIDParameter = sirketID.HasValue ?
                new ObjectParameter("sirketID", sirketID) :
                new ObjectParameter("sirketID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("GunlukKiralamalar1", tarihParameter, sirketIDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> GunlukKmSiniriAsanAracSayisi1(Nullable<int> sirketID, Nullable<System.DateTime> tarih)
        {
            var sirketIDParameter = sirketID.HasValue ?
                new ObjectParameter("sirketID", sirketID) :
                new ObjectParameter("sirketID", typeof(int));
    
            var tarihParameter = tarih.HasValue ?
                new ObjectParameter("tarih", tarih) :
                new ObjectParameter("tarih", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("GunlukKmSiniriAsanAracSayisi1", sirketIDParameter, tarihParameter);
        }
    }
}
