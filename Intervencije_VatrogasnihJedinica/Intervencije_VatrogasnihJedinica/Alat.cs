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
    
    public partial class Alat
    {
        public int AlatId { get; set; }
        public string Naziv_Alata { get; set; }
        public Nullable<int> Id_Vozila { get; set; }
    
        public virtual Vozilo Vozilo { get; set; }
    }
}