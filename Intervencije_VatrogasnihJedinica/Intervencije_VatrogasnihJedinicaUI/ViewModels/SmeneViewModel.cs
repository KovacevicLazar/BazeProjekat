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
    public class SmeneViewModel : PropertyChangedBase
    {
        public SmeneViewModel()
        {
            SveSmene = smenaDAO.GetList();
        }
        private string poruka;
        public string Poruka { get => poruka; set { poruka = value; NotifyOfPropertyChange(() => Poruka); } }
        public List<Smena> sveSmene= new List<Smena>();
        public List<Smena> SveSmene{ get { return sveSmene; } set { sveSmene = value; NotifyOfPropertyChange(() => sveSmene); } }
        public Smena OznacenaSmena { get; set; }
        private SmenaDAO smenaDAO = new SmenaDAO();
        IWindowManager manager = new WindowManager();

        public void Dodaj()
        {
            manager.ShowDialog(new DodavanjeSmeneViewModel(null), null, null);
            SveSmene = smenaDAO.GetList();
        }
        public void Obrisi()
        {
            Poruka = "";
            if (OznacenaSmena != null)
            {
                try
                {
                    smenaDAO.Delete(OznacenaSmena.ID);
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
                SveSmene = smenaDAO.GetList();
                OznacenaSmena = null;
            }
            else
            {
                Poruka = "Prvo morate selektovati smenu iz liste smena!";
            }
        }
        public void Izmeni()
        {
            Poruka = "";
            if (OznacenaSmena != null)
            {
                manager.ShowDialog(new DodavanjeSmeneViewModel(OznacenaSmena), null, null);
                SveSmene = smenaDAO.GetList();
                OznacenaSmena = null;
            }
            else
            {
                Poruka = "Prvo morate selektovati smenu iz liste smena";
            }
        }
    }
}
