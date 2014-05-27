using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongLegacy
{
    class Team
    {
        public Conf.TeamSide Side { get; set; }
        public List<Player> Players { get; set; }
        public int Score { get; set; }
    }
}
