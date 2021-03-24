using Caliburn.Micro;
using System;
using System.Windows;

namespace Intervencije_VatrogasnihJedinicaUI.ViewModels
{
    public class UnosDatumaViewModel : Screen
    {
        private DateTime datum = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
        private DateTime? datumPoslednjeIntervencije;
        private DateTime datumPoslednjePromene;
        private string porukaGreskeZaDatumPremestaja = "";

        public UnosDatumaViewModel(DateTime? datumPoslednjeInter, DateTime datumPoslednjePromen)
        {
            NastaviPromenuSmene = false;
            datumPoslednjeIntervencije = datumPoslednjeInter;
            datumPoslednjePromene = datumPoslednjePromen;
        }

        public DateTime Datum { get => datum; set { datum = new DateTime(value.Year, value.Month, value.Day, 8, 0, 0); NotifyOfPropertyChange(() => Datum); } }
        public bool NastaviPromenuSmene { get; set; }
        public string PorukaGreskeZaDatumPremestaja { get => porukaGreskeZaDatumPremestaja; set { porukaGreskeZaDatumPremestaja = value; NotifyOfPropertyChange(() => PorukaGreskeZaDatumPremestaja); } }

        public void Potvrdi()
        {
            if (Validacija())
            {
                NastaviPromenuSmene = true;
                TryClose();
            }
        }

        public void Odustani()
        {
            NastaviPromenuSmene = false;
            TryClose();
        }

        private bool Validacija()
        {
            if (datum > DateTime.Now.AddDays(7))
            {
                PorukaGreskeZaDatumPremestaja = "Moguće je izabrati samo datum koji je prošao ili u narednih 7 dana!";
                return false;
            }
            else if (datum < datumPoslednjePromene)
            {
                PorukaGreskeZaDatumPremestaja = $"Zadnja promena je bila:{datumPoslednjePromene.ToShortDateString()}, moguće je uneti samo datum posle pomenutog!";
                return false;
            }
            else if (datumPoslednjeIntervencije != null && datum <= datumPoslednjeIntervencije)
            {
                PorukaGreskeZaDatumPremestaja = $"Radnik je učestvovao na intervenciji:{((DateTime)datumPoslednjeIntervencije).ToShortDateString()} sa prethodnom smenom, moguće je uneti samo datum posle pomenutog!";
                return false;
            }

            if (datum == datumPoslednjePromene)
            {
                var Result = MessageBox.Show($"Radnik je vec menjao smenu za ovaj datum! Da li želite ponovnu promenu smene za isti datum?", "Promena smene za isti datum", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (Result == MessageBoxResult.Yes)
                {
                    return true;
                }
                return false;
            }

            return true;
        }
    }
}
