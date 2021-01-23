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
        public DodavanjeRadnikaViewModel()
        {
            Pozicije = Enum.GetValues(typeof(RadnoMesto)).Cast<RadnoMesto>().ToList();
            var jedinicaDAO = new VatrogasnaJedinicaDAO();
            VatrogasneJedinice = jedinicaDAO.GetList();
            var smenaDAO = new SmenaDAO();
            Smene = smenaDAO.GetList();
        }

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Jmbg { get; set; }
        public int RadniStaz { get; set; }
        public RadnoMesto RadnaPozicija { get; set; }
        public IReadOnlyList<RadnoMesto> Pozicije { get; }
        public List<VatrogasnaJedinica> VatrogasneJedinice { get; set; }
        public VatrogasnaJedinica IzabranaVatrogasnaJedinica { get; set; }
        public List<Smena> Smene { get; set; }
        public Smena IzabranaSmena { get; set; }

        public void Dodaj()
        {
            Radnik radnik = new Radnik { Ime = Ime, Prezime = Prezime, Godine_Rada = RadniStaz, JMBG = Jmbg, Radno_Mesto = RadnaPozicija };
            radnik.VatrogasnaJedinicaID = IzabranaVatrogasnaJedinica.ID;
            radnik.SmenaID = IzabranaSmena.ID;
            RadnikDAO radnikDAO = new RadnikDAO();
            radnikDAO.Insert(radnik);
            TryClose();
        }
    }
}
