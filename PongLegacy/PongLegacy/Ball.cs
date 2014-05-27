﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PongLegacy
{
    public class Ball:SpriteTexture2D
    {
        static int Radius =10;
        public Vector2 Speed { get; set; }
        public Rectangle HitBox{ get; set; }
        public Pong Pong { get; set; }

        public Ball(Pong pong): base(new Vector2(pong.Dimensions.X / 2, pong.Dimensions.Y / 2), Ball.Radius, Ball.Radius)
        {
            this.Pong = pong;
        }

        public void Update()
        {
            this.position = new Vector2(this.position.X + this.Speed.X, this.position.Y + this.Speed.Y);
            if (!this.IsOut())
            {
                
                this.CheckWallColision();
                foreach (Player player in this.Pong.LeftTeam.Players)
                {
                    this.CheckPlayerColision(player);
                }
                foreach (Player player in this.Pong.RightTeam.Players)
                {
                    this.CheckPlayerColision(player);
                }

            }
            else
            {
                this.ResetBall();
            }
        }

        public Boolean IsOut()
        {
            
            if(this.position.X <= 0)
            {
                this.Pong.LeftTeam.Score++;
                return true;
            } 
            if (this.position.X >= this.Pong.Dimensions.X)
            {
                this.Pong.RightTeam.Score++;
                return true;
            }
            return false;
        }
        public Boolean CheckPlayerColision(Player player)
        {
            if (this.HitBox.Intersects(player.HitBox))
            {
                this.Speed = new Vector2(-this.Speed.X, this.Speed.Y);
                return true;
            }
            return false;
        }
        public Boolean CheckWallColision()
        {
            if (this.position.Y <= 0 || this.position.Y >= this.Pong.Dimensions.Y-Ball.Radius)
            {
                this.Speed = new Vector2(this.Speed.X, -this.Speed.Y);
                return true;
            }
            return false;
        }
        public void ResetBall()
        {
            this.position = new Vector2(this.Pong.Dimensions.X / 2, this.Pong.Dimensions.Y / 2);
            Random random = new Random();
            int X = (int)(10*(Math.Cos(2*Math.PI*random.NextDouble())));
            int Y = (int)(10*(Math.Sin(2*Math.PI*random.NextDouble())));
            this.Speed = new Vector2(X, Y);
        }
    }
}
