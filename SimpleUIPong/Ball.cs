using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SimpleUIPong
{
    public class Ball
    {
        private readonly Canvas rootCanvas;
        private Vector dir;

        public Rectangle Rect { get; set; }

        public Vector Dir
        {
            get => dir;
            set => dir = Vector.Multiply(Constants.BALL_SPEED, value);
        }

        public Vector Pos { get; set; }

        public Ball(Canvas rootCanvas)
        {
            this.rootCanvas = rootCanvas;
            this.Rect = InitPongBall();
            this.Pos = new Vector(
                (double) this.Rect.GetValue(Canvas.LeftProperty),
                (double) this.Rect.GetValue(Canvas.TopProperty)
            );
            this.Dir = Utils.RandDirVecInRange(SimpleUIPong.Dir.LEFT, Constants.RANDOM_VEC_ANGLE);
        }

        public void UpdatePosition()
        {
            this.Pos = new Vector(Pos.X + Dir.X, Pos.Y + Dir.Y);

            this.Rect.SetValue(Canvas.LeftProperty, Pos.X);
            this.Rect.SetValue(Canvas.TopProperty, Pos.Y);
        }

        public void ResetPosition()
        {
            this.Pos = new Vector(Constants.CANVAS_WIDTH / 2 - Rect.Width / 2, Constants.CANVAS_HEIGHT / 2 - Rect.Height / 2);

            this.Rect.SetValue(Canvas.LeftProperty, Pos.X);
            this.Rect.SetValue(Canvas.TopProperty, Pos.Y);
        }

        public void Reflect(Vector normalVec)
        {
            Vector n = normalVec; 
            n.Normalize();
            Vector b = Dir; 
            b.Normalize();

            this.Dir = Vector.Subtract(b, Vector.Multiply(2 * Utils.DotProduct(n, b), n));
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

        private Rectangle InitPongBall()
        {
            Rectangle ball = WpfElementTemplates.CreatePongBall();
            rootCanvas.Children.Add(ball);
            Canvas.SetTop(ball, Constants.CANVAS_HEIGHT / 2 - ball.Height / 2);
            Canvas.SetLeft(ball, Constants.CANVAS_WIDTH / 2 - ball.Width / 2);
            return ball;
        }
    }
}