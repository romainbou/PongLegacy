using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PongLegacy
{
    public class Player : SpriteTexture2D
    {
        public Team Team { get; set; }

        public Rectangle HitBox;
        public Vector2 Speed { get; set; }
        public IPlayerControler Controler { get; set; }
        public Conf.PlayerPosition PlayerPosition{ get; set; }
        public Conf.InteligenceType Type { get; set; }
        public int CurrentSpeed { get; set; }
        public Boolean isInIntersection { get; set; }
        public Boolean IsAccelerating { get; set; }
        public Player(Team team, Conf.PlayerPosition playerPosition, Conf.InteligenceType type) : base(Vector2.Zero,Conf.BAT_WIDTH,Conf.BAT_HEIGHT)
        {
            this.Team = team;
            this.CurrentSpeed = Conf.PLAYER_INIT_SPEED;
            HitBox = new Rectangle();
            HitBox.Width = this.width;
            HitBox.Height = this.height;
            HitBox.X = (int)this.position.X;
            HitBox.Y = (int)this.position.Y;
            this.PlayerPosition = playerPosition;
            this.Type = type;
            this.setInital();
            this.setHitBox();
            this.IsAccelerating = false;


        }

        
        public void Update()
        {
            this.Controler.Update();
            this.setHitBox();
        }
        private void setHitBox()
        {
            this.HitBox = new Rectangle();
            this.HitBox.Width = this.width;
            this.HitBox.Height = this.height;
            this.HitBox.X = (int)this.position.X;
            this.HitBox.Y = (int)this.position.Y;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, this.HitBox, Color.White);
        }
        public void MoveUp()
        {

            if (this.position.Y - this.CurrentSpeed > 0)
            {
                this.position = new Vector2(this.position.X, this.position.Y - this.CurrentSpeed);
            }
            else
            {
                this.position = new Vector2(this.position.X, 0);
            }
        }
        public void MoveDown()
        {
            if (this.position.Y + this.CurrentSpeed < this.Team.Pong.Dimensions.Y - Conf.BAT_HEIGHT)
            {
                this.position = new Vector2(this.position.X, this.position.Y + this.CurrentSpeed);
            }
            else
            {
                this.position = new Vector2(this.position.X, this.Team.Pong.Dimensions.Y - Conf.BAT_HEIGHT);
            }
        }
        private void setInital()
        {
            
            if (this.Team.Side.Equals(Conf.TeamSide.LEFT))
            {
                if (this.PlayerPosition == Conf.PlayerPosition.BACK)
                {
                    this.position = new Vector2(Conf.BACK_PLAYER_MARGIN, Conf.WINDOW_HEIGHT / 2);
                    this.Controler = new KeyboardPlayerControler(Keys.A, Keys.Q,this);
                }
                else
                {
                    this.position = new Vector2(Conf.FRONT_PLAYER_MARGIN, Conf.WINDOW_HEIGHT / 2);
                    this.Controler = new KeyboardPlayerControler(Keys.F, Keys.V, this);
                }
            }
            else
            {
                if (this.PlayerPosition == Conf.PlayerPosition.BACK)
                {
                    this.position = new Vector2(Conf.WINDOW_WIDTH - Conf.BACK_PLAYER_MARGIN, Conf.WINDOW_HEIGHT / 2);
                    this.Controler = new KeyboardPlayerControler(Keys.Up, Keys.Down, this);
                }
                else
                {
                    this.position = new Vector2(Conf.WINDOW_WIDTH - Conf.FRONT_PLAYER_MARGIN, Conf.WINDOW_HEIGHT / 2);
                    this.Controler = new KeyboardPlayerControler(Keys.J, Keys.N, this);
                }
            }
            if (this.Type == Conf.InteligenceType.IA)
            {
                this.Controler = new ArtificialPlayerControler(this);
            }
        }
        public void SetSpeed()
        {
            if (this.IsAccelerating && this.CurrentSpeed<Conf.PLAYER_MAX_SPEED)
            {
                this.CurrentSpeed += Conf.PLAYER_ACC;
            }
            else if (!this.IsAccelerating)
            {
                this.CurrentSpeed = Conf.PLAYER_INIT_SPEED;
            }
        }
        
    }
}
