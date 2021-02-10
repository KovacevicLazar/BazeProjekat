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
        public RadniciViewModel()
        {
            SviRadnici = radnikDAO.GetList();
        }
        private string poruka;
        public string Poruka { get => poruka; set { poruka = value; NotifyOfPropertyChange(() => Poruka); } }
        public List<Radnik> sviRadnici = new List<Radnik>();
        public List<Radnik> SviRadnici { get { return sviRadnici; } set { sviRadnici = value; NotifyOfPropertyChange(() => sviRadnici); } }
        public Radnik OznacenRadnik { get; set; }
        private RadnikDAO radnikDAO = new RadnikDAO();
        IWindowManager manager = new WindowManager();

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
                    if (ex.InnerException != null)
                    {
                        if (ex.InnerException.InnerException != null)
                        {
                            Poruka = ex.InnerException.InnerException.Message;
                        }
                    }
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
    }
}
