using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System;
using System.Collections.Generic;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    class VozilaViewModel : PropertyChangedBase
    {
        private VoziloDAO voziloDAO = new VoziloDAO();
        public List<Vozilo> svaVozila = new List<Vozilo>();
        IWindowManager manager = new WindowManager();
        private string poruka;

        public VozilaViewModel()
        {
            SvaVozila = voziloDAO.GetList();
        }

        public Vozilo OznacenoVozilo { get; set; }
        public string Poruka
        {
            get => poruka;
            set
            {
                poruka = value;
                NotifyOfPropertyChange(() => Poruka);
            }
        }

        public List<Vozilo> SvaVozila
        {
            get
            {
                return svaVozila;
            }
            set
            {
                svaVozila = value;
                NotifyOfPropertyChange(() => svaVozila);
            }
        }

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
                    Poruka = ex.InnerException?.InnerException?.Message;
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
