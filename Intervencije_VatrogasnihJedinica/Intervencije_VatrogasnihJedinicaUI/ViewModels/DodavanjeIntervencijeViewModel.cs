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
    public class DodavanjeIntervencijeViewModel : Screen
    {
        private PozarDAO pozarDAO = new PozarDAO();
        private TehnickaIntervencijaDAO tehnickaIntervencijaDAO = new TehnickaIntervencijaDAO();
        private OpstinaDAO opstinaDAO = new OpstinaDAO();
        private string porukaGreskeZaAdresu = "";
        private string porukaGreskeZaOpstinu = "";
        private string porukaGreskeZaDatum = "";
        private string porukaGreskeZaVreme = "";
        private string porukaGreskeZaSmeneIVozila = "";
        private DateTime datum = DateTime.Now;
        private int sati = DateTime.Now.Hour;
        private int minuti = DateTime.Now.Minute;
        private TipIntervencijeEnum tipIntervencije;
        private Opstina izabranaOpstina;
        private ObservableCollection<SmenaIsSelected> smene = new ObservableCollection<SmenaIsSelected>();
        private ObservableCollection<VoziloIsSelected> vozila = new ObservableCollection<VoziloIsSelected>();

        public DodavanjeIntervencijeViewModel(Intervencija intervencija)
        {
            Pozar = new Pozar();
            TehnickaIntervencija = new Tehnicka_Intervencija();
            Intervencija = intervencija;
            TipoviIntervencije = Enum.GetValues(typeof(TipIntervencijeEnum)).Cast<TipIntervencijeEnum>().ToList();
            Opstine = opstinaDAO.GetList();
            if (Opstine.Count != 0)
            {
                izabranaOpstina = Opstine[0];
            }

            if (intervencija != null)
            {
                Sati = intervencija.Datum_I_Vreme.Hour;
                Minuti = intervencija.Datum_I_Vreme.Minute;
                Datum = intervencija.Datum_I_Vreme.Date;
                Adresa = intervencija.Adresa;
                IzabranaOpstina = Opstine.Find(x => x.ID == intervencija.Id_Opstine);
                NotifyOfPropertyChange(() => IzabranaOpstina);
                TipIntervencije = intervencija.Tip;
                if (TipIntervencije == TipIntervencijeEnum.POZAR)
                {
                    Pozar = pozarDAO.FindById(intervencija.ID);
                }
                else if (TipIntervencije == TipIntervencijeEnum.TEHNICKA_INTERVENCIJA)
                {
                    TehnickaIntervencija = tehnickaIntervencijaDAO.FindById(intervencija.ID);
                }
            }

            InicijalizacijaListeVozila();
            InicijalizacijaListeSmena();
        }

        public Pozar Pozar { get; set; }
        public Tehnicka_Intervencija TehnickaIntervencija { get; set; }
        public Intervencija Intervencija { get; set; }
        public IReadOnlyList<TipIntervencijeEnum> TipoviIntervencije { get; }
        public TipIntervencijeEnum TipIntervencije { get => tipIntervencije; set { tipIntervencije = value; InicijalizacijaListeVozila(); } }
        public List<Opstina> Opstine { get; set; }
        public DateTime Datum { get { return datum; } set { datum = new DateTime(value.Year, value.Month, value.Day, Sati, Minuti, 0); NotifyOfPropertyChange(() => datum); InicijalizacijaListeSmena(); } }
        public int Minuti { get => minuti; set { minuti = value; Datum = new DateTime(Datum.Year, Datum.Month, Datum.Day, Sati, Minuti, 0); } }
        public int Sati { get => sati; set { sati = value; Datum = new DateTime(Datum.Year, Datum.Month, Datum.Day, Sati, Minuti, 0); } }
        public string Adresa { get; set; }
        public Opstina IzabranaOpstina { get => izabranaOpstina; set { izabranaOpstina = value; InicijalizacijaListeSmena(); InicijalizacijaListeVozila(); } }
        public ObservableCollection<VoziloIsSelected> Vozila { get => vozila; set { vozila = value; NotifyOfPropertyChange(() => Vozila); } }
        public ObservableCollection<SmenaIsSelected> Smene { get => smene; set { smene = value; NotifyOfPropertyChange(() => Smene); } }
        public string PorukaGreskeZaVreme { get => porukaGreskeZaVreme; set { porukaGreskeZaVreme = value; NotifyOfPropertyChange(() => PorukaGreskeZaVreme); } }
        public string PorukaGreskeZaDatum { get => porukaGreskeZaDatum; set { porukaGreskeZaDatum = value; NotifyOfPropertyChange(() => PorukaGreskeZaDatum); } }
        public string PorukaGreskeZaOpstinu { get => porukaGreskeZaOpstinu; set { porukaGreskeZaOpstinu = value; NotifyOfPropertyChange(() => PorukaGreskeZaOpstinu); } }
        public string PorukaGreskeZaAdresu { get => porukaGreskeZaAdresu; set { porukaGreskeZaAdresu = value; NotifyOfPropertyChange(() => PorukaGreskeZaAdresu); } }
        public string PorukaGreskeZaSmeneIVozila { get => porukaGreskeZaSmeneIVozila; set { porukaGreskeZaSmeneIVozila = value; NotifyOfPropertyChange(() => PorukaGreskeZaSmeneIVozila); } }

        public void DodajIzmeni()
        {
            if (Validacija())
            {
                if (Intervencija == null)
                {
                    switch (TipIntervencije)
                    {
                        case (TipIntervencijeEnum.POZAR):
                            Pozar = new Pozar { Tip = TipIntervencije, Adresa = Adresa, Datum_I_Vreme = Datum, Id_Opstine = IzabranaOpstina.ID };
                            pozarDAO.Insert(Pozar);
                            DodajVozilaISmeneZaPozarUBazuPodataka();
                            break;
                        case (TipIntervencijeEnum.TEHNICKA_INTERVENCIJA):
                            TehnickaIntervencija = new Tehnicka_Intervencija { Tip = TipIntervencije, Adresa = Adresa, Datum_I_Vreme = Datum, Id_Opstine = IzabranaOpstina.ID };
                            tehnickaIntervencijaDAO.Insert(TehnickaIntervencija);
                            DodajVozilaISmeneZaTehnickuIntervencijuUBazuPodataka();
                            break;
                    }
                }
                else
                {
                    switch (TipIntervencije)
                    {
                        case (TipIntervencijeEnum.POZAR):
                            Pozar = new Pozar { ID = Intervencija.ID, Tip = TipIntervencije, Adresa = Adresa, Datum_I_Vreme = Datum, Id_Opstine = IzabranaOpstina.ID };
                            pozarDAO.Update(Pozar);
                            pozarDAO.UkloniVozilaSaIntervencije(Pozar.ID);
                            pozarDAO.UkloniSmeneSaIntervencije(Pozar.ID);
                            DodajVozilaISmeneZaPozarUBazuPodataka();
                            break;
                        case (TipIntervencijeEnum.TEHNICKA_INTERVENCIJA):
                            TehnickaIntervencija = new Tehnicka_Intervencija { ID = Intervencija.ID, Tip = TipIntervencije, Adresa = Adresa, Datum_I_Vreme = Datum, Id_Opstine = IzabranaOpstina.ID };
                            tehnickaIntervencijaDAO.Update(TehnickaIntervencija);
                            tehnickaIntervencijaDAO.UkloniVozilaSaIntervencije(TehnickaIntervencija.ID);
                            tehnickaIntervencijaDAO.UkloniSmeneSaIntervencije(TehnickaIntervencija.ID);
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
                    pozarDAO.DodajVoziloNaIntervenciju(vozilo.Vozilo.ID, Pozar.ID);
                }
            }
            foreach (var smena in Smene)
            {
                if (smena.IsSelected)
                {
                    pozarDAO.DodajSmenuNaIntervenciju(smena.Smena.ID, Pozar.ID);
                }
            }
        }

        private void DodajVozilaISmeneZaTehnickuIntervencijuUBazuPodataka()
        {
            foreach (var vozilo in Vozila)
            {
                if (vozilo.IsSelected)
                {
                    tehnickaIntervencijaDAO.DodajVoziloNaIntervenciju(vozilo.Vozilo.ID, TehnickaIntervencija.ID);
                }
            }
            foreach (var smena in Smene)
            {
                if (smena.IsSelected)
                {
                    tehnickaIntervencijaDAO.DodajSmenuNaIntervenciju(smena.Smena.ID, TehnickaIntervencija.ID);
                }
            }
        }

        private void InicijalizacijaListeSmena()
        {
            Smene.Clear();
            if (ValidacijaZaDatumIVreme())
            {
                SmenaDAO smenaDAO = new SmenaDAO();
                List<Smena> sveSmene = izabranaOpstina == null ? smenaDAO.ListaDezurnihSmenaNaDatum(Datum) : smenaDAO.ListaDezurnihSmenaNaDatumZaOpstinu(Datum, IzabranaOpstina.ID);
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
        }

        private void InicijalizacijaListeVozila()
        {
            VoziloDAO voziloDAO = new VoziloDAO();
            var svaVozila = izabranaOpstina == null ? voziloDAO.GetList() : voziloDAO.ListaVozilaZaIzabranuOpstinu(IzabranaOpstina.ID);
            Vozila.Clear();
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

        private bool ValidacijaSmeneIVozila()
        {
            porukaGreskeZaSmeneIVozila = "";
            Dictionary<int, VatrogasnaJedinica> vatrogasneJediniceSelektovanihSmena = new Dictionary<int, VatrogasnaJedinica>();
            Dictionary<int, VatrogasnaJedinica> vatrogasneJediniceSelektovanihVozila = new Dictionary<int, VatrogasnaJedinica>();
            foreach (var smena in Smene)
            {
                if (smena.IsSelected)
                    vatrogasneJediniceSelektovanihSmena[smena.Smena.VatrogasnaJedinicaID] = smena.Smena.VatrogasnaJedinica;
            }
            foreach (var vozilo in Vozila)
            {
                if (vozilo.IsSelected)
                    vatrogasneJediniceSelektovanihVozila[vozilo.Vozilo.VatrogasnaJedinica.ID] = vozilo.Vozilo.VatrogasnaJedinica;
            }

            if (vatrogasneJediniceSelektovanihSmena.Count() == 0 || vatrogasneJediniceSelektovanihVozila.Count() == 0)
            {
                PorukaGreskeZaSmeneIVozila = "Morate izabrati bar jednu smenu, i bar jedno vozilo iz iste vatrogasne jedinice!";
                return false;
            }

            if (vatrogasneJediniceSelektovanihSmena.Count() != vatrogasneJediniceSelektovanihVozila.Count())
            {
                PorukaGreskeZaSmeneIVozila = "Za svaku izabranu smenu morate selektovati i bar jedno vozilo iz iste vatrogasne jedinice!";
                return false;
            }

            foreach (var IdVatrogasneJedinice in vatrogasneJediniceSelektovanihVozila.Keys)
            {
                if (!vatrogasneJediniceSelektovanihSmena.ContainsKey(IdVatrogasneJedinice))
                {
                    PorukaGreskeZaSmeneIVozila = "Za svaku izabranu smenu morate selektovati i bar jedno vozilo iz iste vatrogasne jedinice!";
                    return false;
                }
            }
            return true;
        }

        private bool ValidacijaZaDatumIVreme()
        {
            PorukaGreskeZaDatum = "";
            PorukaGreskeZaVreme = "";
            if (Datum > DateTime.Now)
            {
                PorukaGreskeZaDatum = "Moguce je izabrati samo datum koji je prosao!";
                PorukaGreskeZaVreme = "Neispravan datum i vreme!";
                return false;
            }
            else if (Datum.Year < DateTime.Now.Year - 5)
            {
                PorukaGreskeZaDatum = "Nije moguce uneti podatke starije od 5 godina!";
                return false;
            }
            return true;
        }

        private bool Validacija()
        {
            PorukaGreskeZaAdresu = "";
            PorukaGreskeZaOpstinu = "";
            PorukaGreskeZaDatum = "";
            PorukaGreskeZaVreme = "";
            bool ispravanUnos = ValidacijaZaDatumIVreme() && ValidacijaSmeneIVozila();

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
            return ispravanUnos;
        }
    }
}
