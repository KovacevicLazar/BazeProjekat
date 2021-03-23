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
        private RadnikDAO radnikDAO = new RadnikDAO();
        private RadnikSmenaDAO radnikSmenaDAO = new RadnikSmenaDAO();
        private SmenaDAO smenaDAO = new SmenaDAO();
        private VatrogasnaJedinicaDAO jedinicaDAO = new VatrogasnaJedinicaDAO();
        private Radnik radnik;
        private VatrogasnaJedinica izabranaVatrogasnaJedinica;
        private List<Smena> smene;
        private DateTime datumPocetkaRada = DateTime.Now;
        private string porukaGreskeZaDatumPocetkaRada = "Nije moguće naknadno menjati datum! Unesite ga pažljivo!";
        private string porukaGreskeZaIme = "";
        private string porukaGreskeZaPrezime = "";
        private string porukaGreskeZaJMBG = "";
        private string porukaGreskeZaPoziciju = "";
        private string porukaGreskeZaVSJ = "";
        private string porukaGreskeZaSmenu = "Prvo izaberite vatrogasnu jedinicu!";

        public DodavanjeRadnikaViewModel(Radnik radnik)
        {
            Pozicije = Enum.GetValues(typeof(RadnoMesto)).Cast<RadnoMesto>().ToList();
            VatrogasneJedinice = jedinicaDAO.GetList();
            Radnik = radnik;
            if (radnik != null)
            {
                Smene = smenaDAO.SmeneUnutarJedneVSJ(radnik.VatrogasnaJedinica.ID);
                InicijalizacijaVrednosti(radnik);
                PorukaGreskeZaDatumPocetkaRada = "Nije moguće naknadno menjati datum!";
            }
        }

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Jmbg { get; set; }
        public RadnoMesto RadnaPozicija { get; set; }
        public IReadOnlyList<RadnoMesto> Pozicije { get; }
        public List<VatrogasnaJedinica> VatrogasneJedinice { get; set; }
        public Smena IzabranaSmena { get; set; }
        public Radnik Radnik { get => radnik; set { radnik = value; NotifyOfPropertyChange(() => Radnik); } }
        public VatrogasnaJedinica IzabranaVatrogasnaJedinica { get => izabranaVatrogasnaJedinica; set { izabranaVatrogasnaJedinica = value; Smene = smenaDAO.SmeneUnutarJedneVSJ(value.ID); PorukaGreskeZaSmenu = (Smene.Count == 0) ? "Nisu dodate smene za ovu Vatrogasnu jedinicu!" : ""; } }
        public List<Smena> Smene { get => smene; set { smene = value; NotifyOfPropertyChange(() => Smene); } }
        public string PorukaGreskeZaDatumPocetkaRada { get => porukaGreskeZaDatumPocetkaRada; set { porukaGreskeZaDatumPocetkaRada = value; NotifyOfPropertyChange(() => PorukaGreskeZaDatumPocetkaRada); } }
        public string PorukaGreskeZaIme { get => porukaGreskeZaIme; set { porukaGreskeZaIme = value; NotifyOfPropertyChange(() => PorukaGreskeZaIme); } }
        public string PorukaGreskeZaPrezime { get => porukaGreskeZaPrezime; set { porukaGreskeZaPrezime = value; NotifyOfPropertyChange(() => PorukaGreskeZaPrezime); } }
        public string PorukaGreskeZaJMBG { get => porukaGreskeZaJMBG; set { porukaGreskeZaJMBG = value; NotifyOfPropertyChange(() => PorukaGreskeZaJMBG); } }
        public string PorukaGreskeZaPoziciju { get => porukaGreskeZaPoziciju; set { porukaGreskeZaPoziciju = value; NotifyOfPropertyChange(() => PorukaGreskeZaPoziciju); } }
        public string PorukaGreskeZaVSJ { get => porukaGreskeZaVSJ; set { porukaGreskeZaVSJ = value; NotifyOfPropertyChange(() => PorukaGreskeZaVSJ); } }
        public string PorukaGreskeZaSmenu { get => porukaGreskeZaSmenu; set { porukaGreskeZaSmenu = value; NotifyOfPropertyChange(() => PorukaGreskeZaSmenu); } }

        public DateTime DatumPocetkaRada { get => datumPocetkaRada; set { datumPocetkaRada = new DateTime(value.Year, value.Month, value.Day, 8, 0, 0); NotifyOfPropertyChange(() => DatumPocetkaRada); } }

        public void DodajIzmeni()
        {
            if (Validacija())
            {
                if (Radnik == null)
                {
                    Radnik = new Radnik
                    {
                        Ime = Ime,
                        Prezime = Prezime,
                        DatumPocetkaRada = DatumPocetkaRada,
                        JMBG = Jmbg,
                        Radno_Mesto = RadnaPozicija,
                        VatrogasnaJedinicaID = IzabranaVatrogasnaJedinica.ID,
                        SmenaID = IzabranaSmena.ID
                    };
                    radnikDAO.Insert(Radnik);
                    radnikSmenaDAO.Insert(new RadnikUSmeni
                    {
                        RadnikID = Radnik.ID,
                        SmenaID = IzabranaSmena.ID,
                        DatumPocetkaRada = DatumPocetkaRada
                    });
                }
                else
                {
                    Radnik = new Radnik
                    {
                        ID = Radnik.ID,
                        Ime = Ime,
                        Prezime = Prezime,
                        DatumPocetkaRada = Radnik.DatumPocetkaRada,
                        JMBG = Jmbg,
                        Radno_Mesto = RadnaPozicija,
                        VatrogasnaJedinicaID = IzabranaVatrogasnaJedinica.ID,
                        SmenaID = IzabranaSmena.ID
                    };
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
            DatumPocetkaRada = radnik.DatumPocetkaRada;
            IzabranaVatrogasnaJedinica = VatrogasneJedinice.Find(x => x.ID == radnik.VatrogasnaJedinicaID);
            NotifyOfPropertyChange(() => IzabranaVatrogasnaJedinica);
            IzabranaSmena = Smene.Find(x => x.ID == radnik.SmenaID);
            NotifyOfPropertyChange(() => IzabranaSmena);
            RadnaPozicija = radnik.Radno_Mesto;
        }

        private bool Validacija()
        {
            bool ispravanUnos = true;
            PorukaGreskeZaDatumPocetkaRada = "";
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
            else if (!Ime.Trim().All(c => char.IsWhiteSpace(c) || char.IsLetter(c)))
            {
                PorukaGreskeZaIme = "Ime sme sadržati samo slova!";
                ispravanUnos = false;
            }
            else if (Ime.Trim().Length < 3 || Ime.Trim().Length > 25)
            {
                PorukaGreskeZaIme = "Ime mora sadržati od 3 do 25 slova!";
                ispravanUnos = false;
            }

            if (string.IsNullOrEmpty(Prezime))
            {
                PorukaGreskeZaPrezime = "Unesite prezime radnika!";
                ispravanUnos = false;
            }
            else if (!Prezime.Trim().All(c => char.IsWhiteSpace(c) || char.IsLetter(c)))
            {
                PorukaGreskeZaPrezime = "Prezime sme sadržati samo slova!";
                ispravanUnos = false;
            }
            else if (Prezime.Trim().Length < 3 || Prezime.Trim().Length > 25)
            {
                PorukaGreskeZaPrezime = "Prezime mora sadržati od 3 do 25 slova!";
                ispravanUnos = false;
            }

            if (string.IsNullOrEmpty(Jmbg))
            {
                PorukaGreskeZaJMBG = "Unesite JBMG komandira!";
                ispravanUnos = false;
            }
            else if (!Jmbg.Trim().All(c => char.IsDigit(c)))
            {
                PorukaGreskeZaJMBG = "JMBG sme sadržati samo brojeve!";
                ispravanUnos = false;
            }
            else if (Jmbg.Trim().Length != 13)
            {
                PorukaGreskeZaJMBG = "Jmbg mora sadržati 13 brojeva!";
                ispravanUnos = false;
            }

            if (DatumPocetkaRada > DateTime.Now)
            {
                PorukaGreskeZaDatumPocetkaRada = "Moguće je izabrati samo datum koji je prošao!";
                ispravanUnos = false;
            }

            if (IzabranaVatrogasnaJedinica == null)
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
