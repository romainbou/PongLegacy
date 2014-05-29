using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongLegacy
{
    public class Team
    {
        public Conf.TeamSide Side { get; set; }
        public List<Player> Players { get; set; }
        public int Score { get; set; }
        public Pong Pong { get; set; }

        public Team(Conf.TeamSide side,int nbPlayer, Conf.InteligenceType type, Pong pong)
        {
            this.Players = new List<Player>();
            this.Score = 0;
            this.Pong = pong;
            this.Side = side;
            this.Players.Add(new Player(this, Conf.PlayerPosition.BACK, type));
            if (nbPlayer == 2)
            {
                this.Players.Add(new Player(this, Conf.PlayerPosition.FRONT, type));
            }
        }
    }
}
