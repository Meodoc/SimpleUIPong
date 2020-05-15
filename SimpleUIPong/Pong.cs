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

        private readonly DispatcherTimer timer = new DispatcherTimer {Interval = TimeSpan.FromMilliseconds(Constants.REFRESH_RATE)};
        
        private readonly Player player;
        private readonly Enemy enemy;
        private readonly Ball ball;

        private Label debugLabel;
        private Label playerPosLabel;
        private readonly Label winnerMsgLabel;

        public Pong(Canvas rootCanvas, Label debugLabel, Label playerPosLabel, Label winnerMsgLabel)
        {
            this.rootCanvas = rootCanvas;
            this.player = new Player(rootCanvas);
            this.enemy = new Enemy(rootCanvas);
            this.ball = new Ball(rootCanvas);

            this.debugLabel = debugLabel;
            this.playerPosLabel = playerPosLabel;
            this.winnerMsgLabel = winnerMsgLabel;

            InitKeyHandlers();
            InitAndStartTimer();

            // TODO: make keyDown refresh with the clock somehow
            // TODO: make ball refelction from player random
            // TODO: clamp player movement
            // TODO: smooth player movement
            // TODO: dynamic margin!

            // TODO: bug when ball enters from the side
            // TODO: keymap to handle simultaneous key inputs
        }

        private void Run(object sender, EventArgs e)
        {
            ball.UpdatePosition();
            player.UpdatePosition();
            enemy.UpdatePosition(ball);
            HandleCollisions();
        }

        // Moves the enemy when ball is out of enemy range
        private void UpdateEnemyPosition()
        {
            // "Think" delay and slower movement than framerate
            if (ball.Pos.Y + ball.Rect.Width < enemy.Pos.Y - 10)
                enemy.UpdatePosition(-10);
            else if (ball.Pos.Y > enemy.Pos.Y + enemy.Rect.Height + 10)
                enemy.UpdatePosition(10);
        }

        private void StopTimerAndFinishGame(bool won)
        {
            timer.Stop();
            winnerMsgLabel.Content = won ? "YOU WON" : "YOU LOST";
        }

        private void InitAndStartTimer()
        {
            timer.Tick += Run;
            timer.Start();
        }

        private void InitKeyHandlers()
        {
            this.rootCanvas.KeyDown += PlayerStartMovementHandler;
            this.rootCanvas.KeyUp += PlayerStopMovementHandler;
        }

        private void PlayerStartMovementHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
                player.Move = MoveDir.DOWN;

            if (e.Key == Key.Up)
                player.Move = MoveDir.UP;
        }

        private void PlayerStopMovementHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down || e.Key == Key.Up)
                player.Move = MoveDir.IDLE;
        }

        private void HandleCollisions()
        {
            HandlePlayerCollision();
            HandleEnemyCollision();
            HandleBorderCollision();
        }

        private void HandlePlayerCollision()
        {
            playerPosLabel.Content = "X: " + ball.Pos.X + " Y: " + ball.Pos.Y;


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

            // Left border
            if (ball.Pos.X < 0)
                StopTimerAndFinishGame(false);

            // Right border
            if (ball.Pos.X + ball.Rect.Width > Constants.CANVAS_WIDTH)
                StopTimerAndFinishGame(true);
        }
    }
}