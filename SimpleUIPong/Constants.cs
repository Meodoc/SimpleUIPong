using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SimpleUIPong
{
    static class Constants
    {
        public const int REFRESH_RATE = 1;

        public const int PLAYER_WIDTH = 20;
        public const int PLAYER_HEIGHT = 200;

        public const int BALL_LENGTH = 15;

        public const int CANVAS_WIDTH = 700;
        public const int CANVAS_HEIGHT = 500;

        public const int BALL_SPEED = 1;

        public static readonly Vector VEC_UP = new Vector(0, -1);
        public static readonly Vector VEC_DOWN = new Vector(0, 1);
    }
}
