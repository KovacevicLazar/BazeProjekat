using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System.Collections.Generic;
using Caliburn.Micro;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class DodavanjeSmeneViewModel : Screen
    {
        public DodavanjeSmeneViewModel( Smena smena)
        {
            var jedinicaDAO = new VatrogasnaJedinicaDAO();
            VatrogasneJedinice = jedinicaDAO.GetList();
            if (smena != null)
            {
                Smena = smena;
                NazivSmene = smena.NazivSmene;
                IzabranaVatrogasnaJedinica =VatrogasneJedinice.Find(x => x.ID == smena.VatrogasnaJedinicaID);
                NotifyOfPropertyChange(() => IzabranaVatrogasnaJedinica);
            }
        }
        public Smena Smena { get; set; }
        public string NazivSmene { get; set; }
        public List<VatrogasnaJedinica> VatrogasneJedinice { get; set; }
        public VatrogasnaJedinica IzabranaVatrogasnaJedinica { get; set; }

        private string porukaGreskeZaNazivSmene = "";
        private string porukaGreskeZaVSJ = "";
        public string PorukaGreskeZaVSJ { get => porukaGreskeZaVSJ; set { porukaGreskeZaVSJ = value; NotifyOfPropertyChange(() => PorukaGreskeZaVSJ); } }
        public string PorukaGreskeZaNazivSmene { get => porukaGreskeZaNazivSmene; set { porukaGreskeZaNazivSmene = value; NotifyOfPropertyChange(() => PorukaGreskeZaNazivSmene); } }

        public void DodajIzmeni()
        {
            if (Validacija())
            {
                SmenaDAO smenaDAO = new SmenaDAO();
                if (Smena == null)
                {
                    Smena = new Smena { NazivSmene = NazivSmene, VatrogasnaJedinicaID = IzabranaVatrogasnaJedinica.ID };
                    smenaDAO.Insert(Smena);
                }
                else
                {
                    Smena = new Smena { ID= Smena.ID, NazivSmene = NazivSmene, VatrogasnaJedinicaID = IzabranaVatrogasnaJedinica.ID };
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
