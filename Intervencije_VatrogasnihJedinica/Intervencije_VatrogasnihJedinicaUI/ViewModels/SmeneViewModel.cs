using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System;
using System.Collections.Generic;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class SmeneViewModel : PropertyChangedBase
    {
        private SmenaDAO smenaDAO = new SmenaDAO();
        public List<Smena> sveSmene = new List<Smena>();
        IWindowManager manager = new WindowManager();
        private string poruka;

        public SmeneViewModel()
        {
            SveSmene = smenaDAO.GetList();
        }
        
        public string Poruka { get => poruka; set { poruka = value; NotifyOfPropertyChange(() => Poruka); } }
        public List<Smena> SveSmene{ get { return sveSmene; } set { sveSmene = value; NotifyOfPropertyChange(() => sveSmene); } }
        public Smena OznacenaSmena { get; set; }

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
                    Poruka = ex.InnerException?.InnerException?.Message;
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
