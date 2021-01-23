using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public enum TipIntervencijeEnum { POZAR , TEHNICKA_INTERVENCIJA }
    public class DodavanjeIntervencijeViewModel : Screen
    {
        public DodavanjeIntervencijeViewModel()
        {
            TipoviIntervencije = Enum.GetValues(typeof(TipIntervencijeEnum)).Cast<TipIntervencijeEnum>().ToList();
            OpstinaDAO opstinaDAO = new OpstinaDAO();
            Opstine = opstinaDAO.GetList();
            Sati = DateTime.Now.Hour;
            Minuti = DateTime.Now.Minute;
            Datum = DateTime.Now;
        }
        public IReadOnlyList<TipIntervencijeEnum> TipoviIntervencije { get; }
        public TipIntervencijeEnum TipIntervencije { get; set; }
        public List<Opstina> Opstine { get; set; }
        private DateTime datum;
        public DateTime Datum { get { return datum; } set { datum = value; NotifyOfPropertyChange(() => datum); } }
        public int Sati { get; set; }
        public int Minuti { get; set; }
        public string Adresa { get; set; }
        public Opstina IzabranaOpstina { get; set; }

        public void Dodaj()
        {
            Datum = new DateTime(Datum.Year,Datum.Month,Datum.Day,Sati,Minuti,0);
            switch (TipIntervencije)
            {
                case (TipIntervencijeEnum.POZAR):
                    PozarDAO pozarDAO = new PozarDAO();
                    Pozar pozar = new Pozar();
                    pozar.Datum_I_Vreme = Datum;
                    pozar.Adresa = Adresa;
                    pozar.Id_Opstine = IzabranaOpstina.ID;
                    pozarDAO.Insert(pozar);
                    break;
                case (TipIntervencijeEnum.TEHNICKA_INTERVENCIJA):
                    TehnickaIntervencijaDAO tehnickaIntervencijaDAO = new TehnickaIntervencijaDAO();
                    Tehnicka_Intervencija tehnicka_Intervencija = new Tehnicka_Intervencija();
                    tehnicka_Intervencija.Datum_I_Vreme = Datum;
                    tehnicka_Intervencija.Adresa = Adresa;
                    tehnicka_Intervencija.Id_Opstine = IzabranaOpstina.ID;
                    tehnickaIntervencijaDAO.Insert(tehnicka_Intervencija);
                    break;
            }
            TryClose();
        }
    }
}
