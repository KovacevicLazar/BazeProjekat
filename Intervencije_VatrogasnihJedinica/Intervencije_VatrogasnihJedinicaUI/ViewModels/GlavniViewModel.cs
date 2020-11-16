using Caliburn.Micro;
using Intervencije_VatrogasnihJedinicaUI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class GlavniViewModel
    {
        IWindowManager manager = new WindowManager();

        public void Opstine()
        {
           manager.ShowDialog(new OpstineViewModel(), null, null);
            
        }

        public void VatrogasneJedinice()
        {
            manager.ShowDialog(new VatrogasneJediniceViewModel(), null, null);
        }

        
        public void Vozila()
        {
            manager.ShowDialog(new VozilaViewModel(), null, null);
        }

        public void Radnici()
        {
            manager.ShowDialog(new RadniciViewModel(), null, null);
        }


    }
}
