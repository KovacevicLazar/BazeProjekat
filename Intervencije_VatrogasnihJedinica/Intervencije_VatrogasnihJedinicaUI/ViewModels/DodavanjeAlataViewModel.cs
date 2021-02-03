using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System.Collections.Generic;
using System.Linq;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public  class DodavanjeAlataViewModel : Screen
    {
        public DodavanjeAlataViewModel(Alat alat)
        {
            Alat = alat;
            var voziloDAO = new VoziloDAO();
            Vozila = voziloDAO.GetList();
            if (alat != null)
            {
                NazivAlata = alat.Naziv_Alata;
            }
        }
        public Alat Alat { get; set; }
        public string NazivAlata { get; set; }
        public List<Vozilo> Vozila { get; set; }
        public Vozilo IzabranoVozilo { get; set; }

        private string porukaGreskeZaNazivAlata = "";
        public string PorukaGreskeZaNazivAlata { get => porukaGreskeZaNazivAlata; set { porukaGreskeZaNazivAlata = value; NotifyOfPropertyChange(() => PorukaGreskeZaNazivAlata); } }
        
        public void DodajIzmeni()
        {
            if (Validacija())
            {
                Alat alat = new Alat { Naziv_Alata = NazivAlata};
                AlatDAO alataDAO = new AlatDAO();
                alataDAO.Insert(alat);
                TryClose();
            }
        }
        private bool Validacija()
        {
            PorukaGreskeZaNazivAlata = "";
            bool ispravanUnos = true;
            if (string.IsNullOrEmpty(NazivAlata))
            {
                PorukaGreskeZaNazivAlata = "Unesite naziv!";
                ispravanUnos = false;
            }
            else if (!NazivAlata.All(c => char.IsWhiteSpace(c) || char.IsLetter(c)))
            {
                PorukaGreskeZaNazivAlata = "Naziv sme sadrzati samo slova!";
                ispravanUnos = false;
            }
            else if (NazivAlata.Length < 4 || NazivAlata.Length > 30)
            {
                PorukaGreskeZaNazivAlata = "Naziv mora sadrzati od 4 do 30 slova!";
                ispravanUnos = false;
            }

            return ispravanUnos;
        }
    }
}
