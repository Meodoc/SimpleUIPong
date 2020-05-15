using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SimpleUIPong
{
    public static class WpfElementTemplates
    {
        public static Rectangle CreateEnemyRect()
        {
            Rectangle rectangle = new Rectangle {Height = Constants.PLAYER_HEIGHT, Width = Constants.PLAYER_WIDTH};

            // Create brushes
            SolidColorBrush redBrush = new SolidColorBrush {Color = Colors.Red};
            SolidColorBrush blackBrush = new SolidColorBrush {Color = Colors.Black};

            // Set stroke
            rectangle.StrokeThickness = 2;
            rectangle.Stroke = blackBrush;

            // Fill rectangle with blue color  
            rectangle.Fill = redBrush;

            return rectangle;
        }

        public static Rectangle CreatePlayerRect()
        {
            Rectangle rectangle = new Rectangle {Height = Constants.PLAYER_HEIGHT, Width = Constants.PLAYER_WIDTH};

            // Create brushes
            SolidColorBrush blueBrush = new SolidColorBrush {Color = Colors.Blue};
            SolidColorBrush blackBrush = new SolidColorBrush {Color = Colors.Black};

            // Set stroke
            rectangle.StrokeThickness = 2;
            rectangle.Stroke = blackBrush;

            // Fill rectangle with blue color  
            rectangle.Fill = blueBrush;

            return rectangle;
        }

        public static Rectangle CreatePongBall()
        {
            Rectangle ball = new Rectangle {Height = Constants.BALL_LENGTH, Width = Constants.BALL_LENGTH};

            // Create brush
            SolidColorBrush blackBrush = new SolidColorBrush {Color = Colors.Black};

            // Set stroke
            ball.StrokeThickness = 2;
            ball.Stroke = blackBrush;

            // Fill rectangle with blue color  
            ball.Fill = blackBrush;

            return ball;
        }
    }
}