using System;
using System.Collections.Generic;
using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class DodavanjeInformacijaOUvidjajuViewModel :  Screen
    {
        public DodavanjeInformacijaOUvidjajuViewModel(Intervencija intervencija)
        {
            var inspektorDao = new InspektorDAO();
            Inspektori = inspektorDao.GetList();
            Intervencija = intervencija;
            if (intervencija.Uvidjaj != null)
            {
                Sati = intervencija.Uvidjaj.Datum.Hour;
                Minuti = intervencija.Uvidjaj.Datum.Minute;
                Datum = intervencija.Uvidjaj.Datum.Date;
                TextZapisnika = intervencija.Uvidjaj.Tekst_Zapisnika;
            }
            else
            {
                Sati = DateTime.Now.Hour;
                Minuti = DateTime.Now.Minute;
                Datum = DateTime.Now;
            }
        }
        public Inspektor Inspektor { get; set; }
        public List<Inspektor> Inspektori { get; set; }
        private DateTime datum;
        public DateTime Datum { get { return datum; } set { datum = value; NotifyOfPropertyChange(() => datum); } }
        public Intervencija Intervencija { get; set; }
        public int Sati { get; set; }
        public int Minuti { get; set; }
        public  string TextZapisnika { get; set; }

        public void Dodaj()
        {
            UvidjajDAO uvidjajDAO = new UvidjajDAO();
            Datum = new DateTime(Datum.Year, Datum.Month, Datum.Day, Sati, Minuti, 0);
            if (Intervencija.Uvidjaj != null)
            {
                Intervencija.Uvidjaj.Tekst_Zapisnika = TextZapisnika;
                Intervencija.Uvidjaj.Datum = Datum;
                uvidjajDAO.Update(Intervencija.Uvidjaj);
                TryClose();
            }
            else
            {
                Uvidjaj uvidjaj = new Uvidjaj { ID = Intervencija.ID, Datum = Datum, InspektorID = Inspektor.ID, Tekst_Zapisnika = TextZapisnika };
                uvidjajDAO.Insert(uvidjaj);
                TryClose();
            }
        }
    }
}
