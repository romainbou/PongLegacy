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
        static int Radius =20;
        public Vector2 Speed { get; set; }
        public Rectangle HitBox;
        public float Acceleration { get; set; }
        public Pong Pong { get; set; }
        

        public Ball(Pong pong): base(new Vector2(pong.Dimensions.X / 2, pong.Dimensions.Y / 2), Ball.Radius, Ball.Radius)
        {
            this.Acceleration = .2f;
            this.Pong = pong;
            this.setHitBox();
        }
        private void setHitBox()
        {
            this.HitBox = new Rectangle();
            this.HitBox.Width = Ball.Radius;
            this.HitBox.Height = Ball.Radius;
            this.HitBox.X = (int)this.position.X;
            this.HitBox.Y = (int)this.position.Y;
        }

        public void Update()
        {
            this.setHitBox();
            
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
                this.position = new Vector2(this.position.X + this.Speed.X, this.position.Y + this.Speed.Y);
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
            if (!this.HitBox.Intersects(player.HitBox))
            {
                player.isInIntersection = false;
            }
            if (this.HitBox.Intersects(player.HitBox)&&!player.isInIntersection)
            {
                
                int middle = (int)player.position.Y + Conf.BAT_HEIGHT / 2;
                float coef = (-middle + this.position.Y) / (Conf.BAT_HEIGHT / 2);
                if (this.Speed.X > 0)
                {
                    coef = -1 * coef;
                }
                Vector2 vector = new Vector2(-this.Speed.X, this.Speed.Y);
                float angle = (float)(Math.PI / 180) * 45;
                Vector2 final = new Vector2();
                final.X = (int)(this.Acceleration * (vector.X * Math.Cos(coef * angle) - vector.Y * Math.Sin(coef * angle)) +(vector.X * Math.Cos(coef * angle) - vector.Y * Math.Sin(coef * angle)));
                final.Y = (int)(this.Acceleration * (vector.Y * Math.Cos(coef * angle) + vector.X * Math.Sin(coef * angle)) + (vector.Y * Math.Cos(coef * angle) + vector.X * Math.Sin(coef * angle)));
                if (final.Length() > 20)
                {
                    final.X = (int)((vector.X * Math.Cos(coef * angle) - vector.Y * Math.Sin(coef * angle)));
                    final.Y = (int)((vector.Y * Math.Cos(coef * angle) + vector.X * Math.Sin(coef * angle)));
                }
                this.Speed = final;
                player.isInIntersection = true;
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
            int X = -5;//(int)(5*(Math.Cos(2*Math.PI*random.NextDouble())));
            int Y = 0;//(int)(2*(Math.Sin(2*Math.PI*random.NextDouble())));
            this.Speed = new Vector2(X, Y);
        }
    }
}
