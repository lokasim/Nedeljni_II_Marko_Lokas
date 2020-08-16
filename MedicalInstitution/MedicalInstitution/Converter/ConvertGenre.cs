using System;
using System.Globalization;
using System.Windows.Data;

namespace MedicalInstitution.Converter
{
    public class ConvertGenre : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //krace resenje
            return (parameter == value);
            //if (value == null || parameter == null)
            //    return false;

            //string checkValue = value.ToString();
            //string targetValue = parameter.ToString();
            //return checkValue.Equals(targetValue,
            //         StringComparison.InvariantCultureIgnoreCase);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //krace resenje
            return (bool)value ? parameter : null;
            //if (value == null || parameter == null)
            //    return null;

            //bool useValue = (bool)value;
            //string targetValue = parameter.ToString();
            //if (useValue)
            //    return Enum.Parse(targetType, targetValue);

            //return null;
        }
    }
}
