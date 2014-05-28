using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongLegacy
{
    public class ArtificialPlayerControler:IPlayerControler
    {
        public ArtificialPlayerControler(Player player): base(player)
        {

        }
        public override void MoveUp()
        {
            this.Player.MoveUp();
        }
        public override void MoveDown()
        {
            this.Player.MoveDown();
        }
        public override void Update()
        {
            if (this.Player.position.X + Conf.BAT_HEIGHT / 2 < this.Player.Team.Pong.Ball.position.Y)
            {
                this.MoveDown();
            }
            else
            {
                this.MoveUp();
            }
        }
    }
}
