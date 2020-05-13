using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SimpleUIPong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            CreatePlayerRect();
            CreateEnemyRect();
            CreatePongBall();
            
        }

        public void CreatePlayerRect()
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
            Canvas.SetTop(rectangle, 50);
            Canvas.SetLeft(rectangle, 10);
        }

        public void CreateEnemyRect()
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
            Canvas.SetTop(rectangle, 50);
            Canvas.SetRight(rectangle, 10);
        }

        public void CreatePongBall()
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
            Canvas.SetTop(ball, Constants.CANVAS_HEIGHT - ball.Height/2);
            Canvas.SetLeft(ball, Constants.CANVAS_WIDTH - ball.Width/2);
        }
    }
}