using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace LeagueInfo
{
    class ConverterWin : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool win = (bool)value;
            if (win)
                return new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
            else
                return new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var cor = (SolidColorBrush)value;
            if (cor == new SolidColorBrush(Color.FromArgb(255, 0, 255, 0)))
                return true;
            else
                return false;
        }
    }
}
