using Intervencije_VatrogasnihJedinica;
using System.Collections.Generic;
using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica.dao;
using System.Windows.Forms;
using System;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class AlatiViewModel : PropertyChangedBase
    {
        public AlatiViewModel()
        {
            SviAlati = AalatDAO.GetList();
        }
        private string poruka;
        public string Poruka { get => poruka; set { poruka = value; NotifyOfPropertyChange(() => Poruka); } }
        public List<Alat> sviAlati = new List<Alat>();
        public List<Alat> SviAlati { get { return sviAlati; } set { sviAlati = value; NotifyOfPropertyChange(() => sviAlati); } }
        public Alat OznacenAlat { get; set; }
        private AlatDAO AalatDAO = new AlatDAO();
        IWindowManager manager = new WindowManager();

        public void Dodaj()
        {
            manager.ShowDialog(new DodavanjeAlataViewModel(null), null, null);
            SviAlati = AalatDAO.GetList();
        }
        public void Obrisi()
        {
            Poruka = "";
            if (OznacenAlat != null)
            {
                try
                {
                    AalatDAO.Delete(OznacenAlat.ID);
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
                SviAlati = AalatDAO.GetList();
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
                SviAlati = AalatDAO.GetList();
                OznacenAlat = null;
            }
            else
            {
                Poruka = "Prvo morate selektovati alat iz liste alata";
            }
        }
    }
}
