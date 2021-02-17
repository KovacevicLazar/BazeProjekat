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
            ActivateItem(new VatrogasneJediniceViewModel());
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
            //manager.ShowDialog(new OpstineViewModel(), null, null);
            InicijalizacijaBoja();
            ButtonOpstineBackground = new SolidColorBrush(Colors.White);
            NotifyOfPropertyChange(() => ButtonOpstineBackground);
            ActivateItem(new OpstineViewModel());
        }

        public void VatrogasneJedinice()
        {
            //manager.ShowDialog(new VatrogasneJediniceViewModel(), null, null);
            InicijalizacijaBoja();
            ButtonVSJBackground = new SolidColorBrush(Colors.White);
            NotifyOfPropertyChange(() => ButtonVSJBackground);
            ActivateItem(new VatrogasneJediniceViewModel());
        }

        public void Vozila()
        {
            //manager.ShowDialog(new VozilaViewModel(), null, null);
            InicijalizacijaBoja();
            ButtonVozilaBackground = new SolidColorBrush(Colors.White);
            NotifyOfPropertyChange(() => ButtonVozilaBackground);
            ActivateItem(new VozilaViewModel());
        }

        public void Radnici()
        {
            // manager.ShowDialog(new RadniciViewModel(), null, null);
            InicijalizacijaBoja();
            ButtonRadniciBackground = new SolidColorBrush(Colors.White);
            NotifyOfPropertyChange(() => ButtonRadniciBackground);
            ActivateItem(new RadniciViewModel());
        }

        public void Smene()
        {
            //manager.ShowDialog(new SmeneViewModel(), null, null);
            InicijalizacijaBoja();
            ButtonSmeneBackground = new SolidColorBrush(Colors.White);
            NotifyOfPropertyChange(() => ButtonSmeneBackground);
            ActivateItem(new SmeneViewModel());
        }

        public void Alati()
        {
            //manager.ShowDialog(new AlatiViewModel(), null, null);
            InicijalizacijaBoja();
            ButtonAlatiBackground = new SolidColorBrush(Colors.White);
            NotifyOfPropertyChange(() => ButtonAlatiBackground);
            ActivateItem(new AlatiViewModel());
        }

        public void Intervencije()
        {
            //manager.ShowDialog(new IntervencijeViewModel(), null, null);
            InicijalizacijaBoja();
            ButtonIntervencijeBackground = new SolidColorBrush(Colors.White);
            NotifyOfPropertyChange(() => ButtonIntervencijeBackground);
            ActivateItem(new IntervencijeViewModel());
        }

        public void Inspektori()
        {
            //manager.ShowDialog(new InspektoriViewModel(), null, null);
            InicijalizacijaBoja();
            ButtonInspektoriBackground = new SolidColorBrush(Colors.White);
            NotifyOfPropertyChange(() => ButtonInspektoriBackground);
            ActivateItem(new InspektoriViewModel());
        }

        public void Komandiri()
        {
            //manager.ShowDialog(new KomandiriViewModel(), null, null);
            InicijalizacijaBoja();
            ButtonKomandiriBackground = new SolidColorBrush(Colors.White);
            NotifyOfPropertyChange(() => ButtonKomandiriBackground);
            ActivateItem(new KomandiriViewModel());
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
