using Caliburn.Micro;

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

        public void Smene()
        {
            manager.ShowDialog(new SmeneViewModel(), null, null);
        }

        public void Alati()
        {
            manager.ShowDialog(new AlatiViewModel(), null, null);
        }

        public void Intervencije()
        {
            manager.ShowDialog(new IntervencijeViewModel(), null, null);
        }

        public void Inspektori()
        {
            manager.ShowDialog(new InspektoriViewModel(), null, null);
        }
        
        public void Komandiri()
        {
            manager.ShowDialog(new KomandiriViewModel(), null, null);
        }
    }
}
