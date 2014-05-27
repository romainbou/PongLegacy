using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongLegacy
{
    class Bat : SpriteTexture2D
    {
        public Team Team { get; set; }

        public Bat(Vector2 position, int height, Team team) : base(position,Conf.BAT_WIDTH,height)
        {
            this.Team = team;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle rect = new Rectangle();
            rect.Width = this.width;
            rect.Height = this.height;

            spriteBatch.Draw(texture, position, rect, Color.White);
        }

    }
}
