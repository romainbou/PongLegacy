using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PongLegacy
{
    //Classe abstraite de contrôle d'un joueur
    public abstract class IPlayerControler
    {
        public Player Player { get; set; }
        public abstract void MoveUp();
        public abstract void MoveDown();
        public abstract void Update();

        public IPlayerControler(Player player)
        {
            this.Player = player;
        }
    }
}
