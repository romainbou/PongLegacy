using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Net.Sockets;
using System.Net;

namespace PongLegacy
{
    public class MiddleLine : SpriteTexture2D
    {
        public Rectangle HitBox;

        //Création de la ligne médiane à travers un Rectangle
        public MiddleLine(int windowWidth, int windowHeight)
            : base(new Vector2(windowWidth / 2 - Conf.MIDDLE_LINE_WIDTH / 2, 0), Conf.MIDDLE_LINE_WIDTH, windowHeight)
        {
            HitBox = new Rectangle();
            HitBox.Width = this.width;
            HitBox.Height = this.height;
            HitBox.X = (int)this.position.X;
            HitBox.Y = (int)this.position.Y;
        }

        // Override de Draw pour afficher la ligne médiane à l'écran
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, this.HitBox, Microsoft.Xna.Framework.Color.White);
        }

    }
}
