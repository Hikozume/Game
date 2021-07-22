using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Items
    {
        public string Name { get; set; }
        public int Count { get; set; }

        public Action<double> Сhange;

        public Items(string name, int count, Action<double> change)
        {
            Name = name;
            Count = count;
            Сhange = change;
        }
    }
}
