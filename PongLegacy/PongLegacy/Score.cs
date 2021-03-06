﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongLegacy
{
    public class Score : SpriteText
    {
        private int _Value;
        public int Value
        {
            set { this.text = this._Value.ToString(); this._Value = value; }
            get { return this._Value; }
        }
        //Initialisation du score de type SpriteText avec une Value de type int
        public Score(Vector2 position) : base(position, Color.White, 1.ToString())
        {
            this.Value = 1;
        }
    }
}
