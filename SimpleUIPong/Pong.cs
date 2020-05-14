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
        private Label playerPosLabel;

        public Pong(Canvas rootCanvas, Label debugLabel, Label playerPosLabel)
        {
            this.rootCanvas = rootCanvas;
            this.player = new Player(rootCanvas);
            this.enemy = new Enemy(rootCanvas);
            this.ball = new Ball(rootCanvas);

            this.debugLabel = debugLabel;
            this.playerPosLabel = playerPosLabel;

            InitKeyHandlers();
            InitAndStartTimer();

            // TODO: make keyDown refresh with the clock somehow
            // TODO: make ball refelction from player random
            // TODO: clamp player movement
            // TODO: smooth player movement
        }

        private void Run(object sender, EventArgs e)
        {
            ball.UpdatePosition();
            UpdateEnemyPosition();
            HandleCollisions();
        }

        // Moves the enemy when ball is out of enemy range
        private void UpdateEnemyPosition()
        {
            // "Think" delay and slower movement than framerate
            if (ball.Pos.Y + ball.Rect.Width < enemy.Pos.Y)
                enemy.UpdatePosition(-10);
            else if (ball.Pos.Y > enemy.Pos.Y + enemy.Rect.Height)
                enemy.UpdatePosition(10);
        }

        private void HandleCollisions()
        {
            HandlePlayerCollision();
            HandleEnemyCollision();
            HandleBorderCollision();
        }

        private void HandlePlayerCollision()
        {
            playerPosLabel.Content = "X: " + enemy.Pos.X + " Y: " + enemy.Pos.Y;


            if (ball.Pos.X < player.Pos.X + player.Rect.Width &&
                ball.Pos.Y + ball.Rect.Height > player.Pos.Y && ball.Pos.Y < player.Pos.Y + player.Rect.Height)
                ball.Reflect(Constants.VEC_RIGHT);
        }

        private void HandleEnemyCollision()
        {

            Boolean trigger1 = ball.Pos.X + ball.Rect.Width > enemy.Pos.X;
            debugLabel.Content = "Ball X trigger: " + trigger1;
            if (ball.Pos.X + ball.Rect.Width > enemy.Pos.X &&
                ball.Pos.Y + ball.Rect.Height > enemy.Pos.Y && ball.Pos.Y < enemy.Pos.Y + enemy.Rect.Height)
                ball.Reflect(Constants.VEC_LEFT);
        }


        private void HandleBorderCollision()
        {
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
                player.UpdatePosition(10);
                Canvas.SetTop(this.player.Rect, player.Pos.Y);
            }

            if (e.Key == Key.Up)
            {
                player.UpdatePosition(-10);
                Canvas.SetTop(this.player.Rect, player.Pos.Y);
            }
        }
    }
}