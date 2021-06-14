using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public interface IAnimated
    {
        int Size { get; set; }
        Bitmap Model { get; set; }

        Dictionary<string, List<Image>> Animations { get; set; }
    }
}
