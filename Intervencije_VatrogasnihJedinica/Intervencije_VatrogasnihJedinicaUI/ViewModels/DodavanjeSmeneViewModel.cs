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
            if (smena != null)
            {
                Smena = smena;
                BrojSmene = smena.Broj_Smene;
                IzabranaVatrogasnaJedinica = smena.VatrogasnaJedinica;
                NotifyOfPropertyChange(() => IzabranaVatrogasnaJedinica);
            }
            var jedinicaDAO = new VatrogasnaJedinicaDAO();
            VatrogasneJedinice = jedinicaDAO.GetList();
        }
        public int BrojSmene { get; set; }
        public List<VatrogasnaJedinica> VatrogasneJedinice { get; set; }
        public VatrogasnaJedinica IzabranaVatrogasnaJedinica { get; set; }
        private string porukaGreskeZaNazivSmene = "";
        private string porukaGreskeZaVSJ = "";

        public Smena Smena { get; set; }
        public string PorukaGreskeZaVSJ { get => porukaGreskeZaVSJ; set { porukaGreskeZaVSJ = value; NotifyOfPropertyChange(() => PorukaGreskeZaVSJ); } }
        public string PorukaGreskeZaNazivSmene { get => porukaGreskeZaNazivSmene; set { porukaGreskeZaNazivSmene = value; NotifyOfPropertyChange(() => PorukaGreskeZaNazivSmene); } }

        public void DodajIzmeni()
        {
            if (Validacija())
            {
                SmenaDAO smenaDAO = new SmenaDAO();
                if (Smena == null)
                {
                    Smena = new Smena { Broj_Smene = BrojSmene , VatrogasnaJedinicaID = IzabranaVatrogasnaJedinica.ID };
                    smenaDAO.Insert(Smena);
                }
                else
                {
                    Smena = new Smena { ID= Smena.ID, Broj_Smene = BrojSmene, VatrogasnaJedinicaID = IzabranaVatrogasnaJedinica.ID };
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

            if (BrojSmene < 1 || BrojSmene > 4)
            {
                PorukaGreskeZaNazivSmene = "Samo u intervalu od 1 do 4!";
                ispravanUnos = false;
            }
            
            return ispravanUnos;
        }
    }
}
