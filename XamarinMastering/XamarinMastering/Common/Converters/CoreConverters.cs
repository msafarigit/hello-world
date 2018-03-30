using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace XamarinMastering.Common.Converters
{
    public sealed class LabelFontWeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((string)value + "").Contains("1") ? FontAttributes.Bold : FontAttributes.Italic;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

    public sealed class AgoLabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime articleDateTime = ((DateTime)value).ToUniversalTime();
            int minDifference = (int)(DateTime.Now.ToUniversalTime() - articleDateTime).TotalMinutes;
            if (minDifference == default(int))
                return string.Format("Updated {0:dddd h:mm tt} GMT", (DateTime)value);
            return (minDifference > 60) ? "more than ahour ago" : minDifference + " minutes ago";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
