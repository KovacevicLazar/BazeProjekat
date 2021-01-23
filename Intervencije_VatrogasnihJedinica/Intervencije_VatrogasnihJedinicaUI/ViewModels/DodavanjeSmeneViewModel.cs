using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System.Collections.Generic;
using Caliburn.Micro;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class DodavanjeSmeneViewModel : Screen
    {
        public DodavanjeSmeneViewModel()
        {
            var jedinicaDAO = new VatrogasnaJedinicaDAO();
            VatrogasneJedinice = jedinicaDAO.GetList();
        }
        public int BrojSmene { get; set; }
        public List<VatrogasnaJedinica> VatrogasneJedinice { get; set; }
        public VatrogasnaJedinica IzabranaVatrogasnaJedinica { get; set; }
        public List<Smena> Smene { get; set; }
        public Smena IzabranaSmena { get; set; }

        public void Dodaj()
        {
            Smena smena = new Smena { Broj_Smene = BrojSmene };
            smena.VatrogasnaJedinicaID = IzabranaVatrogasnaJedinica.ID;
            SmenaDAO smenaDAO = new SmenaDAO();
            smenaDAO.Insert(smena);
            TryClose();
        }
    }
}
