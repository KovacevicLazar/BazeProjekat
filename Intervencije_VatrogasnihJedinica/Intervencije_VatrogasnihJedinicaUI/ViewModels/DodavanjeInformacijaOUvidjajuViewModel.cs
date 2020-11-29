using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class DodavanjeInformacijaOUvidjajuViewModel :  Screen
    {
        public DodavanjeInformacijaOUvidjajuViewModel(Intervencija intervencija)
        {
            Sati = DateTime.Now.Hour;
            Minuti = DateTime.Now.Minute;
            Datum = DateTime.Now;
            Intervencija = intervencija;
        }
        private DateTime datum;
        public DateTime Datum { get { return datum; } set { datum = value; NotifyOfPropertyChange(() => datum); } }

        public Intervencija Intervencija { get; set; }
        public int Sati { get; set; }
        public int Minuti { get; set; }

        public  string TextZapisnika { get; set; }

        public void Dodaj()
        {
            Datum = new DateTime(Datum.Year, Datum.Month, Datum.Day, Sati, Minuti, 0);

            Zapisnik zapisnik = new Zapisnik { Tekst_Zapisnika = TextZapisnika };
            Uvidjaj uvidjaj = new Uvidjaj { Datum = Datum , Intervencija = Intervencija  , IdInspektora = 2 };
            zapisnik.Uvidjaj = uvidjaj;

            ZapisnikDAO zapisnikDAO = new ZapisnikDAO();
            zapisnikDAO.Insert(zapisnik);
           // Intervencija.Uvidjaj = uvidjaj;
            //IntervencijaDAO intervencijaDAO = new IntervencijaDAO();
           // intervencijaDAO.Update(Intervencija);
            
            TryClose();
        }
    }
}
