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
        public Vector Dir { get; set; } = new Vector(-Constants.BALL_SPEED, Constants.BALL_SPEED);

        public Vector Pos { get; set; }

        public Ball(Canvas rootCanvas)
        {
            this.rootCanvas = rootCanvas;
            this.Rect = CreatePongBall();
            this.Pos = new Vector(
                (double) this.Rect.GetValue(Canvas.LeftProperty),
                (double) this.Rect.GetValue(Canvas.TopProperty)
            );
        }

        public void UpdatePosition()
        {
            this.Pos = new Vector(Pos.X + Dir.X, Pos.Y + Dir.Y);

            this.Rect.SetValue(Canvas.LeftProperty, Pos.X);
            this.Rect.SetValue(Canvas.TopProperty, Pos.Y);
        }

        public void Reflect(Vector normalVec)
        {
            Vector n = normalVec; 
            n.Normalize();
            Vector b = Dir; 
            b.Normalize();

            Vector newDir = Vector.Subtract(b, Vector.Multiply(2 * Utils.DotProduct(n, b), n));
            this.Dir = Vector.Multiply(Constants.BALL_SPEED, newDir);
        }

        public void SetX(double x)
        {
            this.Pos = new Vector(x, Pos.Y);
        }

        public void SetY(double y)
        {
            this.Pos = new Vector(Pos.X, y);
        }

        public void UpdateX(double x)
        {
            this.SetX(x);
            this.Rect.SetValue(Canvas.LeftProperty, Pos.X);
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