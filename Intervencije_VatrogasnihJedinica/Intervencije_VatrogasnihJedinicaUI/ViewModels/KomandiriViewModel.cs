using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class KomandiriViewModel : PropertyChangedBase
    {
        public KomandiriViewModel()
        {
            SviKomandiri = komandirDAO.GetList();
        }
        public List<Komandir> sviKomandiri = new List<Komandir>();
        public List<Komandir> SviKomandiri { get { return sviKomandiri; } set { sviKomandiri = value; NotifyOfPropertyChange(() => sviKomandiri); } }
        public Komandir OznacenKomandir { get; set; }
        private KomandirDAO komandirDAO = new KomandirDAO();
        IWindowManager manager = new WindowManager();

        public void Obrisi()
        {
            if (OznacenKomandir != null)
            {
                komandirDAO.Delete(OznacenKomandir.ID);
                SviKomandiri = komandirDAO.GetList();
                OznacenKomandir = null;
            }
            else
            {
            }
        }
        public void Izmeni()
        {
            if (OznacenKomandir != null)
            {
                manager.ShowDialog(new DodavanjeKomandiraViewModel(OznacenKomandir.VatrogasnaJedinica), null, null);
                SviKomandiri = komandirDAO.GetList();
                OznacenKomandir = null;
            }
            else
            {
            }
        }
    }
}
