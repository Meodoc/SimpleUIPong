using System.Windows.Controls;
using System.Windows.Input;

namespace SimpleUIPong
{
    public class Pong
    {
        private readonly Canvas rootCanvas;
        
        private Player player;
        private Enemy enemy;
        private Ball ball;

        public Pong(Canvas rootCanvas)
        {
            this.rootCanvas = rootCanvas;
            this.player = new Player(rootCanvas);
            this.enemy = new Enemy(rootCanvas);
            this.ball = new Ball(rootCanvas);

            InitKeyHandlers();
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