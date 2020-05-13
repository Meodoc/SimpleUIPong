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

        public MainWindow()
        {
            InitializeComponent();
            InitializeRootCanvas();
            AddCanvasBorder();
            new Pong(RootCanvas);
        }

        private void InitializeRootCanvas()
        {
            RootCanvas.Width = Constants.CANVAS_WIDTH;
            RootCanvas.Height = Constants.CANVAS_HEIGHT;
            RootCanvas.Background = Brushes.Transparent;
            RootCanvas.Focusable = true;
            RootCanvas.Focus();
        }


        public void AddCanvasBorder()
        {
            Rectangle border = new Rectangle {Width = Constants.CANVAS_WIDTH, Height = Constants.CANVAS_HEIGHT};
            SolidColorBrush blackBrush = new SolidColorBrush {Color = Colors.Black};
            border.StrokeThickness = 1;
            border.Stroke = blackBrush;
            RootCanvas.Children.Add(border);
            Canvas.SetTop(border, 0);
            Canvas.SetLeft(border, 0);
        }
    }
}