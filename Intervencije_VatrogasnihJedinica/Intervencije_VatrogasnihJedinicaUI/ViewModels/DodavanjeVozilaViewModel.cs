using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using Intervencije_VatrogasnihJedinicaUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class DodavanjeVozilaViewModel : Screen
    {
        private VoziloDAO voziloDAO = new VoziloDAO();
        private TehnickoVoziloDAO tehnickoVoziloDAO = new TehnickoVoziloDAO();
        private NavalnoVoziloDAO navalnovoziloDAO = new NavalnoVoziloDAO();
        private AlatDAO alatDAO = new AlatDAO();
        private VatrogasnaJedinicaDAO jedinicaDAO = new VatrogasnaJedinicaDAO();
        private string porukaGreskeZaMarku = "";
        private string porukaGreskeZaModel = "";
        private string porukaGreskeZaGodiste = "";
        private string porukaGreskeZaNosivost = "";
        private string porukaGreskeZaVSJ = "";

        public DodavanjeVozilaViewModel(Vozilo vozilo)
        {
            TipoviVozila = Enum.GetValues(typeof(TipVozila)).Cast<TipVozila>().ToList();
            VatrogasneJedinice = jedinicaDAO.GetList();
            Vozilo = vozilo;
            Godiste = DateTime.Now.Year;
            if (vozilo != null)
            {
                Godiste = vozilo.Godiste;
                TipVozila = vozilo.Tip;
                InicijalizacijaVrednosti(vozilo);
            }
            InicijalizacijaListeGodista();
            InicijalizacijaListeAlata();
        }

        public ObservableCollection<AlatIsSelected> Alati { get; set; }
        public Vozilo Vozilo { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int Godiste { get; set; }
        public List<int> Godista { get; set; }
        private TipVozila tipVozila { get; set; }
        public TipVozila TipVozila { get => tipVozila; set { tipVozila = value; InicijalizacijaListeAlata(); NotifyOfPropertyChange(() => Alati); } }
        public IReadOnlyList<TipVozila> TipoviVozila { get; }
        public string Nosivost { get; set; }
        public List<VatrogasnaJedinica> VatrogasneJedinice { get; set; }
        public VatrogasnaJedinica IzabranaVatrogasnaJedinica { get; set; }
        public string PorukaGreskeZaMarku { get => porukaGreskeZaMarku; set { porukaGreskeZaMarku = value; NotifyOfPropertyChange(() => PorukaGreskeZaMarku); } }
        public string PorukaGreskeZaModel { get => porukaGreskeZaModel; set { porukaGreskeZaModel = value; NotifyOfPropertyChange(() => PorukaGreskeZaModel); } }
        public string PorukaGreskeZaGodiste { get => porukaGreskeZaGodiste; set { porukaGreskeZaGodiste = value; NotifyOfPropertyChange(() => PorukaGreskeZaGodiste); } }
        public string PorukaGreskeZaNosivost { get => porukaGreskeZaNosivost; set { porukaGreskeZaNosivost = value; NotifyOfPropertyChange(() => PorukaGreskeZaNosivost); } }
        public string PorukaGreskeZaVSJ { get => porukaGreskeZaVSJ; set { porukaGreskeZaVSJ = value; NotifyOfPropertyChange(() => PorukaGreskeZaVSJ); } }

        public void DodajIzmeni()
        {
            if (Validacija())
            {
                if (Vozilo == null)
                {
                    switch (TipVozila)
                    {
                        case (TipVozila.TEHNICKO):
                            Tehnicko_Vozilo vozilo = new Tehnicko_Vozilo
                            {
                                Marka = Marka,
                                Model = Model,
                                Tip = TipVozila,
                                Godiste = Godiste,
                                Nosivost = double.Parse(Nosivost),
                                Id_VatrogasneJedinice = IzabranaVatrogasnaJedinica.ID
                            };
                            vozilo = tehnickoVoziloDAO.Insert(vozilo);
                            foreach (var alat in Alati)
                            {
                                if (alat.IsSelected)
                                {
                                    voziloDAO.DodajAlatVozilu(alat.Alat.ID, vozilo.ID);
                                }
                            }
                            break;
                        case (TipVozila.NAVALNO):
                            Navalno_Vozilo navalnoVozilo = new Navalno_Vozilo
                            {
                                Marka = Marka,
                                Model = Model,
                                Tip = TipVozila,
                                Godiste = Godiste,
                                Nosivost = double.Parse(Nosivost),
                                Id_VatrogasneJedinice = IzabranaVatrogasnaJedinica.ID
                            };
                            navalnoVozilo = navalnovoziloDAO.Insert(navalnoVozilo);
                            foreach (var alat in Alati)
                            {
                                if (alat.IsSelected)
                                {
                                    voziloDAO.DodajAlatVozilu(alat.Alat.ID, navalnoVozilo.ID);
                                }
                            }
                            break;
                    }
                }
                else
                {
                    switch (TipVozila)
                    {
                        case (TipVozila.TEHNICKO):
                            Tehnicko_Vozilo tehnickoVozilo = new Tehnicko_Vozilo
                            {
                                ID = Vozilo.ID,
                                Marka = Marka,
                                Model = Model,
                                Tip = TipVozila,
                                Godiste = Godiste,
                                Nosivost = double.Parse(Nosivost),
                                Id_VatrogasneJedinice = IzabranaVatrogasnaJedinica.ID
                            };
                            tehnickoVoziloDAO.Update(tehnickoVozilo);
                            voziloDAO.UkloniAlateIzVozila(Vozilo.ID);
                            foreach (var alat in Alati)
                            {
                                if (alat.IsSelected)
                                {
                                    voziloDAO.DodajAlatVozilu(alat.Alat.ID, Vozilo.ID);
                                }
                            }
                            break;
                        case (TipVozila.NAVALNO):
                            Navalno_Vozilo navalnoVozilo = new Navalno_Vozilo
                            {
                                ID = Vozilo.ID,
                                Marka = Marka,
                                Model = Model,
                                Tip = TipVozila,
                                Godiste = Godiste,
                                Nosivost = double.Parse(Nosivost),
                                Id_VatrogasneJedinice = IzabranaVatrogasnaJedinica.ID
                            };
                            navalnovoziloDAO.Update(navalnoVozilo);
                            voziloDAO.UkloniAlateIzVozila(Vozilo.ID);
                            foreach (var alat in Alati)
                            {
                                if (alat.IsSelected)
                                {
                                    voziloDAO.DodajAlatVozilu(alat.Alat.ID, Vozilo.ID);
                                }
                            }
                            break;
                    }
                }
                TryClose();
            }
        }

        private void InicijalizacijaListeGodista()
        {
            Godista = new List<int>();
            var godina = DateTime.Now.Year;
            for (int i = 40; i > 0; i--)
            {
                Godista.Add(godina);
                godina--;
            }
        }

        private void InicijalizacijaListeAlata()
        {
            List<Alat> sviAlati = new List<Alat>();
            Alati = new ObservableCollection<AlatIsSelected>();
            if (TipVozila == TipVozila.NAVALNO)
            {
                sviAlati = alatDAO.AlatiZaNavalnaVozila();
            }
            else if (TipVozila == TipVozila.TEHNICKO)
            {
                sviAlati = alatDAO.AlatiZaTehnickaVozila();
            }
            if (Vozilo != null)
            {
                foreach (var alat in sviAlati)
                {
                    if (Vozilo.Alati.Any(prod => prod.ID == alat.ID))
                    {
                        Alati.Add(new AlatIsSelected { Alat = alat, IsSelected = true });
                        continue;
                    }
                    Alati.Add(new AlatIsSelected { Alat = alat, IsSelected = false });
                }
            }
            else
            {
                foreach (var alat in sviAlati)
                {
                    Alati.Add(new AlatIsSelected { Alat = alat, IsSelected = false });
                }
            }
        }

        private void InicijalizacijaVrednosti(Vozilo vozilo)
        {
            Marka = vozilo.Marka;
            Model = vozilo.Model;
            TipVozila = vozilo.Tip;
            NotifyOfPropertyChange(() => TipVozila);
            Godiste = vozilo.Godiste;
            NotifyOfPropertyChange(() => Godiste);
            Nosivost = vozilo.Nosivost.ToString();
            IzabranaVatrogasnaJedinica = VatrogasneJedinice.Find(x => x.ID == vozilo.Id_VatrogasneJedinice);
            NotifyOfPropertyChange(() => IzabranaVatrogasnaJedinica);
        }

        private bool Validacija()
        {
            bool ispravanUnos = true;
            PorukaGreskeZaMarku = "";
            PorukaGreskeZaModel = "";
            PorukaGreskeZaGodiste = "";
            PorukaGreskeZaNosivost = "";
            PorukaGreskeZaVSJ = "";
            if (string.IsNullOrEmpty(Marka))
            {
                PorukaGreskeZaMarku = "Unesite marku!";
                ispravanUnos = false;
            }
            else if (!Marka.All(c => char.IsWhiteSpace(c) || char.IsLetter(c)))
            {
                PorukaGreskeZaMarku = "Marka sme sadržati samo slova!";
                ispravanUnos = false;
            }
            else if (Marka.Length < 3 || Marka.Length > 20)
            {
                PorukaGreskeZaMarku = "Naziv mora sadržati od 3 do 20 slova!";
                ispravanUnos = false;
            }

            if (string.IsNullOrEmpty(Model))
            {
                PorukaGreskeZaModel = "Unesite model!";
                ispravanUnos = false;
            }
            else if (!Model.All(c => char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)))
            {
                PorukaGreskeZaModel = "Naziv modela sadrži nedozvoljene karaktere!";
                ispravanUnos = false;
            }
            else if (Model.Length < 3 || Model.Length > 20)
            {
                PorukaGreskeZaModel = "Naziv mora sadržati od 3 do 20 slova!";
                ispravanUnos = false;
            }

            if (Godiste < 1960 || Godiste > DateTime.Now.Year)
            {
                PorukaGreskeZaGodiste = "Nije izabrano prihvatljivo godište!";
                ispravanUnos = false;
            }

            if (string.IsNullOrEmpty(Nosivost))
            {
                PorukaGreskeZaNosivost = "Unesite podatak o nosivosti vozila!";
                ispravanUnos = false;
            }
            else if (!Nosivost.All(c => char.IsDigit(c) || char.IsPunctuation(c)))
            {
                PorukaGreskeZaNosivost = "Mora sadržati samo brojeve!";
                ispravanUnos = false;
            }
            else if (double.Parse(Nosivost) < 1000 || double.Parse(Nosivost) > 12000)
            {
                PorukaGreskeZaNosivost = "Samo u intervalu od 1000kg do 12000kg!";
                ispravanUnos = false;
            }

            if (IzabranaVatrogasnaJedinica == null)
            {
                PorukaGreskeZaVSJ = "Izaberite vatrogasnu jedinicu!";
                ispravanUnos = false;
            }
            return ispravanUnos;
        }
    }
}
