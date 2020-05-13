using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SimpleUIPong
{
    public class Player
    {
        private readonly Canvas rootCanvas;

        public Rectangle Rect { get; set; }


        public Player(Canvas rootCanvas)
        {
            this.rootCanvas = rootCanvas;
            this.Rect = CreatePlayerRect();
        }

        public Player(Canvas rootCanvas, Rectangle rect) : this(rootCanvas)
        {
            this.Rect = rect;
        }


        private Rectangle CreatePlayerRect()
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

            // Add Rectangle to the Grid.  
            rootCanvas.Children.Add(rectangle);
            Canvas.SetTop(rectangle, Constants.CANVAS_HEIGHT / 2 - rectangle.Height / 2);
            Canvas.SetLeft(rectangle, 20);
            return rectangle;
        }

    }
}