using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class DodavanjeRadnikaViewModel : Screen
    {
        public DodavanjeRadnikaViewModel(Radnik radnik)
        {
            if (radnik != null)
            {
                Radnik = radnik;
                InicijalizacijaVrednosti(radnik);
            }
            Pozicije = Enum.GetValues(typeof(RadnoMesto)).Cast<RadnoMesto>().ToList();
            var jedinicaDAO = new VatrogasnaJedinicaDAO();
            VatrogasneJedinice = jedinicaDAO.GetList();
            var smenaDAO = new SmenaDAO();
            Smene = smenaDAO.GetList();
        }
        private Radnik radnik;
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public long Jmbg { get; set; }
        public int RadniStaz { get; set; }
        public RadnoMesto RadnaPozicija { get; set; }
        public IReadOnlyList<RadnoMesto> Pozicije { get; }
        public List<VatrogasnaJedinica> VatrogasneJedinice { get; set; }
        public VatrogasnaJedinica IzabranaVatrogasnaJedinica { get; set ; }
        public List<Smena> Smene { get; set; }
        public Smena IzabranaSmena { get; set; }
        public string PorukaGreskeZaGodineStaza { get => porukaGreskeZaGodineStaza; set { porukaGreskeZaGodineStaza = value; NotifyOfPropertyChange(() => PorukaGreskeZaGodineStaza); } }
        public string PorukaGreskeZaIme { get => porukaGreskeZaIme; set { porukaGreskeZaIme = value; NotifyOfPropertyChange(() => PorukaGreskeZaIme); } }
        public string PorukaGreskeZaPrezime { get => porukaGreskeZaPrezime; set { porukaGreskeZaPrezime = value; NotifyOfPropertyChange(() => PorukaGreskeZaPrezime); } }
        public string PorukaGreskeZaJMBG { get => porukaGreskeZaJMBG; set { porukaGreskeZaJMBG = value; NotifyOfPropertyChange(() => PorukaGreskeZaJMBG); } }
        public string PorukaGreskeZaPoziciju { get => porukaGreskeZaPoziciju; set { porukaGreskeZaPoziciju = value; NotifyOfPropertyChange(() => PorukaGreskeZaPoziciju); } }
        public string PorukaGreskeZaVSJ { get => porukaGreskeZaVSJ; set { porukaGreskeZaVSJ = value; NotifyOfPropertyChange(() => PorukaGreskeZaVSJ); } }
        public string PorukaGreskeZaSmenu { get => porukaGreskeZaSmenu; set { porukaGreskeZaSmenu = value; NotifyOfPropertyChange(() => PorukaGreskeZaSmenu); } }

        public Radnik Radnik { get => radnik; set => radnik = value; }

        private string porukaGreskeZaGodineStaza = "";
        private string porukaGreskeZaIme = "";
        private string porukaGreskeZaPrezime = "";
        private string porukaGreskeZaJMBG = "";
        private string porukaGreskeZaPoziciju = "";
        private string porukaGreskeZaVSJ = "";
        private string porukaGreskeZaSmenu = "";

        public void DodajIzmeni()
        {
            if (Validacija())
            {
                RadnikDAO radnikDAO = new RadnikDAO();
                if ( Radnik == null)
                {
                    Radnik = new Radnik { Ime = Ime, Prezime = Prezime, Godine_Rada = RadniStaz, JMBG = Jmbg, Radno_Mesto = RadnaPozicija, VatrogasnaJedinicaID = IzabranaVatrogasnaJedinica.ID, SmenaID=IzabranaSmena.ID };
                    radnikDAO.Insert(Radnik);
                }
                else
                {
                    Radnik = new Radnik { ID=Radnik.ID, Ime = Ime, Prezime = Prezime, Godine_Rada = RadniStaz, JMBG = Jmbg, Radno_Mesto = RadnaPozicija, VatrogasnaJedinicaID = IzabranaVatrogasnaJedinica.ID, SmenaID = IzabranaSmena.ID };
                    radnikDAO.Update(Radnik);
                }
                TryClose();
            }
        }
        private void InicijalizacijaVrednosti(Radnik radnik)
        {
            Ime = radnik.Ime;
            Prezime = radnik.Prezime;
            Jmbg = radnik.JMBG;
            RadniStaz = radnik.Godine_Rada;
            IzabranaSmena = radnik.Smena;
            NotifyOfPropertyChange(() => IzabranaSmena);
            IzabranaVatrogasnaJedinica = radnik.VatrogasnaJedinica;
            NotifyOfPropertyChange(() => IzabranaVatrogasnaJedinica);
            RadnaPozicija = radnik.Radno_Mesto;
        }

        private bool Validacija()
        {
            bool ispravanUnos = true;
            PorukaGreskeZaGodineStaza = "";
            PorukaGreskeZaIme = "";
            PorukaGreskeZaPrezime = "";
            PorukaGreskeZaJMBG = "";
            PorukaGreskeZaPoziciju = "";
            PorukaGreskeZaVSJ = "";
            PorukaGreskeZaSmenu = "";
            if (string.IsNullOrEmpty(Ime))
            {
                PorukaGreskeZaIme = "Unesite ime radnika!";
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
                PorukaGreskeZaPrezime = "Unesite prezime radnika!";
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

            if (Jmbg.ToString().Length != 13)
            {
                PorukaGreskeZaJMBG = "Jmbg mora sadrzati 13 brojeva!";
                ispravanUnos = false;
            }

            if (RadniStaz < 0 || RadniStaz > 50)
            {
                PorukaGreskeZaGodineStaza = "Samo u intervalu od 0 do 50!";
                ispravanUnos = false;
            }

            if(IzabranaVatrogasnaJedinica == null)
            {
                PorukaGreskeZaVSJ = "Izaberite vatrogasnu jedinicu!";
                ispravanUnos = false;
            }

            if (IzabranaSmena == null)
            {
                PorukaGreskeZaSmenu = "Izaberite smenu!";
                ispravanUnos = false;
            }

            return ispravanUnos;
        }
    }
}
