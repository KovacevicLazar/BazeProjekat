using System;
using System.Collections.Generic;
using System.Linq;
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
        private string porukaGreskeZaInspektora = "";
        private string porukaGreskeZaTekst = "";
        private string porukaGreskeZaDatum = "";
        private string porukaGreskeZaVreme = "";
        public Inspektor Inspektor { get; set; }
        public List<Inspektor> Inspektori { get; set; }
        private DateTime datum;
        public DateTime Datum { get { return datum; } set { datum = value; NotifyOfPropertyChange(() => datum); } }
        public Intervencija Intervencija { get; set; }
        public int Sati { get; set; }
        public int Minuti { get; set; }
        public  string TextZapisnika { get; set; }
        public string PorukaGreskeZaVreme { get => porukaGreskeZaVreme; set { porukaGreskeZaVreme = value; NotifyOfPropertyChange(() => PorukaGreskeZaVreme); } }
        public string PorukaGreskeZaDatum { get => porukaGreskeZaDatum; set { porukaGreskeZaDatum = value; NotifyOfPropertyChange(() => PorukaGreskeZaDatum); } }
        public string PorukaGreskeZaTekst { get => porukaGreskeZaTekst; set { porukaGreskeZaTekst = value; NotifyOfPropertyChange(() => PorukaGreskeZaTekst); } }
        public string PorukaGreskeZaInspektora { get => porukaGreskeZaInspektora; set { porukaGreskeZaInspektora = value; NotifyOfPropertyChange(() => PorukaGreskeZaInspektora); } }

        public void DodajIzmeni()
        {
            if (Validacija())
            {
                UvidjajDAO uvidjajDAO = new UvidjajDAO();
                Datum = new DateTime(Datum.Year, Datum.Month, Datum.Day, Sati, Minuti, 0);
                Uvidjaj uvidjaj = new Uvidjaj { ID = Intervencija.ID, Datum = Datum, InspektorID = Inspektor.ID, Tekst_Zapisnika = TextZapisnika };
                if (Intervencija.Uvidjaj == null)
                {
                    uvidjajDAO.Insert(uvidjaj);
                }
                else
                {
                    uvidjajDAO.Update(uvidjaj);
                }
                TryClose();
            }
        }
        private bool Validacija()
        {
            PorukaGreskeZaInspektora = "";
            PorukaGreskeZaTekst = "";
            PorukaGreskeZaDatum = "";
            PorukaGreskeZaVreme = "";
            bool ispravanUnos = true;

            if (string.IsNullOrEmpty(TextZapisnika))
            {
                PorukaGreskeZaTekst = "Unesite adresu!";
                ispravanUnos = false;
            }
            else if (!TextZapisnika.All(c => char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)))
            {
                PorukaGreskeZaTekst = "Adresa sme sadrzati samo slova i brojeve!";
                ispravanUnos = false;
            }
            else if (TextZapisnika.Trim().Length < 30)
            {
                PorukaGreskeZaTekst = "Tekst mora sadrzati najmanje 30 slova!";
                ispravanUnos = false;
            }

            if (Inspektor == null)
            {
                PorukaGreskeZaInspektora = "Izaberite inspektora!";
                ispravanUnos = false;
            }

            Datum = new DateTime(Datum.Year, Datum.Month, Datum.Day, Sati, Minuti, 0);
            if (Datum > DateTime.Now)
            {
                PorukaGreskeZaDatum = "Neispravan datum i vreme!";
                PorukaGreskeZaVreme = "Neispravan datum i vreme!";
                ispravanUnos = false;
            }
            else if (Datum.Year < DateTime.Now.Year - 5)
            {
                PorukaGreskeZaDatum = "Nije moguce uneti podatke starije od 5 godina!";
                ispravanUnos = false;
            }
            return ispravanUnos;
        }
    }
}
