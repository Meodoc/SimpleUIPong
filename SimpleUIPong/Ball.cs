using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SimpleUIPong
{
    public class Ball
    {
        private readonly Canvas rootCanvas;

        public Rectangle Rect { get; set; }
        public Vector Dir { get; set; } = new Vector(-Constants.BALL_SPEED, 0);

        private Vector pos;

        public Ball(Canvas rootCanvas)
        {
            this.rootCanvas = rootCanvas;
            this.Rect = CreatePongBall();
            this.pos = new Vector(
                (double) this.Rect.GetValue(Canvas.LeftProperty),
                (double) this.Rect.GetValue(Canvas.TopProperty)
            );
        }

        public Ball(Canvas rootCanvas, Rectangle rect) : this(rootCanvas)
        {
            this.Rect = rect;
        }

        public void UpdatePosition()
        {
            this.pos.X += Dir.X;
            this.pos.Y += Dir.Y;

            this.Rect.SetValue(Canvas.LeftProperty, pos.X);
            this.Rect.SetValue(Canvas.TopProperty, pos.Y);
        }

        public Rectangle CreatePongBall()
        {
            Rectangle ball = new Rectangle {Height = Constants.BALL_LENGTH, Width = Constants.BALL_LENGTH};

            // Create brushes
            //SolidColorBrush redBrush = new SolidColorBrush();
            //redBrush.Color = Colors.Red;
            SolidColorBrush blackBrush = new SolidColorBrush {Color = Colors.Black};

            // Set stroke
            ball.StrokeThickness = 2;
            ball.Stroke = blackBrush;

            // Fill rectangle with blue color  
            ball.Fill = blackBrush;

            // Add Rectangle to the Grid.  
            rootCanvas.Children.Add(ball);
            Canvas.SetTop(ball, Constants.CANVAS_HEIGHT / 2 - ball.Height / 2);
            Canvas.SetLeft(ball, Constants.CANVAS_WIDTH / 2 - ball.Width / 2);
            return ball;
        }
    }
}