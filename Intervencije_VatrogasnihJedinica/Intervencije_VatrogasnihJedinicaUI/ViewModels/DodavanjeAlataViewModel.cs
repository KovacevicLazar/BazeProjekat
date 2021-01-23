using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System.Collections.Generic;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public  class DodavanjeAlataViewModel : Screen
    {
        public DodavanjeAlataViewModel()
        {
            var voziloDAO = new VoziloDAO();
            Vozila = voziloDAO.GetList();
        }
        public string NazivAlata { get; set; }
        public List<Vozilo> Vozila { get; set; }
        public Vozilo IzabranoVozilo { get; set; }
        public void Dodaj()
        {
            Alat alat = new Alat { Naziv_Alata = NazivAlata, Id_Vozila = IzabranoVozilo.ID };
            AlatDAO alataDAO = new AlatDAO();
            alataDAO.Insert(alat);
            TryClose();
        }
    }
}
