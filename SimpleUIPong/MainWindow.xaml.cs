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
            this.player = new Player(RootCanvas, CreatePlayerRect());
            CreatePongBall();
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

        public Rectangle CreatePlayerRect()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Height = Constants.PLAYER_HEIGHT;
            rectangle.Width = Constants.PLAYER_WIDTH;

            // Create brushes
            SolidColorBrush blueBrush = new SolidColorBrush();
            blueBrush.Color = Colors.Blue;
            SolidColorBrush blackBrush = new SolidColorBrush();
            blackBrush.Color = Colors.Black;

            // Set stroke
            rectangle.StrokeThickness = 2;
            rectangle.Stroke = blackBrush;

            // Fill rectangle with blue color  
            rectangle.Fill = blueBrush;

            // Add Rectangle to the Grid.  
            RootCanvas.Children.Add(rectangle);
            Canvas.SetTop(rectangle, Constants.CANVAS_HEIGHT/2 - rectangle.Height/2);
            Canvas.SetLeft(rectangle, 20);
            return rectangle;
        }

        public Rectangle CreateEnemyRect()
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Height = Constants.PLAYER_HEIGHT;
            rectangle.Width = Constants.PLAYER_WIDTH;

            // Create brushes
            SolidColorBrush redBrush = new SolidColorBrush();
            redBrush.Color = Colors.Red;
            SolidColorBrush blackBrush = new SolidColorBrush();
            blackBrush.Color = Colors.Black;

            // Set stroke
            rectangle.StrokeThickness = 2;
            rectangle.Stroke = blackBrush;

            // Fill rectangle with blue color  
            rectangle.Fill = redBrush;

            // Add Rectangle to the Grid.  
            RootCanvas.Children.Add(rectangle);
            Canvas.SetTop(rectangle, Constants.CANVAS_HEIGHT/2 - rectangle.Height/2);
            Canvas.SetRight(rectangle, 20);
            return rectangle;
        }

        public Rectangle CreatePongBall()
        {
            Rectangle ball = new Rectangle();
            ball.Height = Constants.BALL_LENGTH;
            ball.Width = Constants.BALL_LENGTH;

            // Create brushes
            //SolidColorBrush redBrush = new SolidColorBrush();
            //redBrush.Color = Colors.Red;
            SolidColorBrush blackBrush = new SolidColorBrush();
            blackBrush.Color = Colors.Black;

            // Set stroke
            ball.StrokeThickness = 2;
            ball.Stroke = blackBrush;

            // Fill rectangle with blue color  
            ball.Fill = blackBrush;

            // Add Rectangle to the Grid.  
            RootCanvas.Children.Add(ball);
            Canvas.SetTop(ball, Constants.CANVAS_HEIGHT/2 - ball.Height/2);
            Canvas.SetLeft(ball, Constants.CANVAS_WIDTH/2 - ball.Width/2);
            return ball;
        }
    }
}