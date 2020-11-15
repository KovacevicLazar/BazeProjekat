using Caliburn.Micro;
using Intervencije_VatrogasnihJedinicaUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Intervencije_VatrogasnihJedinicaUI
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper() 
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<GlavniViewModel>();
        }

    }
}
