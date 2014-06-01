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
        public Score Score { get; set; }
        public Pong Pong { get; set; }

        //Initialisation d'une équipe
        public Team(Conf.TeamSide side,int nbPlayer, Conf.InteligenceType type, Pong pong)
        {
            this.Players = new List<Player>();
            if (side == Conf.TeamSide.LEFT)
            {
                this.Score = new Score(new Vector2(Conf.TEAM_LEFT_SCORE_POSITION_X, Conf.TEAM_SCORE_POSITION_Y));
            }
            else
            {
                this.Score = new Score(new Vector2(Conf.TEAM_RIGHT_SCORE_POSITION_X, Conf.TEAM_SCORE_POSITION_Y));
            }
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
