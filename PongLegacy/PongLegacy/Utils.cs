using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongLegacy
{
    public class Utils
    {
        public static Vector2 rotate(Double angle, Vector2 vector)
        {
            Vector2 returned = new Vector2();
            returned.X = (int)(vector.X * Math.Cos(angle) - vector.Y * Math.Sin(angle));
            returned.Y = (int)(vector.Y * Math.Cos(angle) + vector.X * Math.Sin(angle));
            return returned;
        }
    }
}
