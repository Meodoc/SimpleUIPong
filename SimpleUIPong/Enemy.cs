﻿using System.CodeDom;
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

        public void UpdatePosition(double y)
        {
            this.Pos = new Vector(Pos.X, Pos.Y + y);

            this.Rect.SetValue(Canvas.LeftProperty, Pos.X);
            this.Rect.SetValue(Canvas.TopProperty, Pos.Y);
        }

        private Rectangle InitEnemyRect()
        {
            Rectangle rectangle = ElementTemplates.CreateEnemyRect();
            rootCanvas.Children.Add(rectangle);
            Canvas.SetTop(rectangle, Constants.CANVAS_HEIGHT / 2 - rectangle.Height / 2);
            Canvas.SetRight(rectangle, 20);
            return rectangle;
        }

    }
}