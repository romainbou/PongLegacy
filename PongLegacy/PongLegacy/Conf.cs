using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongLegacy
{
    public static class Conf
    {

        public const String GAME_NAME = "PONG LEGACY";
        public const String PAUSE_NAME = "PAUSE - Press Space to continue";
        public const String DEFAULT_FONT = "35_Corbel";

        public const int BAT_WIDTH = 12;
        public const int BAT_HEIGHT = 80;
        public const int PLAYER_ACC = 1;
        public const int PLAYER_INIT_SPEED = 2;
        public const int PLAYER_MAX_SPEED = 12;
        public const int TEAM_LEFT_SCORE_POSITION_X = WINDOW_WIDTH / 2 - 120;
        public const int TEAM_RIGHT_SCORE_POSITION_X = WINDOW_WIDTH / 2 + 20;
        public const int TEAM_SCORE_POSITION_Y = 5;
        public const int WINDOW_WIDTH = 1000;
        public const int WINDOW_HEIGHT = 600;
        public const int BACK_PLAYER_MARGIN = 50;
        public const int FRONT_PLAYER_MARGIN = 250;
        public const int KEY_CONTROL_PICTURE_MARGIN_LEFT = BAT_WIDTH + 10;
        public const int KEY_CONTROL_PICTURE_MARGIN_RIGHT = 40 + 10;
        public const int KEY_CONTROL_PICTURE_MARGIN_TOP = (120 - BAT_HEIGHT)/2;
        public const int MIDDLE_LINE_WIDTH = 2;

        public const int BUTTON_WIDTH = 250;
        public const int BUTTON_HEIGHT = 70;


        /* ENUMS */
        public  enum GameState { MENU, START, PLAY, PAUSE, END };
        public  enum TeamSide { LEFT, RIGHT };

        public enum PlayerPosition { FRONT, BACK };
        public enum InteligenceType { HUMAN, IA};

        public class PlayerColor
        {
            public const String RED = "redPixel";
            public const String BLUE = "bluePixel";
            public const String GREEN = "greenPixel";
            public const String YELLOW = "yellowPixel";
        }
    }
}
