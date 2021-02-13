using System;
using System.Globalization;
using System.Windows.Data;

namespace Intervencije_VatrogasnihJedinicaUI.Models
{
    public class NullToIsReadOnlyConverter : IValueConverter
    {
        public object Convert(object obj, Type targetType, object parameter, CultureInfo culture)
        {
            if (obj != null)
            {
                return false;
            }
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}