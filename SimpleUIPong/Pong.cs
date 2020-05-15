using System;
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
            debugLabel.Content = "Player Y + rect.Height: " + player.Pos.Y + player.Rect.Height;

            if (collidesWithPlayer())
            {
                switch (GetPlayerCollisionSide())
                {
                    case CollisionSide.RIGHT:
                        ball.SetX(player.Pos.X + player.Rect.Width);
                        ball.Reflect(Constants.VEC_RIGHT);
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
        }

        private void HandleEnemyCollision()
        {

            if (ball.Pos.X + ball.Rect.Width > enemy.Pos.X &&
                ball.Pos.Y + ball.Rect.Height > enemy.Pos.Y && ball.Pos.Y < enemy.Pos.Y + enemy.Rect.Height)
                ball.Reflect(Constants.VEC_LEFT);
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
                StopTimerAndFinishGame(false);

            // Right border
            if (ball.Pos.X + ball.Rect.Width > Constants.CANVAS_WIDTH)
                StopTimerAndFinishGame(true);
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
            else
                return top ? CollisionSide.TOP : CollisionSide.BOTTOM;
            
        }

        private bool collidesWithPlayer()
        {
            return ball.Pos.X < player.Pos.X + player.Rect.Width &&
                   ball.Pos.Y + ball.Rect.Height > player.Pos.Y &&
                   ball.Pos.Y < player.Pos.Y + player.Rect.Height;
        }
    }
}