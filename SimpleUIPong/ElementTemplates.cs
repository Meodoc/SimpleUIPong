using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SimpleUIPong
{
    public static class ElementTemplates
    {
        public static Rectangle CreateEnemyRect()
        {
            Rectangle rectangle = new Rectangle { Height = Constants.PLAYER_HEIGHT, Width = Constants.PLAYER_WIDTH };

            // Create brushes
            SolidColorBrush redBrush = new SolidColorBrush { Color = Colors.Red };
            SolidColorBrush blackBrush = new SolidColorBrush { Color = Colors.Black };

            // Set stroke
            rectangle.StrokeThickness = 2;
            rectangle.Stroke = blackBrush;

            // Fill rectangle with blue color  
            rectangle.Fill = redBrush;

            return rectangle;
        }

        public static Rectangle CreatePlayerRect()
        {
            Rectangle rectangle = new Rectangle { Height = Constants.PLAYER_HEIGHT, Width = Constants.PLAYER_WIDTH };

            // Create brushes
            SolidColorBrush blueBrush = new SolidColorBrush { Color = Colors.Blue };
            SolidColorBrush blackBrush = new SolidColorBrush { Color = Colors.Black };

            // Set stroke
            rectangle.StrokeThickness = 2;
            rectangle.Stroke = blackBrush;

            // Fill rectangle with blue color  
            rectangle.Fill = blueBrush;

            return rectangle;
        }
    }
}