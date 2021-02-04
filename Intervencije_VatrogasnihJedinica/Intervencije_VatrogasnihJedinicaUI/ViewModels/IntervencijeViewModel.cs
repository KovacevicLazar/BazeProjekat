using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System.Collections.Generic;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public  class IntervencijeViewModel : PropertyChangedBase
    {
        public IntervencijeViewModel()
        {
            SveIntervencije = IntervencijaDAO.GetList();
        }
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
            if (OznacenaIntervencija != null)
            {
                IntervencijaDAO.Delete(OznacenaIntervencija.ID);
                SveIntervencije = IntervencijaDAO.GetList();
                OznacenaIntervencija = null;
            }
            else
            {
            }
        }
        public void Izmeni()
        {
            if (OznacenaIntervencija != null)
            {
                manager.ShowDialog(new DodavanjeIntervencijeViewModel(OznacenaIntervencija), null, null);
                SveIntervencije = IntervencijaDAO.GetList();
            }
        }
        public void DodajInformacijeOUvidjaju( object Intervencija )
        {
            manager.ShowDialog(new DodavanjeInformacijaOUvidjajuViewModel(Intervencija  as Intervencija), null, null);
            SveIntervencije = IntervencijaDAO.GetList();
        }
    }
}
