using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System;
using System.Collections.Generic;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class InspektoriViewModel : PropertyChangedBase
    {
        private InspektorDAO inspektorDAO = new InspektorDAO();
        public List<Inspektor> sviInspektori = new List<Inspektor>();
        IWindowManager manager = new WindowManager();
        private string poruka;

        public InspektoriViewModel()
        {
            SviInspektori = inspektorDAO.GetList();
        }

        public string Poruka { get => poruka; set { poruka = value; NotifyOfPropertyChange(() => Poruka); } }
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
                Poruka = "Prvo morate selektovati inspektora iz liste inspektora!";
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
                Poruka = "Prvo morate selektovati inspektora iz liste inspektora!";
            }
        }
    }
}
