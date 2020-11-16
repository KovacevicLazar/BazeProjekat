using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class DodavanjeRadnikaViewModel : Screen
    {
        public enum PozicijeEnum { VATROGASAC , VOZAC , KOMANDIR}
        public DodavanjeRadnikaViewModel()
        {
            Pozicije = Enum.GetValues(typeof(PozicijeEnum)).Cast<PozicijeEnum>().ToList();
            var jedinicaDAO = new VatrogasnaJedinicaDAO();
            VatrogasneJedinice = jedinicaDAO.GetList();

            var smenaDAO = new SmenaDAO();
            Smene = smenaDAO.GetList();
        }

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Jmbg { get; set; }

        public int RadniStaz { get; set; }



        public PozicijeEnum RadnaPozicija { get; set; }
        public IReadOnlyList<PozicijeEnum> Pozicije { get; }

        public List<VatrogasnaJedinica> VatrogasneJedinice { get; set; }
        public VatrogasnaJedinica IzabranaVatrogasnaJedinica { get; set; }

        public List<Smena> Smene { get; set; }
        public Smena IzabranaSmena { get; set; }


        public void Dodaj()
        {

            switch (RadnaPozicija)
            {
                case (PozicijeEnum.VATROGASAC):
                   
                    break;
                case (PozicijeEnum.VOZAC):
                   
                    break;
                case (PozicijeEnum.KOMANDIR):
                   
                    break;

            }
            TryClose();
        }
    }
}
