using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SimpleUIPong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {

        //private Rectangle player;
        //private Rectangle enemy;

        private Player player;
        private Enemy enemy;
        private Ball ball;


        public MainWindow()
        {
            InitializeComponent();

   
            RootCanvas.Width = Constants.CANVAS_WIDTH;
            RootCanvas.Height = Constants.CANVAS_HEIGHT;

            AddCanvasBorder();

            InitCanvasComponents();


            this.KeyDown += PlayerMovementHandler;

        }

        private void InitCanvasComponents()
        {
            this.player = new Player(RootCanvas);
            this.enemy = new Enemy(RootCanvas);
            this.ball = new Ball(RootCanvas);
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

        public void AddCanvasBorder()
        {
            Rectangle border = new Rectangle();
            border.Width = Constants.CANVAS_WIDTH;
            border.Height = Constants.CANVAS_HEIGHT;
            SolidColorBrush blackBrush = new SolidColorBrush();
            blackBrush.Color = Colors.Black;
            border.StrokeThickness = 1;
            border.Stroke = blackBrush;
            RootCanvas.Children.Add(border);
            Canvas.SetTop(border, 0);
            Canvas.SetLeft(border, 0);
        }

    }
}