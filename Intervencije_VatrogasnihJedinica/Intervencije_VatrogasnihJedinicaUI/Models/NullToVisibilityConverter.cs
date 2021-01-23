using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Intervencije_VatrogasnihJedinicaUI.Models
{
    public class NullToVisibilityConverter : IValueConverter
    {
        public object Convert(object uvidjaj, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter.ToString() == "DodavanjeIliIzmenaUvidjaja")
            {
                if (uvidjaj == null)
                {
                    return "Dodaj";
                }
                return "Izmeni";
            }
            else if (parameter.ToString() == "DodajUvidjajZaIntervenciju")
            {
                if (uvidjaj == null)
                {
                    return "Dodaj informacije o uvidjaj";
                }
                return "Informacije o uvidjaju";
            }
            return "";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}