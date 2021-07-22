using System;
using System.Collections.Generic;
using System.Drawing;

namespace Game
{
    public class Units
    {
        public int PosX;
        public Image UnitImage;
        public string Name;

        public Units(int posX, Image image, String name)
        {
            PosX = posX;
            UnitImage = image;
            Name = name;
        }
    }
}
