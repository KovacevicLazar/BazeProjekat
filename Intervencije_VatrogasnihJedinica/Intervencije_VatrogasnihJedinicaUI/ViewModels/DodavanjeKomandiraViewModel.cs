using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class DodavanjeKomandiraViewModel:  Screen
    {
        public DodavanjeKomandiraViewModel(VatrogasnaJedinica vatrogasnaJedinica)
        {
            Komandir = vatrogasnaJedinica.Komandir;
            VatrogasnaJedinica = vatrogasnaJedinica;
            NazivVatrogasneJedinice = vatrogasnaJedinica.Naziv;
            if (vatrogasnaJedinica.Komandir != null)
            {
                Ime = vatrogasnaJedinica.Komandir.Ime;
                Prezime = vatrogasnaJedinica.Komandir.Prezime;
                Jmbg = vatrogasnaJedinica.Komandir.JMBG;
            }
        }
        public VatrogasnaJedinica VatrogasnaJedinica { get; set; }
        public Komandir Komandir { get; set; }
        public string NazivVatrogasneJedinice { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Jmbg { get; set; }

        public void Dodaj()
        {
            KomandirDAO komandirDAO = new KomandirDAO();
           
            if (Komandir != null)
            {
                Komandir.Prezime = Prezime;
                Komandir.Ime = Ime;
                Komandir.JMBG = Jmbg;
                komandirDAO.Update(Komandir);
                TryClose();
            }
            else
            {
                Komandir = new Komandir { ID = VatrogasnaJedinica.ID, Prezime = Prezime, Ime = Ime, JMBG = Jmbg };
                komandirDAO.Insert(Komandir);
                TryClose();
            }
        }
    }
}
