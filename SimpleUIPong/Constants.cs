﻿using System.Windows;

namespace SimpleUIPong
{
    static class Constants
    {
        public const int REFRESH_RATE = 1;

        public const int PLAYER_WIDTH = 20;
        public const int PLAYER_HEIGHT = 200;
        public const int PLAYER_SIDE_MARGIN = 20;

        public const int BALL_LENGTH = 15;

        public const int WINDOW_WIDTH = 800;
        public const int WINDOW_HEIGHT = 600;

        public const int CANVAS_WIDTH = 700;
        public const int CANVAS_HEIGHT = 500;

        public const int WIN_LABEL_HEIGHT = 50;
        public const int WIN_LABEL_WIDTH = 150;
        public const int WIN_LABEL_FONTSIZE = 20;

        public const int PLAYER_SPEED = 5;
        public const int ENEMY_SPEED = 3;
        public const int BALL_SPEED = 1;

        public static readonly Vector VEC_UP = new Vector(0, -1);
        public static readonly Vector VEC_DOWN = new Vector(0, 1);
        public static readonly Vector VEC_RIGHT = new Vector(1, 0);
        public static readonly Vector VEC_LEFT = new Vector(-1, 0);
    }
}