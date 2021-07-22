using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface IEnemy
    {
        int PosX { get; set; }
        int PosY { get; set; }
        int Health { get; set; }
    }
}
