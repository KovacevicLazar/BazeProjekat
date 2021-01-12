using Intervencije_VatrogasnihJedinica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica.dao;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class AlatiViewModel : PropertyChangedBase
    {
        public AlatiViewModel()
        {
            SviAlati = AalatDAO.GetList();
        }

        public List<Alat> sviAlati = new List<Alat>();

        public List<Alat> SviAlati { get { return sviAlati; } set { sviAlati = value; NotifyOfPropertyChange(() => sviAlati); } }
        public Alat OznacenAlat { get; set; }

        private AlatDAO AalatDAO = new AlatDAO();
        IWindowManager manager = new WindowManager();

        public void Dodaj()
        {
            manager.ShowDialog(new DodavanjeAlataViewModel(), null, null);
            SviAlati = AalatDAO.GetList();
        }

        public void Obrisi()
        {
            if (OznacenAlat != null)
            {
                AalatDAO.Delete(OznacenAlat.ID);
                SviAlati = AalatDAO.GetList();
                OznacenAlat = null;
            }
            else
            {

            }
        }
    }
}
