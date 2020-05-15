using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace SimpleUIPong
{
    public class Player
    {
        private readonly Canvas rootCanvas;

        public Rectangle Rect { get; set; }

        public Vector Pos { get; set; }

        public MoveDir Move { get; set; }

        public Player(Canvas rootCanvas)
        {
            this.rootCanvas = rootCanvas;
            this.Rect = InitPlayerRect();
            this.Pos = new Vector(
                (double) this.Rect.GetValue(Canvas.LeftProperty),
                (double) this.Rect.GetValue(Canvas.TopProperty)
            );
        }

        public void UpdatePosition()
        {
            if (Move == MoveDir.IDLE) return;

            this.Pos = GetClampedPosVector();
            this.Rect.SetValue(Canvas.LeftProperty, Pos.X);
            this.Rect.SetValue(Canvas.TopProperty, Pos.Y);
        }

        public void ResetPosition()
        {
            this.Pos = new Vector(Constants.PLAYER_SIDE_MARGIN, Constants.CANVAS_HEIGHT / 2 - Rect.Height / 2);

            this.Rect.SetValue(Canvas.LeftProperty, Pos.X);
            this.Rect.SetValue(Canvas.TopProperty, Pos.Y);
        }

        private Vector GetClampedPosVector()
        {
            double newY = Move switch
            {
                MoveDir.UP => Math.Max(0, Pos.Y - Constants.PLAYER_SPEED),
                MoveDir.DOWN => Math.Min(Constants.CANVAS_HEIGHT, Pos.Y + Rect.Height + Constants.PLAYER_SPEED) - Rect.Height,
                MoveDir.IDLE => Pos.Y,
                _ => throw new ArgumentOutOfRangeException()
            };

            return new Vector(Pos.X, newY);
        }

        private Rectangle InitPlayerRect()
        {
            Rectangle rectangle = WpfElementTemplates.CreatePlayerRect();
            rootCanvas.Children.Add(rectangle);
            Canvas.SetTop(rectangle, Constants.CANVAS_HEIGHT / 2 - rectangle.Height / 2);
            Canvas.SetLeft(rectangle, 20);
            return rectangle;
        }
    }
}