using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace TiCloud_Desktop.core.data.converters
{
    public class ActiveViewToBorderBrushConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // values[0] - ActiveViewModelName
            // values[1] - Tag przycisku
            if (values[0] is string activeViewName && values[1] is string expectedViewName)
            {
                return activeViewName == expectedViewName ? "Orange" : "Transparent";
            }
            return "Transparent";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
