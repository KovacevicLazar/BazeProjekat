using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using Intervencije_VatrogasnihJedinicaUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class DodavanjeIntervencijeViewModel : Screen
    {
        public DodavanjeIntervencijeViewModel(Intervencija intervencija)
        {
            Intervencija = intervencija;
            TipoviIntervencije = Enum.GetValues(typeof(TipIntervencijeEnum)).Cast<TipIntervencijeEnum>().ToList();
            OpstinaDAO opstinaDAO = new OpstinaDAO();
            Opstine = opstinaDAO.GetList();
            Pozar = new Pozar();
            TehnickaIntervencija = new Tehnicka_Intervencija();
            PozarDAO = new PozarDAO();
            TehnickaIntervencijaDAO = new TehnickaIntervencijaDAO();

            if (intervencija !=null)
            {
                Sati = intervencija.Datum_I_Vreme.Hour;
                Minuti = intervencija.Datum_I_Vreme.Minute;
                Datum = intervencija.Datum_I_Vreme.Date;
                Adresa = intervencija.Adresa;
                IzabranaOpstina = intervencija.Opstina;
                TipIntervencije = intervencija.Tip;
                if (TipIntervencije == TipIntervencijeEnum.POZAR)
                {
                    Pozar = PozarDAO.FindById(intervencija.ID);
                }
                else if (TipIntervencije == TipIntervencijeEnum.TEHNICKA_INTERVENCIJA)
                {
                    TehnickaIntervencija = TehnickaIntervencijaDAO.FindById(intervencija.ID);
                }
            }
            else
            {
                Sati = DateTime.Now.Hour;
                Minuti = DateTime.Now.Minute;
                Datum = DateTime.Now;
            }

            InicijalizacijaListeVozila();
            InicijalizacijaListeSmena();
        }
        public PozarDAO PozarDAO { get; set; }
        public Pozar Pozar { get; set; }
        public TehnickaIntervencijaDAO TehnickaIntervencijaDAO { get; set; }
        public Tehnicka_Intervencija TehnickaIntervencija { get; set; }
        public Intervencija Intervencija { get; set; }
        public IReadOnlyList<TipIntervencijeEnum> TipoviIntervencije { get; }
        private TipIntervencijeEnum tipIntervencije;
        public TipIntervencijeEnum TipIntervencije { get => tipIntervencije; set { tipIntervencije = value; InicijalizacijaListeVozila(); } }
        public List<Opstina> Opstine { get; set; }
        private DateTime datum;
        public DateTime Datum { get { return datum; } set { datum = value; NotifyOfPropertyChange(() => datum); } }
        public int Sati { get; set; }
        public int Minuti { get; set; }
        public string Adresa { get; set; }
        public Opstina IzabranaOpstina { get; set; }

        private string porukaGreskeZaAdresu = "";
        private string porukaGreskeZaOpstinu = "";
        private string porukaGreskeZaDatum = "";
        private string porukaGreskeZaVreme = "";
        public string PorukaGreskeZaVreme { get => porukaGreskeZaVreme; set { porukaGreskeZaVreme = value; NotifyOfPropertyChange(() => PorukaGreskeZaVreme);  } }
        public string PorukaGreskeZaDatum { get => porukaGreskeZaDatum; set { porukaGreskeZaDatum = value; NotifyOfPropertyChange(() => PorukaGreskeZaDatum); } }
        public string PorukaGreskeZaOpstinu { get => porukaGreskeZaOpstinu; set { porukaGreskeZaOpstinu = value; NotifyOfPropertyChange(() => PorukaGreskeZaOpstinu); } }
        public string PorukaGreskeZaAdresu { get => porukaGreskeZaAdresu; set { porukaGreskeZaAdresu = value; NotifyOfPropertyChange(() => PorukaGreskeZaAdresu); } }

        private List<SmenaIsSelected> smene;
        private List<VoziloIsSelected> vozila;
        public List<VoziloIsSelected> Vozila { get => vozila; set { vozila = value; NotifyOfPropertyChange(() => Vozila); } }
        public List<SmenaIsSelected> Smene { get => smene; set { smene = value; NotifyOfPropertyChange(() => Smene); } }


        public void DodajIzmeni()
        {
            if (Validacija())
            {
                Datum = new DateTime(Datum.Year, Datum.Month, Datum.Day, Sati, Minuti, 0);
                if(Intervencija == null)
                {
                    switch (TipIntervencije)
                    {
                        case (TipIntervencijeEnum.POZAR):
                            Pozar = new Pozar { Tip = TipIntervencije, Adresa = Adresa, Datum_I_Vreme = Datum, Id_Opstine = IzabranaOpstina.ID };
                            PozarDAO.Insert(Pozar);
                            DodajVozilaISmeneZaPozarUBazuPodataka();
                            break;
                        case (TipIntervencijeEnum.TEHNICKA_INTERVENCIJA):
                            TehnickaIntervencija = new Tehnicka_Intervencija { Tip = TipIntervencije, Adresa = Adresa, Datum_I_Vreme = Datum, Id_Opstine = IzabranaOpstina.ID };
                            TehnickaIntervencijaDAO.Insert(TehnickaIntervencija);
                            DodajVozilaISmeneZaTehnickuIntervencijuUBazuPodataka();
                            break;
                    }
                }
                else
                {
                    switch (TipIntervencije)
                    {
                        case (TipIntervencijeEnum.POZAR):
                            Pozar = new Pozar { ID=Intervencija.ID, Tip = TipIntervencije, Adresa = Adresa, Datum_I_Vreme = Datum, Id_Opstine = IzabranaOpstina.ID };
                            PozarDAO.Update(Pozar);
                            PozarDAO.UkloniVozilaSaIntervencije(Pozar.ID);
                            PozarDAO.UkloniSmeneSaIntervencije(Pozar.ID);
                            DodajVozilaISmeneZaPozarUBazuPodataka();
                            break;
                        case (TipIntervencijeEnum.TEHNICKA_INTERVENCIJA):
                            TehnickaIntervencija = new Tehnicka_Intervencija { ID = Intervencija.ID, Tip = TipIntervencije, Adresa = Adresa, Datum_I_Vreme = Datum, Id_Opstine = IzabranaOpstina.ID };
                            TehnickaIntervencijaDAO.Update(TehnickaIntervencija);
                            TehnickaIntervencijaDAO.UkloniVozilaSaIntervencije(TehnickaIntervencija.ID);
                            TehnickaIntervencijaDAO.UkloniSmeneSaIntervencije(TehnickaIntervencija.ID);
                            DodajVozilaISmeneZaTehnickuIntervencijuUBazuPodataka();
                            break;
                    }
                }
                TryClose();
            }
        }

        private void DodajVozilaISmeneZaPozarUBazuPodataka()
        {
            foreach (var vozilo in Vozila)
            {
                if (vozilo.IsSelected)
                {
                    PozarDAO.DodajVoziloNaIntervenciju(vozilo.Vozilo.ID, Pozar.ID);
                }
            }
            foreach (var smena in Smene)
            {
                if (smena.IsSelected)
                {
                    PozarDAO.DodajSmenuNaIntervenciju(smena.Smena.ID, Pozar.ID);
                }
            }
        }

        private void DodajVozilaISmeneZaTehnickuIntervencijuUBazuPodataka()
        {
            foreach (var vozilo in Vozila)
            {
                if (vozilo.IsSelected)
                {
                    TehnickaIntervencijaDAO.DodajVoziloNaIntervenciju(vozilo.Vozilo.ID, TehnickaIntervencija.ID);
                }
            }
            foreach (var smena in Smene)
            {
                if (smena.IsSelected)
                {
                    TehnickaIntervencijaDAO.DodajSmenuNaIntervenciju(smena.Smena.ID, TehnickaIntervencija.ID);
                }
            }
        }

        private void InicijalizacijaListeSmena() 
        {
            SmenaDAO smenaDAO = new SmenaDAO();
            var sveSmene = smenaDAO.GetList();
            Smene = new List<SmenaIsSelected>();
            if (Intervencija != null)
            {
                if (Intervencija.Tip == TipIntervencijeEnum.POZAR)
                {
                    foreach (var smena in sveSmene)
                    {
                        if (Pozar.Smene.Any(prod => prod.ID == smena.ID))
                        {
                            Smene.Add((new SmenaIsSelected { Smena = smena, IsSelected = true }));
                            continue;
                        }
                        Smene.Add((new SmenaIsSelected { Smena = smena, IsSelected = false }));
                    }
                }
                else if (Intervencija.Tip == TipIntervencijeEnum.TEHNICKA_INTERVENCIJA)
                {
                    foreach (var smena in sveSmene)
                    {
                        if (TehnickaIntervencija.Smene.Any(prod => prod.ID == smena.ID))
                        {
                            Smene.Add((new SmenaIsSelected { Smena = smena, IsSelected = true }));
                            continue;
                        }
                        Smene.Add((new SmenaIsSelected { Smena = smena, IsSelected = false }));
                    }
                }
            }
            else
            {
                foreach (var smena in sveSmene)
                {
                    Smene.Add((new SmenaIsSelected { Smena = smena, IsSelected = false }));
                }
            }
        }
        private void InicijalizacijaListeVozila()
        {
            VoziloDAO voziloDAO = new VoziloDAO();
            var svaVozila = voziloDAO.GetList();
            Vozila = new List<VoziloIsSelected>();
            if (Intervencija == null)
            {
                foreach (var vozilo in svaVozila)
                {
                    if (vozilo.Tip == TipVozila.NAVALNO && TipIntervencije == TipIntervencijeEnum.POZAR)
                    {
                        Vozila.Add(new VoziloIsSelected { Vozilo = vozilo, IsSelected = false });
                    }
                    else if (vozilo.Tip == TipVozila.TEHNICKO && TipIntervencije == TipIntervencijeEnum.TEHNICKA_INTERVENCIJA)
                    {
                        Vozila.Add(new VoziloIsSelected { Vozilo = vozilo, IsSelected = false });
                    }
                }
            }
            else
            {
                foreach (var vozilo in svaVozila)
                {
                    if (vozilo.Tip == TipVozila.NAVALNO && TipIntervencije == TipIntervencijeEnum.POZAR)
                    {
                        if (Pozar.Vozila.Any(prod => prod.ID == vozilo.ID))
                        {
                            Vozila.Add(new VoziloIsSelected { Vozilo = vozilo, IsSelected = true });
                            continue;
                        }
                        Vozila.Add(new VoziloIsSelected { Vozilo = vozilo, IsSelected = false });
                    }
                    else if (vozilo.Tip == TipVozila.TEHNICKO && TipIntervencije == TipIntervencijeEnum.TEHNICKA_INTERVENCIJA)
                    {
                        if (TehnickaIntervencija.Vozila.Any(prod => prod.ID == vozilo.ID))
                        {
                            Vozila.Add(new VoziloIsSelected { Vozilo = vozilo, IsSelected = true });
                            continue;
                        }
                        Vozila.Add(new VoziloIsSelected { Vozilo = vozilo, IsSelected = false });
                    }
                }
            }
        }

        private bool Validacija()
        {
            PorukaGreskeZaAdresu = "";
            PorukaGreskeZaOpstinu = "";
            PorukaGreskeZaDatum = "";
            PorukaGreskeZaVreme = "";
            bool ispravanUnos = true;
            
            if (string.IsNullOrEmpty(Adresa))
            {
                PorukaGreskeZaAdresu = "Unesite adresu!";
                ispravanUnos = false;
            }
            else if (!Adresa.All(c => char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)))
            {
                PorukaGreskeZaAdresu = "Adresa sme sadrzati samo slova i brojeve!";
                ispravanUnos = false;
            }
            else if (Adresa.Length < 6 || Adresa.Length > 30)
            {
                PorukaGreskeZaAdresu = "Adresa mora sadrzati od 6 do 30 karaktera!";
                ispravanUnos = false;
            }

            if (IzabranaOpstina == null)
            {
                PorukaGreskeZaOpstinu = "Izaberite opstinu!";
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
