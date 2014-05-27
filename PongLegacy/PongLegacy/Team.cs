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

        public Team(Conf.TeamSide side)
        {
            this.Players = new List<Player>();
            this.Score = 0;
            this.Side = side;
        }
    }
}
