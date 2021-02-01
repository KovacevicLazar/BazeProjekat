using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System.Collections.Generic;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class InspektoriViewModel : PropertyChangedBase
    {
        public InspektoriViewModel()
        {
            SviInspektori = inspektorDAO.GetList();
        }

        private InspektorDAO inspektorDAO = new InspektorDAO();
        IWindowManager manager = new WindowManager();
        public List<Inspektor> sviInspektori = new List<Inspektor>();
        public List<Inspektor> SviInspektori { get { return sviInspektori; } set { sviInspektori = value; NotifyOfPropertyChange(() => sviInspektori); } }
        public Inspektor OznacenInspektor { get; set; }

        public void Dodaj()
        {
            manager.ShowDialog(new DodavanjeInspektoraViewModel(null), null, null);
            SviInspektori = inspektorDAO.GetList();
        }
        public void Obrisi()
        {
            if (OznacenInspektor != null)
            {
                inspektorDAO.Delete(OznacenInspektor.ID);
                SviInspektori = inspektorDAO.GetList();
                OznacenInspektor = null;
            }
            else
            {
            }
        }
        public void Izmeni()
        {
            if (OznacenInspektor != null)
            {
                manager.ShowDialog(new DodavanjeInspektoraViewModel(OznacenInspektor), null, null);
                SviInspektori = inspektorDAO.GetList();
            }
            else
            {
            }
        }
    }
}
