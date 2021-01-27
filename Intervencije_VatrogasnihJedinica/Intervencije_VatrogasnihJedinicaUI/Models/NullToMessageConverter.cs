using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Intervencije_VatrogasnihJedinicaUI.Models
{
    public class NullToMessageConverter : IValueConverter
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
            else if (parameter.ToString() == "Dodaj Komandira")
            {
                if (uvidjaj == null)
                {
                    return "Dodaj Komandira";
                }
                return "Informacije o Komandiru";
            }
            
            return "";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}