using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongLegacy
{
    class Player : SpriteTexture2D
    {
        public Team Team { get; set; }
        public Rectangle HitBox;

        public Player(Vector2 position, int height, Team team) : base(position,Conf.BAT_WIDTH,height)
        {
            this.Team = team;
            HitBox = new Rectangle();
            HitBox.Width = this.width;
            HitBox.Height = this.height;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, this.HitBox, Color.White);
        }

    }
}
