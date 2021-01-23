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
    public class SmeneViewModel : PropertyChangedBase
    {
        public SmeneViewModel()
        {
            SveSmene = smenaDAO.GetList();
        }
        public List<Smena> sveSmene= new List<Smena>();
        public List<Smena> SveSmene{ get { return sveSmene; } set { sveSmene = value; NotifyOfPropertyChange(() => sveSmene); } }
        public Smena OznacenaSmena { get; set; }
        private SmenaDAO smenaDAO = new SmenaDAO();
        IWindowManager manager = new WindowManager();

        public void Dodaj()
        {
            manager.ShowDialog(new DodavanjeSmeneViewModel(), null, null);
            SveSmene = smenaDAO.GetList();
        }
        public void Obrisi()
        {
            if (OznacenaSmena != null)
            {
                smenaDAO.Delete(OznacenaSmena.ID);
                SveSmene = smenaDAO.GetList();
                OznacenaSmena = null;
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
