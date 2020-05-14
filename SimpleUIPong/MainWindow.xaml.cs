using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SimpleUIPong
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {

        public MainWindow()
        {
            InitializeComponent();

            RootCanvas.Focus();
            new Pong(RootCanvas, Debug, PlayerPos, WinnerMessage);
        }
    }

    //class MultiMarginConverter : IMultiValueConverter
    //{
    //    public object Convert(object[] values, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        return new Thickness(System.Convert.ToDouble(values[0]),
    //            System.Convert.ToDouble(values[1]),
    //            System.Convert.ToDouble(values[2]),
    //            System.Convert.ToDouble(values[3]));
    //    }

    //    public object[] ConvertBack(object value, System.Type[] targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        return null;
    //    }
    //}
}