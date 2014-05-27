using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PongLegacy
{
    class Player
    {
        public int BatWidth { get; set; }
        public Color Color { get; set; }
        public Vector2 Position { get; set; }
        public Team Team { get; set; }
        public Rectangle HitBox { get; set; }

    }
}
