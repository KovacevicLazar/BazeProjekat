using Caliburn.Micro;
using Intervencije_VatrogasnihJedinicaUI.ViewModels;
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
