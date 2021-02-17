using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class RadniciViewModel : PropertyChangedBase
    {
        private RadnikDAO radnikDAO = new RadnikDAO();
        public List<Radnik> sviRadnici = new List<Radnik>();
        IWindowManager manager = new WindowManager();
        private string poruka;

        public RadniciViewModel()
        {
            SviRadnici = radnikDAO.GetList();
        }

        public string Poruka { get => poruka; set { poruka = value; NotifyOfPropertyChange(() => Poruka); } }
        public List<Radnik> SviRadnici { get { return sviRadnici; } set { sviRadnici = value; NotifyOfPropertyChange(() => sviRadnici); } }
        public Radnik OznacenRadnik { get; set; }

        public void Dodaj()
        {
            manager.ShowDialog(new DodavanjeRadnikaViewModel(null), null, null);
            SviRadnici = radnikDAO.GetList();
        }

        public void Obrisi()
        {
            Poruka = "";
            if (OznacenRadnik != null)
            {
                try
                {
                    radnikDAO.Delete(OznacenRadnik.ID);
                }
                catch (Exception ex)
                {
                    Poruka = ex.InnerException?.InnerException?.Message;
                }

                SviRadnici = radnikDAO.GetList();
                OznacenRadnik = null;
            }
            else
            {
                Poruka = "Prvo morate selektovati radnika iz liste radnika";
            }
        }

        public void Izmeni()
        {
            Poruka = "";
            if (OznacenRadnik != null)
            {
                manager.ShowDialog(new DodavanjeRadnikaViewModel(OznacenRadnik), null, null);
                SviRadnici = radnikDAO.GetList();
                OznacenRadnik = null;
            }
            else
            {
                Poruka = "Prvo morate selektovati radnika iz liste radnika";
            }
        }

        public void IzmenaVatrogasneJediniceISmene(object radnik)
        {
            manager.ShowDialog(new PromenaVSJISmeneZaRadnikaViewModel(radnik as Radnik), null, null);
            SviRadnici = radnikDAO.GetList();
        }
    }
}
