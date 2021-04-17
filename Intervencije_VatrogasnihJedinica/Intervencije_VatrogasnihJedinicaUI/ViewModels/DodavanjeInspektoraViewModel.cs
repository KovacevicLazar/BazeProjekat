using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System.Linq;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class DodavanjeInspektoraViewModel : Screen
    {
        private InspektorDAO inspektorDAO = new InspektorDAO();
        private string porukaGreskeZaIme = "";
        private string porukaGreskeZaPrezime = "";
        private string porukaGreskeZaTelefon = "";

        public DodavanjeInspektoraViewModel(Inspektor inspektor)
        {
            Inspektor = inspektor;
            if (inspektor != null)
            {
                Ime = inspektor.Ime;
                Prezime = Inspektor.Prezime;
                Telefon = inspektor.BrojTelefona.ToString();
            }
        }

        public Inspektor Inspektor { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }
        public string PorukaGreskeZaIme { get => porukaGreskeZaIme; set { porukaGreskeZaIme = value; NotifyOfPropertyChange(() => PorukaGreskeZaIme); } }
        public string PorukaGreskeZaPrezime { get => porukaGreskeZaPrezime; set { porukaGreskeZaPrezime = value; NotifyOfPropertyChange(() => PorukaGreskeZaPrezime); } }
        public string PorukaGreskeZaTelefon { get => porukaGreskeZaTelefon; set { porukaGreskeZaTelefon = value; NotifyOfPropertyChange(() => PorukaGreskeZaTelefon); } }

        public void DodajIzmeni()
        {
            if (Validacija())
            {
                if (Inspektor == null)
                {
                    Inspektor = new Inspektor
                    {
                        Ime = Ime,
                        Prezime = Prezime,
                        BrojTelefona = Telefon
                    };
                    inspektorDAO.Insert(Inspektor);
                }
                else
                {
                    Inspektor = new Inspektor
                    {
                        ID = Inspektor.ID,
                        Ime = Ime,
                        Prezime = Prezime,
                        BrojTelefona = Telefon
                    };
                    inspektorDAO.Update(Inspektor);
                }
                TryClose();
            }
        }

        private bool Validacija()
        {
            PorukaGreskeZaIme = "";
            PorukaGreskeZaPrezime = "";
            PorukaGreskeZaTelefon = "";

            bool ispravanUnos = true;
            if (string.IsNullOrEmpty(Ime))
            {
                PorukaGreskeZaIme = "Unesite ime inspektora!";
                ispravanUnos = false;
            }
            else if (!Ime.Trim().All(c => char.IsWhiteSpace(c) || char.IsLetter(c)))
            {
                PorukaGreskeZaIme = "Ime sme sadržati samo slova!";
                ispravanUnos = false;
            }
            else if (Ime.Trim().Length < 3 || Ime.Trim().Length > 20)
            {
                PorukaGreskeZaIme = "Ime mora sadržati od 3 do 20 slova!";
                ispravanUnos = false;
            }

            if (string.IsNullOrEmpty(Prezime))
            {
                PorukaGreskeZaPrezime = "Unesite prezime inspektora!";
                ispravanUnos = false;
            }
            else if (!Prezime.Trim().All(c => char.IsWhiteSpace(c) || char.IsLetter(c)))
            {
                PorukaGreskeZaPrezime = "Prezime sme sadržati samo slova!";
                ispravanUnos = false;
            }
            else if (Prezime.Trim().Length < 3 || Prezime.Trim().Length > 20)
            {
                PorukaGreskeZaPrezime = "Prezime mora sadržati od 3 do 20 slova!";
                ispravanUnos = false;
            }

            if (string.IsNullOrEmpty(Telefon))
            {
                PorukaGreskeZaTelefon = "Unesite broj telefona!";
                ispravanUnos = false;
            }
            else if (!Telefon.Trim().All(c => char.IsNumber(c)))
            {
                PorukaGreskeZaTelefon = "Telefon sme sadržati samo brojeve!";
                ispravanUnos = false;
            }
            else if (Telefon.Trim().Length < 6 || Telefon.Trim().Length > 14)
            {
                PorukaGreskeZaTelefon = "Telefon mora sadržati od 6 do 14 brojeva!";
                ispravanUnos = false;
            }
            else if (inspektorDAO.PronadjiPoBrojuTelefona(Telefon.Trim()) != null)
            {
                if (Inspektor == null || (Inspektor != null && Inspektor.BrojTelefona != Telefon))
                {
                    PorukaGreskeZaTelefon = "Ovaj broj telefona koristi drugi inspektor!";
                    ispravanUnos = false;
                }
            }
            return ispravanUnos;
        }
    }
}
