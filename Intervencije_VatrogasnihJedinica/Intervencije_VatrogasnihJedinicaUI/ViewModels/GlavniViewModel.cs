using Caliburn.Micro;
using System.Windows.Media;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class GlavniViewModel : Conductor<object>
    {
        IWindowManager manager = new WindowManager();

        public GlavniViewModel()
        {
            InicijalizacijaBoja();
            ActivateItem(new VatrogasneJediniceViewModel(this));
            ButtonVSJBackground = new SolidColorBrush(Colors.White);
            NotifyOfPropertyChange(() => ButtonVSJBackground);
        }

        public SolidColorBrush ButtonOpstineBackground { get; set; }
        public SolidColorBrush ButtonVSJBackground { get; set; }
        public SolidColorBrush ButtonSmeneBackground { get; set; }
        public SolidColorBrush ButtonRadniciBackground { get; set; }
        public SolidColorBrush ButtonAlatiBackground { get; set; }
        public SolidColorBrush ButtonVozilaBackground { get; set; }
        public SolidColorBrush ButtonInspektoriBackground { get; set; }
        public SolidColorBrush ButtonIntervencijeBackground { get; set; }
        public SolidColorBrush ButtonKomandiriBackground { get; set; }

        public void Opstine()
        {
            try
            {
                InicijalizacijaBoja();
                ButtonOpstineBackground = new SolidColorBrush(Colors.White);
                NotifyOfPropertyChange(() => ButtonOpstineBackground);
                ActivateItem(new OpstineViewModel());
            }
            catch { }
        }

        public void VatrogasneJedinice()
        {
            try
            {
                InicijalizacijaBoja();
                ButtonVSJBackground = new SolidColorBrush(Colors.White);
                NotifyOfPropertyChange(() => ButtonVSJBackground);
                ActivateItem(new VatrogasneJediniceViewModel(this));
            }
            catch { }
        }

        public void Vozila()
        {
            try
            {
                InicijalizacijaBoja();
                ButtonVozilaBackground = new SolidColorBrush(Colors.White);
                NotifyOfPropertyChange(() => ButtonVozilaBackground);
                ActivateItem(new VozilaViewModel());
            }
            catch { }
        }

        public void Radnici()
        {
            try
            {
                InicijalizacijaBoja();
                ButtonRadniciBackground = new SolidColorBrush(Colors.White);
                NotifyOfPropertyChange(() => ButtonRadniciBackground);
                ActivateItem(new RadniciViewModel());
            }
            catch { }
        }

        public void Smene()
        {
            try
            {
                InicijalizacijaBoja();
                ButtonSmeneBackground = new SolidColorBrush(Colors.White);
                NotifyOfPropertyChange(() => ButtonSmeneBackground);
                ActivateItem(new SmeneViewModel());
            }
            catch { }
        }

        public void Alati()
        {
            try
            {
                InicijalizacijaBoja();
                ButtonAlatiBackground = new SolidColorBrush(Colors.White);
                NotifyOfPropertyChange(() => ButtonAlatiBackground);
                ActivateItem(new AlatiViewModel());
            }
            catch { }
        }

        public void Intervencije()
        {
            try
            {
                InicijalizacijaBoja();
                ButtonIntervencijeBackground = new SolidColorBrush(Colors.White);
                NotifyOfPropertyChange(() => ButtonIntervencijeBackground);
                ActivateItem(new IntervencijeViewModel());
            }
            catch { }
        }

        public void Inspektori()
        {
            try
            {
                InicijalizacijaBoja();
                ButtonInspektoriBackground = new SolidColorBrush(Colors.White);
                NotifyOfPropertyChange(() => ButtonInspektoriBackground);
                ActivateItem(new InspektoriViewModel());
            }
            catch { }
        }

        public void Komandiri()
        {
            try
            {
                InicijalizacijaBoja();
                ButtonKomandiriBackground = new SolidColorBrush(Colors.White);
                NotifyOfPropertyChange(() => ButtonKomandiriBackground);
                ActivateItem(new KomandiriViewModel());
            }
            catch { }
        }

        private void InicijalizacijaBoja()
        {
            ButtonOpstineBackground = new SolidColorBrush(Color.FromRgb(156, 145, 142));
            ButtonVSJBackground = new SolidColorBrush(Color.FromRgb(156, 145, 142));
            ButtonSmeneBackground = new SolidColorBrush(Color.FromRgb(156, 145, 142));
            ButtonRadniciBackground = new SolidColorBrush(Color.FromRgb(156, 145, 142));
            ButtonAlatiBackground = new SolidColorBrush(Color.FromRgb(156, 145, 142));
            ButtonVozilaBackground = new SolidColorBrush(Color.FromRgb(156, 145, 142));
            ButtonInspektoriBackground = new SolidColorBrush(Color.FromRgb(156, 145, 142));
            ButtonIntervencijeBackground = new SolidColorBrush(Color.FromRgb(156, 145, 142));
            ButtonKomandiriBackground = new SolidColorBrush(Color.FromRgb(156, 145, 142));
            NotifyOfPropertyChange(() => ButtonOpstineBackground);
            NotifyOfPropertyChange(() => ButtonVSJBackground);
            NotifyOfPropertyChange(() => ButtonSmeneBackground);
            NotifyOfPropertyChange(() => ButtonRadniciBackground);
            NotifyOfPropertyChange(() => ButtonVozilaBackground);
            NotifyOfPropertyChange(() => ButtonInspektoriBackground);
            NotifyOfPropertyChange(() => ButtonIntervencijeBackground);
            NotifyOfPropertyChange(() => ButtonKomandiriBackground);
            NotifyOfPropertyChange(() => ButtonAlatiBackground);
        }
    }
}
