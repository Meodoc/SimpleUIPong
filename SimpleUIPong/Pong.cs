﻿using System;
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


        public Pong(Canvas rootCanvas)
        {
            this.rootCanvas = rootCanvas;
            this.player = new Player(rootCanvas);
            this.enemy = new Enemy(rootCanvas);
            this.ball = new Ball(rootCanvas);

            InitKeyHandlers();
            InitAndStartTimer();

            // TODO: make keyDown refresh with the clock somehow
        }

        private void Run(object sender, EventArgs e)
        {
            ball.UpdatePosition();
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
                Canvas.SetTop(this.player.Rect, (double)this.player.Rect.GetValue(Canvas.TopProperty) + 10);
            }

            if (e.Key == Key.Up)
            {
                Canvas.SetTop(this.player.Rect, (double)this.player.Rect.GetValue(Canvas.TopProperty) - 10);
            }
        }
    }
}