using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PongLegacy
{
    class Ball:SpriteTexture2D
    {
        public int Radius { get; set; }
        public Vector2 Speed { get; set; }
        public Rectangle HitBox{ get; set; }
        public Pong Pong { get; set; }

        public Ball(Pong pong)
        {

        }

        public void Update()
        {
            
        }
        public Boolean checkPlayerColision(Player player)
        {
            if (this.HitBox.Intersects(player.HitBox)) ;
            return false;
        }
    }
}
