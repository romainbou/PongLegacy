using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongLegacy
{
    public static class Conf
    {

        public const String GAME_NAME = "PONG LEGACY";
        public const int BAT_WIDTH = 12;


        /* ENUMS */
        public  enum GameState { MENU, START, PLAY, PAUSE, END };
        public  enum TeamSide { LEFT, RIGHT };

    }
}
