using Caliburn.Micro;
using Intervencije_VatrogasnihJedinica;
using Intervencije_VatrogasnihJedinica.dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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
            manager.ShowDialog(new DodavanjeInspektoraViewModel(), null, null);
            SviInspektori = inspektorDAO.GetList();
        }

        public void Obrisi()
        {
            if (OznacenInspektor != null)
            {
                inspektorDAO.Delete(OznacenInspektor.InspektorId);
                SviInspektori = inspektorDAO.GetList();
                OznacenInspektor = null;
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
