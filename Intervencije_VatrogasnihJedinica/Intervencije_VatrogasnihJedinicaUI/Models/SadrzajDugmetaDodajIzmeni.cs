using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Intervencije_VatrogasnihJedinicaUI.Models
{
    class SadrzajDugmetaDodajIzmeni : IValueConverter
    {
        public object Convert(object Object, Type targetType, object parameter, CultureInfo culture)
        {
            if (Object == null)
            {
                return "Dodaj";
            }
            return "Izmeni";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}