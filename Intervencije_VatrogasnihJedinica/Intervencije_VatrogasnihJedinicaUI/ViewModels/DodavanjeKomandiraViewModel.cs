using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System.Linq;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class DodavanjeKomandiraViewModel:  Screen
    {
        public DodavanjeKomandiraViewModel(VatrogasnaJedinica vatrogasnaJedinica)
        {
            Komandir = vatrogasnaJedinica.Komandir;
            VatrogasnaJedinica = vatrogasnaJedinica;
            if (vatrogasnaJedinica.Komandir != null)
            {
                Ime = vatrogasnaJedinica.Komandir.Ime;
                Prezime = vatrogasnaJedinica.Komandir.Prezime;
                Jmbg = vatrogasnaJedinica.Komandir.JMBG;
            }
        }
        public VatrogasnaJedinica VatrogasnaJedinica { get; set; }
        public Komandir Komandir { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Jmbg { get; set; }

        private string porukaGreskeZaIme = "";
        private string porukaGreskeZaPrezime = "";
        private string porukaGreskeZaJMBG = "";
        public string PorukaGreskeZaIme { get => porukaGreskeZaIme; set { porukaGreskeZaIme = value; NotifyOfPropertyChange(() => PorukaGreskeZaIme); } }
        public string PorukaGreskeZaPrezime { get => porukaGreskeZaPrezime; set { porukaGreskeZaPrezime = value; NotifyOfPropertyChange(() => PorukaGreskeZaPrezime); } }
        public string PorukaGreskeZaJMBG { get => porukaGreskeZaJMBG; set { porukaGreskeZaJMBG = value; NotifyOfPropertyChange(() => PorukaGreskeZaJMBG); } }

        public void DodajIzmeni()
        {
            KomandirDAO komandirDAO = new KomandirDAO();
            if (Validacija())
            {
                if (Komandir == null)
                {
                    Komandir = new Komandir { ID = VatrogasnaJedinica.ID, Prezime = Prezime, Ime = Ime, JMBG = Jmbg };
                    komandirDAO.Insert(Komandir);
                }
                else
                {
                    Komandir = new Komandir { ID = Komandir.ID, Prezime = Prezime, Ime = Ime, JMBG = Jmbg };
                    komandirDAO.Update(Komandir);
                }
                TryClose();
            }
        }
        private bool Validacija()
        {
            bool ispravanUnos = true;
            PorukaGreskeZaIme = "";
            PorukaGreskeZaPrezime = "";
            PorukaGreskeZaJMBG = "";
           
            if (string.IsNullOrEmpty(Ime))
            {
                PorukaGreskeZaIme = "Unesite ime komandira!";
                ispravanUnos = false;
            }
            else if (!Ime.All(c => char.IsWhiteSpace(c) || char.IsLetter(c)))
            {
                PorukaGreskeZaIme = "Ime sme sadrzati samo slova!";
                ispravanUnos = false;
            }
            else if (Ime.Length < 4 || Ime.Length > 20)
            {
                PorukaGreskeZaIme = "Ime mora sadrzati od 4 do 20 slova!";
                ispravanUnos = false;
            }

            if (string.IsNullOrEmpty(Prezime))
            {
                PorukaGreskeZaPrezime = "Unesite prezime komandira!";
                ispravanUnos = false;
            }
            else if (!Prezime.All(c => char.IsWhiteSpace(c) || char.IsLetter(c)))
            {
                PorukaGreskeZaPrezime = "Prezime sme sadrzati samo slova!";
                ispravanUnos = false;
            }
            else if (Prezime.Length < 4 || Prezime.Length > 20)
            {
                PorukaGreskeZaPrezime = "Prezime mora sadrzati od 4 do 20 slova!";
                ispravanUnos = false;
            }

            if (string.IsNullOrEmpty(Jmbg))
            {
                PorukaGreskeZaJMBG = "Unesite JBMG komandira!";
                ispravanUnos = false;
            }
            else if (!Jmbg.All(c => char.IsDigit(c)))
            {
                PorukaGreskeZaJMBG = "JMBG sme sadrzati samo brojeve!";
                ispravanUnos = false;
            }
            else if (Jmbg.Length != 13)
            {
                PorukaGreskeZaJMBG = "Jmbg mora sadrzati 13 brojeva!";
                ispravanUnos = false;
            }

            return ispravanUnos;
        }
    }
}
