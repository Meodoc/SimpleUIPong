using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace SimpleUIPong
{
    public class Pong
    {
        private readonly Canvas rootCanvas;
        
        private Player player;
        private Enemy enemy;
        private Ball ball;


        private Label debugLabel;

        public Pong(Canvas rootCanvas, Label debugLabel)
        {
            this.rootCanvas = rootCanvas;
            this.player = new Player(rootCanvas);
            this.enemy = new Enemy(rootCanvas);
            this.ball = new Ball(rootCanvas);

            this.debugLabel = debugLabel;

            InitKeyHandlers();
            InitAndStartTimer();

            // TODO: make keyDown refresh with the clock somehow
        }

        private void Run(object sender, EventArgs e)
        {
            ball.UpdatePosition();
            CheckCollision();
        }

        private void CheckCollision()
        {
            CheckBorderCollision();
        }

        private void CheckBorderCollision()
        {
            debugLabel.Content = ball.Pos.Y;
            // Top border
            if (ball.Pos.Y < 0)
                ball.Reflect(Constants.VEC_DOWN);

            // Bottom border
            if (ball.Pos.Y + ball.Rect.Height > Constants.CANVAS_HEIGHT)
                ball.Reflect(Constants.VEC_UP);
        }

        private void InitAndStartTimer()
        {
            DispatcherTimer timer = new DispatcherTimer {Interval = TimeSpan.FromMilliseconds(Constants.REFRESH_RATE)};
            timer.Tick += Run;
            timer.Start();
        }

        private void InitKeyHandlers()
        {
            this.rootCanvas.KeyDown += PlayerMovementHandler;
        }

        private void PlayerMovementHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                Canvas.SetTop(this.player.Rect, (double)this.player.Rect.GetValue(Canvas.TopProperty) + 10);
            }

            if (e.Key == Key.Up)
            {
                Canvas.SetTop(this.player.Rect, (double)this.player.Rect.GetValue(Canvas.TopProperty) - 10);
            }
        }
    }
}