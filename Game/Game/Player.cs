using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Player
    {

        public int Health { get; set; }
        public int Armor { get; set; }
        public Player()
        {
            Health = 100;
            Armor = 100;
        }

    }
}
