using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System.Collections.ObjectModel;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class OpstineViewModel : PropertyChangedBase
    {
        public OpstineViewModel()
        {
            SveOpstine = new ObservableCollection<Opstina>(OpstinaDAO.GetList());
        }
        IWindowManager manager = new WindowManager();
        private OpstinaDAO opstinaDAO = new OpstinaDAO();
        public ObservableCollection<Opstina> sveOpstine = new ObservableCollection<Opstina>();
        public ObservableCollection<Opstina> SveOpstine { get { return sveOpstine; } set { sveOpstine = value; NotifyOfPropertyChange(() => SveOpstine); } }
        public Opstina OznacenaOpstina { get; set; }
        public OpstinaDAO OpstinaDAO { get => opstinaDAO; set => opstinaDAO = value; }

        public void Dodaj()
        {
            manager.ShowDialog(new DodavanjeOpstineViewModel(null), null, null);
            SveOpstine = new ObservableCollection<Opstina>(OpstinaDAO.GetList());
        }
        public void Obrisi()
        {
            if (OznacenaOpstina != null)
            {
                OpstinaDAO.Delete(OznacenaOpstina.ID);
                SveOpstine = new ObservableCollection<Opstina>(OpstinaDAO.GetList());
                OznacenaOpstina = null;
            }
            else
            {
            }
        }
        public void Izmeni()
        {
            if (OznacenaOpstina != null)
            {
                manager.ShowDialog(new DodavanjeOpstineViewModel(OznacenaOpstina), null, null);
                SveOpstine = new ObservableCollection<Opstina>(OpstinaDAO.GetList());
            } 
        }
    }
}
