using System.CodeDom;
using System.Windows;

namespace SimpleUIPong
{
    static class Constants
    {
        public const double REFRESH_RATE = 1;

        public const int PLAYER_WIDTH = 20;
        public const int PLAYER_HEIGHT = 200;
        public const int PLAYER_SIDE_MARGIN = 20;

        public const int BALL_LENGTH = 15;

        public const int WINDOW_WIDTH = 1200;
        public const int WINDOW_HEIGHT = 800;

        public const int CANVAS_WIDTH = 1185;
        public const int CANVAS_HEIGHT = 760;

        public const int WIN_LABEL_HEIGHT = 100;
        public const int WIN_LABEL_WIDTH = 1000;
        public const int WIN_LABEL_FONTSIZE = 50;

        public const int RETRY_LABEL_HEIGHT = 50;
        public const int RETRY_LABEL_WIDTH = 400;
        public const int RETRY_LABEL_FONTSIZE = 25;

        public const double PLAYER_SPEED = 6;
        public const int ENEMY_SPEED = 5;
        public const double BALL_SPEED = 12;

        // Specifies the reaction difference threshold between ball and enemy rectangle edge
        public const int ENEMY_SMARTNESS = 35;

        // Angle of random reflection vector on player or enemy in degrees (half angle)
        public const int RANDOM_VEC_ANGLE = 37;

        public static readonly Vector VEC_UP = new Vector(0, -1);
        public static readonly Vector VEC_DOWN = new Vector(0, 1);
        public static readonly Vector VEC_RIGHT = new Vector(1, 0);
        public static readonly Vector VEC_LEFT = new Vector(-1, 0);
    }
}