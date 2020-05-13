using System.CodeDom;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SimpleUIPong
{
    public class Enemy
    {
        private readonly Canvas rootCanvas;

        public Rectangle Rect { get; set; }


        public Enemy(Canvas rootCanvas)
        {
            this.rootCanvas = rootCanvas;
            this.Rect = CreateEnemyRect();
        }

        public Enemy(Canvas rootCanvas, Rectangle rect) : this(rootCanvas)
        {
            this.Rect = rect;
        }

        public Rectangle CreateEnemyRect()
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

            // Add Rectangle to the Grid.  
            rootCanvas.Children.Add(rectangle);
            Canvas.SetTop(rectangle, Constants.CANVAS_HEIGHT / 2 - rectangle.Height / 2);
            Canvas.SetRight(rectangle, 20);
            return rectangle;
        }

    }
}