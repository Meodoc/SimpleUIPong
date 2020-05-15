using System;
using System.CodeDom;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SimpleUIPong
{
    public class Enemy
    {
        private readonly Canvas rootCanvas;

        public Rectangle Rect { get; set; }

        public Vector Pos { get; set; }

        public Enemy(Canvas rootCanvas)
        {
            this.rootCanvas = rootCanvas;
            this.Rect = InitEnemyRect();
            this.Pos = new Vector(
                 Constants.CANVAS_WIDTH - (double) this.Rect.GetValue(Canvas.RightProperty) - this.Rect.Width,
                (double) this.Rect.GetValue(Canvas.TopProperty)
            );
        }

        public void UpdatePosition(Ball ball)
        {
            this.Pos = GetClampedPosVector(ball);
            this.Rect.SetValue(Canvas.LeftProperty, Pos.X);
            this.Rect.SetValue(Canvas.TopProperty, Pos.Y);
        }

        public void ResetPosition()
        {
            this.Pos = new Vector(Constants.CANVAS_WIDTH - Constants.PLAYER_SIDE_MARGIN - Rect.Width, Constants.CANVAS_HEIGHT / 2 - Rect.Height / 2);

            this.Rect.SetValue(Canvas.LeftProperty, Pos.X);
            this.Rect.SetValue(Canvas.TopProperty, Pos.Y);
        }

        private Vector GetClampedPosVector(Ball ball)
        {

            double newY;
            if (BallIsAbove(ball))
                newY = Math.Max(0, Pos.Y - Constants.ENEMY_SPEED);
            else if (BallIsBelow(ball))
                newY = Math.Min(Constants.CANVAS_HEIGHT, Pos.Y + Rect.Height + Constants.ENEMY_SPEED) - Rect.Height;
            else
                newY = Pos.Y;

            return new Vector(Pos.X, newY);
        }

        private bool BallIsAbove(Ball ball)
        {
            return ball.Pos.Y + ball.Rect.Height < this.Pos.Y + Constants.ENEMY_SMARTNESS;
        }

        private bool BallIsBelow(Ball ball)
        {
            return ball.Pos.Y > this.Pos.Y + this.Rect.Height - Constants.ENEMY_SMARTNESS;
        }

        private Rectangle InitEnemyRect()
        {
            Rectangle rectangle = WpfElementTemplates.CreateEnemyRect();
            rootCanvas.Children.Add(rectangle);
            Canvas.SetTop(rectangle, Constants.CANVAS_HEIGHT / 2 - rectangle.Height / 2);
            Canvas.SetRight(rectangle, 20);
            return rectangle;
        }
    }
}