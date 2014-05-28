using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongLegacy
{
    public static class Conf
    {

        public const String GAME_NAME = "PONG LEGACY";
        public const String DEFAULT_FONT = "35_Corbel";

        public const int BAT_WIDTH = 12;
        public const int BAT_HEIGHT = 70;
        public const int PLAYER_SPEED = 20;
        public const int WINDOW_WIDTH = 1000;
        public const int WINDOW_HEIGHT = 600;
        public const int BACK_PLAYER_MARGIN = 50;
        public const int FRONT_PLAYER_MARGIN = 250;

        public const int BUTTON_WIDTH = 100;
        public const int BUTTON_HEIGHT = 50;


        /* ENUMS */
        public  enum GameState { MENU, START, PLAY, PAUSE, END };
        public  enum TeamSide { LEFT, RIGHT };

        public enum PlayerPosition { FRONT, BACK };
        public enum InteligenceType { HUMAN, IA};
    }
}
