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
    
    public class DodavanjeVozilaViewModel : Screen
    {
        public DodavanjeVozilaViewModel()
        {
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

        public string Marka { get; set; }
        public string Model { get; set; }
        public int Godiste { get; set; }

        public List<int> Godista { get; set; }

        public TipVozila TipVozila { get; set; }

        public IReadOnlyList<TipVozila> TipoviVozila { get; }

        public string Nosivost { get; set; }

        public List<VatrogasnaJedinica> VatrogasneJedinice { get; set; }

        public VatrogasnaJedinica IzabranaVatrogasnaJedinica { get; set; }

        public void Dodaj()
        {
           
            switch (TipVozila)
            {
                case(TipVozila.TEHNICKO):
                    Tehnicko_Vozilo vozilo = new Tehnicko_Vozilo {Marka = Marka, Model = Model, Tip = TipVozila, Godiste = Godiste, Nosivost = int.Parse(Nosivost), Id_VatrogasneJedinice = IzabranaVatrogasnaJedinica.ID };
                    TehnickoVoziloDAO voziloDAO = new TehnickoVoziloDAO();
                    voziloDAO.Insert(vozilo);
                    break;
                case(TipVozila.NAVALNO):
                    Navalno_Vozilo navalnoVozilo = new Navalno_Vozilo { Marka = Marka, Model = Model, Tip = TipVozila, Godiste = Godiste, Nosivost = int.Parse(Nosivost), Id_VatrogasneJedinice = IzabranaVatrogasnaJedinica.ID };
                    NavalnoVoziloDAO navalnovoziloDAO = new NavalnoVoziloDAO();
                    navalnovoziloDAO.Insert(navalnoVozilo);
                    break;

            }
            TryClose();
        }


    }
}
