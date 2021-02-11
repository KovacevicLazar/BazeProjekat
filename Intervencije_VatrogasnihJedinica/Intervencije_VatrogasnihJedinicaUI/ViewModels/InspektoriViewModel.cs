using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class InspektoriViewModel : PropertyChangedBase
    {
        public InspektoriViewModel()
        {
            SviInspektori = inspektorDAO.GetList();
        }
        private string poruka;
        public string Poruka { get => poruka; set { poruka = value; NotifyOfPropertyChange(() => Poruka); } }

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
            Poruka = "";
            if (OznacenInspektor != null)
            {
                try
                {
                    inspektorDAO.Delete(OznacenInspektor.ID);
                }
                catch (Exception ex)
                {
                    Poruka = ex.InnerException?.InnerException?.Message;
                }
                
                SviInspektori = inspektorDAO.GetList();
                OznacenInspektor = null;
            }
            else
            {
                Poruka = "Prvo morate selektovati inspektora iz liste inspektora";
            }
        }
        public void Izmeni()
        {
            Poruka = "";
            if (OznacenInspektor != null)
            {
                manager.ShowDialog(new DodavanjeInspektoraViewModel(OznacenInspektor), null, null);
                SviInspektori = inspektorDAO.GetList();
                OznacenInspektor = null;
            }
            else
            {
                Poruka = "Prvo morate selektovati inspektora iz liste inspektora";
            }
        }
    }
}
