//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class VatrogasnaJedinica
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VatrogasnaJedinica()
        {
            this.Radnici = new HashSet<Radnik>();
            this.Vozila = new HashSet<Vozilo>();
        }
    
        public int Id_VSJ { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public int Id_Opstine { get; set; }
    
        public virtual Opstina Opstina { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Radnik> Radnici { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vozilo> Vozila { get; set; }
    }
}
