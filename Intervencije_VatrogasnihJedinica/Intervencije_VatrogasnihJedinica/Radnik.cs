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
    
    public partial class Radnik
    {
        public int ID { get; set; }
        public string JMBG { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public RadnoMesto Radno_Mesto { get; set; }
        public int Godine_Rada { get; set; }
        public int VatrogasnaJedinicaID { get; set; }
        public int SmenaID { get; set; }
    
        public virtual VatrogasnaJedinica VatrogasnaJedinica { get; set; }
        public virtual Smena Smena { get; set; }
    }
}
