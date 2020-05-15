using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace SimpleUIPong
{
    public class Pong
    {
        private readonly MainWindow mainWindow;
        private readonly Canvas rootCanvas;

        private DispatcherTimer timer = new DispatcherTimer {Interval = TimeSpan.FromMilliseconds(Constants.REFRESH_RATE)};
        
        private readonly Player player;
        private readonly Enemy enemy;
        private readonly Ball ball;

        private readonly Label winnerMsgLabel;
        private readonly Label retryMsgLabel;

        public Pong(MainWindow mainWindow, Canvas rootCanvas, Label winnerMsgLabel, Label retryMsgLabel)
        {
            this.mainWindow = mainWindow;
            this.rootCanvas = rootCanvas;
            this.player = new Player(rootCanvas);
            this.enemy = new Enemy(rootCanvas);
            this.ball = new Ball(rootCanvas);

            this.winnerMsgLabel = winnerMsgLabel;
            this.retryMsgLabel = retryMsgLabel;

            InitKeyHandlers();
            retryMsgLabel.Content = "Press ENTER to start";
        }

        private void Run(object sender, EventArgs e)
        {
            retryMsgLabel.Content = "";
            ball.UpdatePosition();
            player.UpdatePosition();
            enemy.UpdatePosition(ball);
            HandleCollisions();
        }

        private void InitAndStartTimer()
        {
            timer.Tick += Run;
            timer.Start();
        }

        private void StopTimerAndFinishGame(bool won)
        {
            timer.Stop();
            winnerMsgLabel.Content = won ? "YOU WON" : "COMPUTER WON";
            retryMsgLabel.Content = "Press ENTER to retry";
        }

        private void InitKeyHandlers()
        {
            mainWindow.AddKeyDownListener(PlayerStartMovementHandler);
            mainWindow.AddKeyUpListener(PlayerStopMovementHandler);
            mainWindow.AddKeyDownListener(RetryHandler);
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

        private void RetryHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Reset();

        }

        private void Reset()
        {
            this.timer.Stop();
            this.timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(Constants.REFRESH_RATE) };
            winnerMsgLabel.Content = "";
            retryMsgLabel.Content = "";

            player.ResetPosition();
            enemy.ResetPosition();
            ball.ResetPosition();

            InitAndStartTimer();
        }

        private void HandleCollisions()
        {
            HandlePlayerCollision();
            HandleEnemyCollision();
            HandleBorderCollision();
        }

        private void HandlePlayerCollision()
        {
            if (!CollidesWithPlayer()) return;

            switch (GetPlayerCollisionSide())
            {
                case CollisionSide.RIGHT:
                    ball.SetX(player.Pos.X + player.Rect.Width);
                    ball.Dir = Utils.RandDirVecInRange(Dir.RIGHT, Constants.RANDOM_VEC_ANGLE);
                    break;
                case CollisionSide.TOP:
                    ball.SetY(player.Pos.Y - ball.Rect.Height);
                    ball.Reflect(Constants.VEC_UP);
                    break;
                case CollisionSide.BOTTOM:
                    ball.SetY(player.Pos.Y + player.Rect.Height);
                    ball.Reflect(Constants.VEC_DOWN);
                    break;
            }
        }

        private void HandleEnemyCollision()
        {
            if (!CollidesWithEnemy()) return;

            switch (GetEnemyCollisionSide())
            {
                case CollisionSide.LEFT:
                    ball.SetX(enemy.Pos.X - ball.Rect.Width);
                    ball.Dir = Utils.RandDirVecInRange(Dir.LEFT, Constants.RANDOM_VEC_ANGLE);
                    break;
                case CollisionSide.TOP:
                    ball.SetY(enemy.Pos.Y - ball.Rect.Height);
                    ball.Reflect(Constants.VEC_UP);
                    break;
                case CollisionSide.BOTTOM:
                    ball.SetY(enemy.Pos.Y + enemy.Rect.Height);
                    ball.Reflect(Constants.VEC_DOWN);
                    break;
            }
        }


        private void HandleBorderCollision()
        {
            // Top border
            if (ball.Pos.Y < 0)
            {
                ball.SetY(0);
                ball.Reflect(Constants.VEC_DOWN);
            }

            // Bottom border
            if (ball.Pos.Y + ball.Rect.Height > Constants.CANVAS_HEIGHT)
            {
                ball.SetY(Constants.CANVAS_HEIGHT - ball.Rect.Height);
                ball.Reflect(Constants.VEC_UP);
            }

            // Left border
            if (ball.Pos.X < 0)
            {
                ball.UpdateX(0);
                StopTimerAndFinishGame(false);
            }


            // Right border
            if (ball.Pos.X + ball.Rect.Width > Constants.CANVAS_WIDTH)
            {
                ball.UpdateX(Constants.CANVAS_WIDTH - ball.Rect.Width);
                StopTimerAndFinishGame(true);
            }

        }

        private CollisionSide GetPlayerCollisionSide()
        {
            double dYTop = ball.Pos.Y + ball.Rect.Height - player.Pos.Y;
            double dYBottom = player.Pos.Y + player.Rect.Height - ball.Pos.Y;
            double dY = Math.Min(dYTop, dYBottom);
            bool top = dYTop < dYBottom;

            double dX = player.Pos.X + player.Rect.Width - ball.Pos.X;

            if (dY > dX)
                return CollisionSide.RIGHT;

            return top ? CollisionSide.TOP : CollisionSide.BOTTOM;
            
        }

        private CollisionSide GetEnemyCollisionSide()
        {
            double dYTop = ball.Pos.Y + ball.Rect.Height - enemy.Pos.Y;
            double dYBottom = enemy.Pos.Y + enemy.Rect.Height - ball.Pos.Y;
            double dY = Math.Min(dYTop, dYBottom);
            bool top = dYTop < dYBottom;

            double dX = ball.Pos.X + ball.Rect.Width - enemy.Pos.X;

            if (dY > dX)
                return CollisionSide.LEFT;

            return top ? CollisionSide.TOP : CollisionSide.BOTTOM;
        }

        private bool CollidesWithPlayer()
        {
            return ball.Pos.X < player.Pos.X + player.Rect.Width &&
                   ball.Pos.Y + ball.Rect.Height > player.Pos.Y &&
                   ball.Pos.Y < player.Pos.Y + player.Rect.Height;
        }

        private bool CollidesWithEnemy()
        {
            return ball.Pos.X + ball.Rect.Width > enemy.Pos.X &&
                   ball.Pos.Y + ball.Rect.Height > enemy.Pos.Y &&
                   ball.Pos.Y < enemy.Pos.Y + enemy.Rect.Height;
        }
    }
}