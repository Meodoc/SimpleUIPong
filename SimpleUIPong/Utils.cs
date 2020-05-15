using System.Windows;
using System.Windows.Data;

namespace SimpleUIPong
{
    public class Utils
    {
        public static double DotProduct(Vector v1, Vector v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y;
        }
    }

    public class MarginConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return new Thickness(
                Constants.CANVAS_WIDTH / 2 - Constants.WIN_LABEL_WIDTH / 2,
                Constants.CANVAS_HEIGHT / 2 - Constants.WIN_LABEL_HEIGHT / 2,
                0,
                0
            );
        }

        public object ConvertBack(object value, System.Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}