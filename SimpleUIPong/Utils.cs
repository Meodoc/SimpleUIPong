using System;
using System.Runtime.InteropServices;
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

        public static Vector RandDirVecInRange(Dir dir, int angle)
        {
            Random r = new Random();
            double angleRad = ToRad(r.Next(-angle, angle));
            
            switch (dir)
            {
                case Dir.LEFT:
                    Vector v = new Vector(-Math.Cos(angleRad), Math.Sin(angleRad));
                    v.Normalize();
                    return v;
                case Dir.RIGHT:
                    v = new Vector(Math.Cos(angleRad), Math.Sin(angleRad));
                    v.Normalize();
                    return v;
                default:
                    throw new InvalidOperationException();
            }
        }

        public static double ToRad(double angle)
        {
            return (Math.PI / 180) * angle;
        }
    }



    public class WinLabelMarginConverter : IValueConverter
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


    public class RetryLabelMarginConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return new Thickness(
                Constants.CANVAS_WIDTH / 2 - Constants.RETRY_LABEL_WIDTH / 2,
                Constants.CANVAS_HEIGHT / 2 - Constants.RETRY_LABEL_HEIGHT / 2 + 100,
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

    public class PlayerEnemyCanvasTopConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return Constants.CANVAS_HEIGHT / 2 - Constants.PLAYER_HEIGHT / 2;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}