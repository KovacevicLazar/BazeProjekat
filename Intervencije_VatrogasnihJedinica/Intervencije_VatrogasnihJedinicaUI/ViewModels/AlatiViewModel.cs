using Intervencije_VatrogasnihJedinica;
using System.Collections.Generic;
using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica.dao;
using System.Windows.Forms;
using System;
using System.Collections.ObjectModel;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class AlatiViewModel : PropertyChangedBase
    {
        private AlatDAO alatDAO = new AlatDAO();
        public ObservableCollection<Alat> sviAlati = new ObservableCollection<Alat>();
        private string poruka = "";
        IWindowManager manager = new WindowManager();

        public AlatiViewModel()
        {
            SviAlati = new ObservableCollection<Alat>(alatDAO.GetList());
        }

        public string Poruka { get => poruka; set { poruka = value; NotifyOfPropertyChange(() => Poruka); } }
        public ObservableCollection<Alat> SviAlati { get { return sviAlati; } set { sviAlati = value; NotifyOfPropertyChange(() => sviAlati); } }
        public Alat OznacenAlat { get; set; }

        public void Dodaj()
        {
            manager.ShowDialog(new DodavanjeAlataViewModel(null), null, null);
            SviAlati = new ObservableCollection<Alat>(alatDAO.GetList());
        }

        public void Obrisi()
        {
            Poruka = "";
            if (OznacenAlat != null)
            {
                try
                {
                    alatDAO.Delete(OznacenAlat.ID);
                }
                catch (Exception ex)
                {
                    Poruka = ex.InnerException?.InnerException?.Message;
                }
                SviAlati = new ObservableCollection<Alat>(alatDAO.GetList());
                OznacenAlat = null;
            }
            else
            {
                Poruka = "Prvo morate selektovati alat iz liste alata";
            }
        }

        public void Izmeni()
        {
            Poruka = "";
            if (OznacenAlat != null)
            {
                manager.ShowDialog(new DodavanjeAlataViewModel(OznacenAlat), null, null);
                SviAlati = new ObservableCollection<Alat>(alatDAO.GetList());
                OznacenAlat = null;
            }
            else
            {
                Poruka = "Prvo morate selektovati alat iz liste alata";
            }
        }
    }
}
