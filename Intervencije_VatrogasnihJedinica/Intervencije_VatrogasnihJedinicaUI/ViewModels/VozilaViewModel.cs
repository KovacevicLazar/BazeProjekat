using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    class VozilaViewModel : PropertyChangedBase
    {
        public VozilaViewModel()
        {
            SvaVozila = voziloDAO.GetList();
        }
        private string poruka;
        public string Poruka { get => poruka; set { poruka = value; NotifyOfPropertyChange(() => Poruka); } }
        public List<Vozilo> svaVozila = new List<Vozilo>();
        public List<Vozilo> SvaVozila { get { return svaVozila; } set { svaVozila = value; NotifyOfPropertyChange(() => svaVozila); } }
        public Vozilo OznacenoVozilo { get; set; }
        private VoziloDAO voziloDAO = new VoziloDAO();
        IWindowManager manager = new WindowManager();

        public void Dodaj()
        {
            manager.ShowDialog(new DodavanjeVozilaViewModel(null), null, null);
            SvaVozila = voziloDAO.GetList();
        }
        public void Obrisi()
        {
            Poruka = "";
            if (OznacenoVozilo != null)
            {
                try
                {
                    voziloDAO.Delete(OznacenoVozilo.ID);
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        if (ex.InnerException.InnerException != null)
                        {
                            Poruka = ex.InnerException.InnerException.Message;
                        }
                    }
                }
                SvaVozila = voziloDAO.GetList();
                OznacenoVozilo = null;
            }
            else
            {
                Poruka = "Prvo morate selektovati vozilo iz liste vozila!";
            }
        }
        public void Izmeni()
        {
            Poruka = "";
            if (OznacenoVozilo != null)
            {
                manager.ShowDialog(new DodavanjeVozilaViewModel(OznacenoVozilo), null, null);
                SvaVozila = voziloDAO.GetList();
                OznacenoVozilo = null;
            }
            else
            {
                Poruka = "Prvo morate selektovati vozilo iz liste vozila!";
            }
        }
    }
}
