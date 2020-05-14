using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SimpleUIPong
{
    public class Player
    {
        private readonly Canvas rootCanvas;

        public Rectangle Rect { get; set; }

        public Vector Pos { get; set; }

        public Player(Canvas rootCanvas)
        {
            this.rootCanvas = rootCanvas;
            this.Rect = CreatePlayerRect();
            this.Pos = new Vector(
                (double) this.Rect.GetValue(Canvas.LeftProperty),
                (double) this.Rect.GetValue(Canvas.TopProperty)
            );
        }

        public Player(Canvas rootCanvas, Rectangle rect) : this(rootCanvas)
        {
            this.Rect = rect;
        }

        public void UpdatePosition(double y)
        {
            this.Pos = new Vector(Pos.X, Pos.Y + y);

            this.Rect.SetValue(Canvas.LeftProperty, Pos.X);
            this.Rect.SetValue(Canvas.TopProperty, Pos.Y);
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