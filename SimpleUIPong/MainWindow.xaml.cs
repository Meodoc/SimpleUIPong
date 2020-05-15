using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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
            new Pong(this, RootCanvas, WinnerMessage);
        }

        public void AddKeyUpListener(KeyEventHandler listener)
        {
            KeyUp += listener;
        }

        public void AddKeyDownListener(KeyEventHandler listener)
        {
            KeyDown += listener;
        }
    }
}