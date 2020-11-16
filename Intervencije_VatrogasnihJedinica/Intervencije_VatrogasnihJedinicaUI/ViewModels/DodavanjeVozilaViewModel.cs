using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public enum TipoviVozilaEnum { TEHNICKO, NAVALNO, CISTERNA }
    public class DodavanjeVozilaViewModel : Screen
    {
        public DodavanjeVozilaViewModel()
        {
            TipoviVozila = Enum.GetValues(typeof(TipoviVozilaEnum)).Cast<TipoviVozilaEnum>().ToList();
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

        public string Marka { get; set; }
        public string Model { get; set; }
        public int Godiste { get; set; }

        public List<int> Godista { get; set; }

        public TipoviVozilaEnum TipVozila { get; set; }

        public IReadOnlyList<TipoviVozilaEnum> TipoviVozila { get; }

        public string Nosivost { get; set; }

        public List<VatrogasnaJedinica> VatrogasneJedinice { get; set; }

        public VatrogasnaJedinica IzabranaVatrogasnaJedinica { get; set; }

        public void Dodaj()
        {
           
            switch (TipVozila)
            {
                case(TipoviVozilaEnum.TEHNICKO):
                    Tehnicko_Vozilo vozilo = new Tehnicko_Vozilo();
                    vozilo.Model = Model;
                    vozilo.Marka = Marka;
                    vozilo.Godiste = Godiste;
                    vozilo.Nosivost = int.Parse(Nosivost);
                    vozilo.Tip = (int)TipVozila;
                    vozilo.Id_VatrogasneJedinice = IzabranaVatrogasnaJedinica.Id_VSJ;
                    TehnickoVoziloDAO voziloDAO = new TehnickoVoziloDAO();
                    voziloDAO.Insert(vozilo);
                    break;
                case(TipoviVozilaEnum.NAVALNO):
                    Navalno_Vozilo navalnoVozilo = new Navalno_Vozilo();
                    navalnoVozilo.Model = Model;
                    navalnoVozilo.Marka = Marka;
                    navalnoVozilo.Godiste = Godiste;
                    navalnoVozilo.Nosivost = int.Parse(Nosivost);
                    navalnoVozilo.Tip = (int)TipVozila;
                    navalnoVozilo.VatrogasnaJedinica = IzabranaVatrogasnaJedinica;
                    NavalnoVoziloDAO navalnovoziloDAO = new NavalnoVoziloDAO();
                    navalnovoziloDAO.Insert(navalnoVozilo);
                    break;

            }
            TryClose();
        }


    }
}
