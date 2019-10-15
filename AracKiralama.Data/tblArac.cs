//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class tblArac
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblArac()
        {
            this.tblKiralama = new HashSet<tblKiralama>();
            this.tblTalep = new HashSet<tblTalep>();
            this.tblTeslim = new HashSet<tblTeslim>();
        }
    
        public int aracID { get; set; }
        public string aracMarka { get; set; }
        public string aracModel { get; set; }
        public Nullable<int> minEhliyetYasi { get; set; }
        public Nullable<int> minSurucuYasi { get; set; }
        public Nullable<int> gunlukKmSiniri { get; set; }
        public Nullable<long> aracKmsi { get; set; }
        public Nullable<int> gunlukKiralamaFiyati { get; set; }
        public Nullable<int> koltukSayisi { get; set; }
        public string yakitTuru { get; set; }
        public string aracAciklama { get; set; }
        public Nullable<bool> kiralamaDurumu { get; set; }
        public int sirketID { get; set; }
    
        public virtual tblSirket tblSirket { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblKiralama> tblKiralama { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblTalep> tblTalep { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblTeslim> tblTeslim { get; set; }
    }
}
