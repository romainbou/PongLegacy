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
        public Player(Team team, Conf.PlayerPosition playerPosition, Conf.InteligenceType type) : base(Vector2.Zero,Conf.BAT_WIDTH,Conf.BAT_HEIGHT)
        {
            this.Team = team;
            HitBox = new Rectangle();
            HitBox.Width = this.width;
            HitBox.Height = this.height;
            this.PlayerPosition = playerPosition;
            this.Type = type;
            this.setInital();
            

        }

        
        public void Update()
        {
            this.Controler.Update();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, this.HitBox, Color.White);
        }
        public void MoveUp()
        {
            if (this.position.Y + Conf.PLAYER_SPEED > 0)
            {
                this.position = new Vector2(this.position.X, this.position.Y - Conf.PLAYER_SPEED);
            }
            else
            {
                this.position = new Vector2(this.position.X, 0);
            }
        }
        public void MoveDown()
        {
            if (this.position.Y + Conf.PLAYER_SPEED < this.Team.Pong.Dimensions.Y - Conf.BAT_HEIGHT)
            {
                this.position = new Vector2(this.position.X, this.position.Y + Conf.PLAYER_SPEED);
            }
            else
            {
                this.position = new Vector2(this.position.X, this.Team.Pong.Dimensions.Y);
            }
        }
        private void setInital()
        {
            
            if (this.Team.Side == Conf.TeamSide.LEFT)
            {
                if (this.PlayerPosition == Conf.PlayerPosition.BACK)
                {
                    this.position = new Vector2(Conf.BACK_PLAYER_MARGIN, Conf.WINDOW_HEIGHT / 2);
                    this.Controler = new KeyboardPlayerControler(Keys.A, Keys.Q);
                }
                else
                {
                    this.position = new Vector2(Conf.FRONT_PLAYER_MARGIN, Conf.WINDOW_HEIGHT / 2);
                    this.Controler = new KeyboardPlayerControler(Keys.F, Keys.V);
                }
            }
            else
            {
                if (this.PlayerPosition == Conf.PlayerPosition.BACK)
                {
                    this.position = new Vector2(Conf.WINDOW_WIDTH - Conf.BACK_PLAYER_MARGIN, Conf.WINDOW_HEIGHT / 2);
                    this.Controler = new KeyboardPlayerControler(Keys.J, Keys.N);
                }
                else
                {
                    this.position = new Vector2(Conf.WINDOW_WIDTH - Conf.FRONT_PLAYER_MARGIN, Conf.WINDOW_HEIGHT / 2);
                    this.Controler = new KeyboardPlayerControler(Keys.Up, Keys.Down);
                }
            }
            if (this.Type == Conf.InteligenceType.IA)
            {
                this.Controler =  new ArtificialPlayerControler(this)
            }
        }
        
    }
}
