using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
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

            if(intervencija !=null)
            {
                Sati = intervencija.Datum_I_Vreme.Hour;
                Minuti = intervencija.Datum_I_Vreme.Minute;
                Datum = intervencija.Datum_I_Vreme.Date;
                Adresa = intervencija.Adresa;
                IzabranaOpstina = intervencija.Opstina;
                TipIntervencije = intervencija.Tip; 
            }
            else
            {
                Sati = DateTime.Now.Hour;
                Minuti = DateTime.Now.Minute;
                Datum = DateTime.Now;
            }
        }
        public Intervencija Intervencija { get; set; }
        private string porukaGreskeZaAdresu = "";
        private string porukaGreskeZaOpstinu = "";
        private string porukaGreskeZaDatum = "";
        private string porukaGreskeZaVreme = "";
        public IReadOnlyList<TipIntervencijeEnum> TipoviIntervencije { get; }
        public TipIntervencijeEnum TipIntervencije { get; set; }
        public List<Opstina> Opstine { get; set; }
        private DateTime datum;
        public DateTime Datum { get { return datum; } set { datum = value; NotifyOfPropertyChange(() => datum); } }
        public int Sati { get; set; }
        public int Minuti { get; set; }
        public string Adresa { get; set; }
        public Opstina IzabranaOpstina { get; set; }
        public string PorukaGreskeZaVreme { get => porukaGreskeZaVreme; set { porukaGreskeZaVreme = value; NotifyOfPropertyChange(() => PorukaGreskeZaVreme);  } }
        public string PorukaGreskeZaDatum { get => porukaGreskeZaDatum; set { porukaGreskeZaDatum = value; NotifyOfPropertyChange(() => PorukaGreskeZaDatum); } }
        public string PorukaGreskeZaOpstinu { get => porukaGreskeZaOpstinu; set { porukaGreskeZaOpstinu = value; NotifyOfPropertyChange(() => PorukaGreskeZaOpstinu); } }
        public string PorukaGreskeZaAdresu { get => porukaGreskeZaAdresu; set { porukaGreskeZaAdresu = value; NotifyOfPropertyChange(() => PorukaGreskeZaAdresu); } }

        public void DodajIzmeni()
        {
            if (Validacija())
            {
                Datum = new DateTime(Datum.Year, Datum.Month, Datum.Day, Sati, Minuti, 0);
                PozarDAO pozarDAO = new PozarDAO();
                Pozar pozar;
                TehnickaIntervencijaDAO tehnickaIntervencijaDAO = new TehnickaIntervencijaDAO();
                Tehnicka_Intervencija tehnicka_Intervencija;
                if(Intervencija == null)
                {
                    switch (TipIntervencije)
                    {
                        case (TipIntervencijeEnum.POZAR):
                            pozar = new Pozar { Tip = TipIntervencije, Adresa = Adresa, Datum_I_Vreme = Datum, Id_Opstine = IzabranaOpstina.ID };
                            pozarDAO.Insert(pozar);
                            break;
                        case (TipIntervencijeEnum.TEHNICKA_INTERVENCIJA):
                            tehnicka_Intervencija = new Tehnicka_Intervencija { Tip = TipIntervencije, Adresa = Adresa, Datum_I_Vreme = Datum, Id_Opstine = IzabranaOpstina.ID };
                            tehnickaIntervencijaDAO.Insert(tehnicka_Intervencija);
                            break;
                    }
                }
                else
                {
                    switch (TipIntervencije)
                    {
                        case (TipIntervencijeEnum.POZAR):
                            pozar = new Pozar { ID=Intervencija.ID, Tip = TipIntervencije, Adresa = Adresa, Datum_I_Vreme = Datum, Id_Opstine = IzabranaOpstina.ID };
                            pozarDAO.Update(pozar);
                            break;
                        case (TipIntervencijeEnum.TEHNICKA_INTERVENCIJA):
                            tehnicka_Intervencija = new Tehnicka_Intervencija { ID = Intervencija.ID, Tip = TipIntervencije, Adresa = Adresa, Datum_I_Vreme = Datum, Id_Opstine = IzabranaOpstina.ID };
                            tehnickaIntervencijaDAO.Update(tehnicka_Intervencija);
                            break;
                    }
                }
                
                TryClose();
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
