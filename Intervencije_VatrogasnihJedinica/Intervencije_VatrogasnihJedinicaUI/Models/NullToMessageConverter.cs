﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace Intervencije_VatrogasnihJedinicaUI.Models
{
    public class NullToMessageConverter : IValueConverter
    {
        public object Convert(object uvidjaj, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter.ToString() == "DodajUvidjajZaIntervenciju")
            {
                if (uvidjaj == null)
                {
                    return "Dodaj informacije o uviđaju";
                }
                return "Informacije o uviđaju";
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