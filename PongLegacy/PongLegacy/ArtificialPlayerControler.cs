using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongLegacy
{
    public class ArtificialPlayerControler : IPlayerControler
    {
        public ArtificialPlayerControler(Player player)
            : base(player)
        {
            this.Player.IsAccelerating = true;
        }

        public override void MoveUp()
        {
            this.Player.IsAccelerating = true;
            this.Player.MoveUp();
        }
        public override void MoveDown()
        {
            this.Player.IsAccelerating = true;
            this.Player.MoveDown();
        }

        //Mouvement automatique du joueur vers le haut ou le bas en fonction de la position de la balle.
        public override void Update()
        {
            if (this.Player.position.Y + Conf.BAT_HEIGHT / 2 < this.Player.Team.Pong.Ball.position.Y - 20)
            {
                this.MoveDown();
            }
            else if (this.Player.position.Y + Conf.BAT_HEIGHT / 2 > this.Player.Team.Pong.Ball.position.Y + 20)
            {
                this.MoveUp();
            }
        }


        
    }
}
