using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System.Linq;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class DodavanjeInspektoraViewModel : Screen
    {
        public DodavanjeInspektoraViewModel(Inspektor inspektor)
        {
            Inspektor = inspektor;
            if (inspektor != null)
            {
                Ime = inspektor.Ime;
                Prezime = Inspektor.Prezime;
                Telefon = inspektor.Broj_Telefona.ToString();
            }
        }

        public Inspektor Inspektor { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }

        private string porukaGreskeZaIme = "";
        private string porukaGreskeZaPrezime = "";
        private string porukaGreskeZaTelefon = "";
        public string PorukaGreskeZaIme { get => porukaGreskeZaIme; set { porukaGreskeZaIme = value; NotifyOfPropertyChange(() => PorukaGreskeZaIme); } }
        public string PorukaGreskeZaPrezime { get => porukaGreskeZaPrezime; set { porukaGreskeZaPrezime = value; NotifyOfPropertyChange(() => PorukaGreskeZaPrezime); } }
        public string PorukaGreskeZaTelefon { get => porukaGreskeZaTelefon; set { porukaGreskeZaTelefon = value; NotifyOfPropertyChange(() => PorukaGreskeZaTelefon); } }

        public void DodajIzmeni()
        {
            InspektorDAO inspektorDAO = new InspektorDAO();
            if (Validacija())
            {
                if (Inspektor == null)
                {
                    Inspektor = new Inspektor { Ime = Ime, Prezime = Prezime, Broj_Telefona = Telefon };
                    inspektorDAO.Insert(Inspektor);
                }
                else
                {
                    Inspektor = new Inspektor { ID=Inspektor.ID, Ime = Ime, Prezime = Prezime, Broj_Telefona = Telefon };
                    inspektorDAO.Update(Inspektor);
                }
                TryClose();
            }
        }
        private bool Validacija()
        {
            bool ispravanUnos = true;
            PorukaGreskeZaIme = "";
            PorukaGreskeZaPrezime = "";
            PorukaGreskeZaTelefon = "";

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

            if (string.IsNullOrEmpty(Telefon))
            {
                PorukaGreskeZaTelefon = "Unesite broj telefona!";
                ispravanUnos = false;
            }
            else if (!Telefon.All(c => char.IsNumber(c)))
            {
                PorukaGreskeZaTelefon = "Telefon sme sadrzati samo brojeve!";
                ispravanUnos = false;
            }
            else if (Telefon.Length < 6 || Telefon.Length > 14)
            {
                PorukaGreskeZaTelefon = "Telefon mora sadrzati od 6 do 14 brojeva!";
                ispravanUnos = false;
            }
            return ispravanUnos;
        }
    }
}
