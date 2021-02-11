using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class KomandiriViewModel : PropertyChangedBase
    {
        public KomandiriViewModel()
        {
            SviKomandiri = komandirDAO.GetList();
        }
        private string poruka;
        public string Poruka { get => poruka; set { poruka = value; NotifyOfPropertyChange(() => Poruka); } }
        public List<Komandir> sviKomandiri = new List<Komandir>();
        public List<Komandir> SviKomandiri { get { return sviKomandiri; } set { sviKomandiri = value; NotifyOfPropertyChange(() => sviKomandiri); } }
        public Komandir OznacenKomandir { get; set; }
        private KomandirDAO komandirDAO = new KomandirDAO();
        IWindowManager manager = new WindowManager();

        public void Obrisi()
        {
            Poruka = "";
            if (OznacenKomandir != null)
            {
                try
                {
                    komandirDAO.Delete(OznacenKomandir.ID);
                }
                catch (Exception ex)
                {
                    Poruka = ex.InnerException?.InnerException?.Message;
                }
                
                SviKomandiri = komandirDAO.GetList();
                OznacenKomandir = null;
            }
            else
            {
                Poruka = "Prvo morate selektovati komandira iz liste komandira";
            }
        }
        public void Izmeni()
        {
            Poruka = "";
            if (OznacenKomandir != null)
            {
                manager.ShowDialog(new DodavanjeKomandiraViewModel(OznacenKomandir.VatrogasnaJedinica), null, null);
                SviKomandiri = komandirDAO.GetList();
                OznacenKomandir = null;
            }
            else
            {
                Poruka = "Prvo morate selektovati komandira iz liste komandira";
            }
        }
    }
}
