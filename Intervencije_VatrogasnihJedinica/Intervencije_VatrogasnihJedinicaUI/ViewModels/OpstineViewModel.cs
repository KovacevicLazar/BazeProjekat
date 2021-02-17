using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class OpstineViewModel : PropertyChangedBase
    {
        private OpstinaDAO opstinaDAO = new OpstinaDAO();
        public ObservableCollection<Opstina> sveOpstine = new ObservableCollection<Opstina>();
        IWindowManager manager = new WindowManager();
        private string poruka;

        public OpstineViewModel()
        {
            SveOpstine = new ObservableCollection<Opstina>(opstinaDAO.GetList());
        }

        public string Poruka { get => poruka; set { poruka = value; NotifyOfPropertyChange(() => Poruka); } }
        public ObservableCollection<Opstina> SveOpstine { get { return sveOpstine; } set { sveOpstine = value; NotifyOfPropertyChange(() => SveOpstine); } }
        public Opstina OznacenaOpstina { get; set; }

        public void Dodaj()
        {
            manager.ShowDialog(new DodavanjeOpstineViewModel(null), null, null);
            SveOpstine = new ObservableCollection<Opstina>(opstinaDAO.GetList());
        }

        public void Obrisi()
        {
            Poruka = "";
            if (OznacenaOpstina != null)
            {
                try
                {
                    opstinaDAO.Delete(OznacenaOpstina.ID);
                }
                catch (Exception ex)
                {
                    Poruka = ex.InnerException?.InnerException?.Message;
                }
                SveOpstine = new ObservableCollection<Opstina>(opstinaDAO.GetList());
                OznacenaOpstina = null;
            }
            else
            {
                Poruka = "Prvo morate selektovati opštinu u listi opština!";
            }
        }

        public void Izmeni()
        {
            Poruka = "";
            if (OznacenaOpstina != null)
            {
                manager.ShowDialog(new DodavanjeOpstineViewModel(OznacenaOpstina), null, null);
                SveOpstine = new ObservableCollection<Opstina>(opstinaDAO.GetList());
                OznacenaOpstina = null;
            }
            else
            {
                Poruka = "Prvo morate selektovati opštinu u listi opština!";
            }
        }
    }
}
