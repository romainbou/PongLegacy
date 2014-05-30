using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;


namespace PongLegacy
{
    public class KeyboardPlayerControler : IPlayerControler
    {
        public KeyboardState KeyboardState { get; set; }
        public Keys UpKey { get; set; }
        public Keys DownKey { get; set; }
        


        public KeyboardPlayerControler(Keys up, Keys down,Player player):base(player)
        {

            this.KeyboardState = new KeyboardState();
            this.UpKey = up;
            this.DownKey = down;
            
        }

        public override void Update()
        {
            this.Player.IsAccelerating = false;
            KeyboardState = Keyboard.GetState();
            if (KeyboardState.IsKeyDown(this.DownKey))
            {
                this.Player.IsAccelerating = true;
                this.MoveDown();
            }
            if (KeyboardState.IsKeyDown(this.UpKey))
            {
                this.Player.IsAccelerating = true;
                this.MoveUp();
            }
            
        }

        public override void MoveUp()
        {
            this.Player.MoveUp();
        }
        public override void MoveDown()
        {
            this.Player.MoveDown();
        }
       
    }
}
