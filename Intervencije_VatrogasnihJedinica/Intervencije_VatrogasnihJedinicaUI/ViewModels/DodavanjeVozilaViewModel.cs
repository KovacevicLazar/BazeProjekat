using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using Intervencije_VatrogasnihJedinicaUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class DodavanjeVozilaViewModel : Screen
    {
        public DodavanjeVozilaViewModel(Vozilo vozilo)
        {
            AlatDAO alatDAO = new AlatDAO();
            var sviAlati = alatDAO.GetList();
            Alati = new List<AlatIsSelected>();
            if (vozilo != null)
            {
                Vozilo = vozilo;
                InicijalizacijaVrednosti(vozilo);
                foreach (var alat in sviAlati)
                {
                    if (vozilo.Alati.Any(prod => prod.ID == alat.ID))
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
            
            TipoviVozila = Enum.GetValues(typeof(TipVozila)).Cast<TipVozila>().ToList();
            var jedinicaDAO = new VatrogasnaJedinicaDAO();
            VatrogasneJedinice = jedinicaDAO.GetList();
            Godista = new List<int>();
            var godina = DateTime.Now.Year;
            for (int i = 40; i > 0; i--)
            {
                Godista.Add(godina);
                godina--;
            }
        }
        public List<AlatIsSelected> Alati { get; set; }
        public Vozilo Vozilo { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int Godiste { get; set; }
        public List<int> Godista { get; set; }
        public TipVozila TipVozila { get; set; }
        public IReadOnlyList<TipVozila> TipoviVozila { get; }
        public double Nosivost { get; set; }
        public List<VatrogasnaJedinica> VatrogasneJedinice { get; set; }
        public VatrogasnaJedinica IzabranaVatrogasnaJedinica { get; set; }

        private string porukaGreskeZaMarku = "";
        private string porukaGreskeZaModel = "";
        private string porukaGreskeZaGodiste = "";
        private string porukaGreskeZaNosivost = "";
        private string porukaGreskeZaVSJ = "";
        public string PorukaGreskeZaMarku { get => porukaGreskeZaMarku; set { porukaGreskeZaMarku = value; NotifyOfPropertyChange(() => PorukaGreskeZaMarku); } }
        public string PorukaGreskeZaModel { get => porukaGreskeZaModel; set { porukaGreskeZaModel = value; NotifyOfPropertyChange(() => PorukaGreskeZaModel); } }
        public string PorukaGreskeZaGodiste { get => porukaGreskeZaGodiste; set { porukaGreskeZaGodiste = value; NotifyOfPropertyChange(() => PorukaGreskeZaGodiste); } }
        public string PorukaGreskeZaNosivost { get => porukaGreskeZaNosivost; set { porukaGreskeZaNosivost = value; NotifyOfPropertyChange(() => PorukaGreskeZaNosivost); } }
        public string PorukaGreskeZaVSJ { get => porukaGreskeZaVSJ; set { porukaGreskeZaVSJ = value; NotifyOfPropertyChange(() => PorukaGreskeZaVSJ); } }

        public void DodajIzmeni()
        {
            if (Validacija())
            {
                VoziloDAO voziloDAO = new VoziloDAO();
                TehnickoVoziloDAO tehnickoVoziloDAO = new TehnickoVoziloDAO();
                NavalnoVoziloDAO navalnovoziloDAO = new NavalnoVoziloDAO();
                if (Vozilo == null)
                {
                    switch (TipVozila)
                    {
                        case (TipVozila.TEHNICKO):
                            Tehnicko_Vozilo vozilo = new Tehnicko_Vozilo { Marka = Marka, Model = Model, Tip = TipVozila, Godiste = Godiste, Nosivost = Nosivost, Id_VatrogasneJedinice = IzabranaVatrogasnaJedinica.ID };
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
                            Navalno_Vozilo navalnoVozilo = new Navalno_Vozilo { Marka = Marka, Model = Model, Tip = TipVozila, Godiste = Godiste, Nosivost = Nosivost, Id_VatrogasneJedinice = IzabranaVatrogasnaJedinica.ID };
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
                            Tehnicko_Vozilo tehnickoVozilo = new Tehnicko_Vozilo { ID = Vozilo.ID, Marka = Marka, Model = Model, Tip = TipVozila, Godiste = Godiste, Nosivost = Nosivost, Id_VatrogasneJedinice = IzabranaVatrogasnaJedinica.ID };
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
                            Navalno_Vozilo navalnoVozilo = new Navalno_Vozilo { ID = Vozilo.ID, Marka = Marka, Model = Model, Tip = TipVozila, Godiste = Godiste, Nosivost = Nosivost, Id_VatrogasneJedinice = IzabranaVatrogasnaJedinica.ID };
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

        private void InicijalizacijaVrednosti(Vozilo vozilo)
        {
            Marka = vozilo.Marka;
            Model = vozilo.Model;
            TipVozila = vozilo.Tip;
            NotifyOfPropertyChange(() => TipVozila);
            Godiste = vozilo.Godiste;
            NotifyOfPropertyChange(() => Godiste);
            Nosivost = vozilo.Nosivost;
            IzabranaVatrogasnaJedinica = vozilo.VatrogasnaJedinica;
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
                PorukaGreskeZaMarku = "Marka sme sadrzati samo slova!";
                ispravanUnos = false;
            }
            else if (Marka.Length < 3 || Marka.Length > 20)
            {
                PorukaGreskeZaMarku = "Naziv mora sadrzati od 3 do 20 slova!";
                ispravanUnos = false;
            }

            if (string.IsNullOrEmpty(Model))
            {
                PorukaGreskeZaModel = "Unesite model!";
                ispravanUnos = false;
            }
            else if (!Model.All(c => char.IsWhiteSpace(c) || char.IsLetterOrDigit(c)))
            {
                PorukaGreskeZaModel = "Naziv modela sadrzi nedozvoljene karaktere!";
                ispravanUnos = false;
            }
            else if (Model.Length <3 || Model.Length > 20)
            {
                PorukaGreskeZaModel = "Naziv mora sadrzati od 3 do 20 slova!";
                ispravanUnos = false;
            }
             
            if (Godiste < 1960 || Godiste > DateTime.Now.Year)
            {
                PorukaGreskeZaGodiste = "Nije izabrano prihvatljivo godiste!";
                ispravanUnos = false;
            }

            if (Nosivost < 1000 || Nosivost > 12000)
            {
                PorukaGreskeZaNosivost = "Samo u intervalu od 1000kg do 12000kg";
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
