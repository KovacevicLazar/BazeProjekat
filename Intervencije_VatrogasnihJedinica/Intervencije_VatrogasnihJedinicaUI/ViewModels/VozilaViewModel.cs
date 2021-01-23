using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System.Collections.Generic;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    class VozilaViewModel : PropertyChangedBase
    {
        public VozilaViewModel()
        {
            SvaVozila = voziloDAO.GetList();
        }

        public List<Vozilo> svaVozila = new List<Vozilo>();
        public List<Vozilo> SvaVozila { get { return svaVozila; } set { svaVozila = value; NotifyOfPropertyChange(() => svaVozila); } }
        public Vozilo OznacenoVozilo { get; set; }
        private VoziloDAO voziloDAO = new VoziloDAO();
        IWindowManager manager = new WindowManager();

        public void Dodaj()
        {
            manager.ShowDialog(new DodavanjeVozilaViewModel(), null, null);
            SvaVozila = voziloDAO.GetList();
        }
        public void Obrisi()
        {
            if (OznacenoVozilo != null)
            {
                voziloDAO.Delete(OznacenoVozilo.ID);
                SvaVozila = voziloDAO.GetList();
                OznacenoVozilo = null;
            }
            else
            {
            }
        }
        public void Izmeni()
        {
        }
    }
}
