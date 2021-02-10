using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public  class IntervencijeViewModel : PropertyChangedBase
    {
        public IntervencijeViewModel()
        {
            SveIntervencije = IntervencijaDAO.GetList();
        }
        private string poruka;
        public string Poruka { get => poruka; set { poruka = value; NotifyOfPropertyChange(() => Poruka); } }
        private IntervencijaDAO IntervencijaDAO = new IntervencijaDAO();
        IWindowManager manager = new WindowManager();
        public List<Intervencija> sveIntervencije = new List<Intervencija>();
        public List<Intervencija> SveIntervencije { get { return sveIntervencije; } set { sveIntervencije = value; NotifyOfPropertyChange(() => sveIntervencije); } }
        public Intervencija OznacenaIntervencija { get; set; }

        public void Dodaj()
        {
            manager.ShowDialog(new DodavanjeIntervencijeViewModel(null), null, null);
            SveIntervencije = IntervencijaDAO.GetList();
        }
        public void Obrisi()
        {
            Poruka = "";
            if (OznacenaIntervencija != null)
            {
                try
                {
                    IntervencijaDAO.Delete(OznacenaIntervencija.ID);
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
                
                SveIntervencije = IntervencijaDAO.GetList();
                OznacenaIntervencija = null;
            }
            else
            {
                Poruka = "Prvo morate selektovati intervenciju iz liste intervencija";
            }
        }
        public void Izmeni()
        {
            Poruka = "";
            if (OznacenaIntervencija != null)
            {
                manager.ShowDialog(new DodavanjeIntervencijeViewModel(OznacenaIntervencija), null, null);
                SveIntervencije = IntervencijaDAO.GetList();
                OznacenaIntervencija = null;
            }
            else
            {
                Poruka = "Prvo morate selektovati intervenciju iz liste intervencija";
            }
        }
        public void DodajInformacijeOUvidjaju( object Intervencija )
        {
            manager.ShowDialog(new DodavanjeInformacijaOUvidjajuViewModel(Intervencija  as Intervencija), null, null);
            SveIntervencije = IntervencijaDAO.GetList();
        }
    }
}
