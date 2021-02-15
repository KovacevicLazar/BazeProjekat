using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System.Collections.Generic;
using Caliburn.Micro;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class DodavanjeSmeneViewModel : Screen
    {
        private SmenaDAO smenaDAO = new SmenaDAO();
        private VatrogasnaJedinicaDAO jedinicaDAO = new VatrogasnaJedinicaDAO();
        private string porukaGreskeZaNazivSmene = "";
        private string porukaGreskeZaVSJ = "";

        public DodavanjeSmeneViewModel(Smena smena)
        {
            VatrogasneJedinice = jedinicaDAO.GetList();
            Smena = smena;
            if (smena != null)
            {
                NazivSmene = smena.NazivSmene;
                IzabranaVatrogasnaJedinica = VatrogasneJedinice.Find(x => x.ID == smena.VatrogasnaJedinicaID);
                NotifyOfPropertyChange(() => IzabranaVatrogasnaJedinica);
            }
        }

        public Smena Smena { get; set; }
        public string NazivSmene { get; set; }
        public List<VatrogasnaJedinica> VatrogasneJedinice { get; set; }
        public VatrogasnaJedinica IzabranaVatrogasnaJedinica { get; set; }
        public string PorukaGreskeZaVSJ { get => porukaGreskeZaVSJ; set { porukaGreskeZaVSJ = value; NotifyOfPropertyChange(() => PorukaGreskeZaVSJ); } }
        public string PorukaGreskeZaNazivSmene { get => porukaGreskeZaNazivSmene; set { porukaGreskeZaNazivSmene = value; NotifyOfPropertyChange(() => PorukaGreskeZaNazivSmene); } }

        public void DodajIzmeni()
        {
            if (Validacija())
            {
                if (Smena == null)
                {
                    Smena = new Smena { NazivSmene = NazivSmene, VatrogasnaJedinicaID = IzabranaVatrogasnaJedinica.ID };
                    smenaDAO.Insert(Smena);
                }
                else
                {
                    Smena = new Smena { ID = Smena.ID, NazivSmene = NazivSmene, VatrogasnaJedinicaID = IzabranaVatrogasnaJedinica.ID };
                    smenaDAO.Update(Smena);
                }
                TryClose();
            }
        }

        private bool Validacija()
        {
            PorukaGreskeZaVSJ = "";
            PorukaGreskeZaNazivSmene = "";
            bool ispravanUnos = true;
            if (IzabranaVatrogasnaJedinica == null)
            {
                PorukaGreskeZaVSJ = "Izaberite Vatrogasnu jedincu!";
                ispravanUnos = false;
            }
            return ispravanUnos;
        }
    }
}
