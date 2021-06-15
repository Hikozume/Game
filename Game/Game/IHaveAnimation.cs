using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public interface IHaveAnimation
    {
        Dictionary<string, List<Image>> Animations { get; set; }
        Image Sprite { get; set; }

        void PlayAnimation(Graphics g);
        List<Image> SetAnimation(int animFrames, int row, bool flip = false);

    }
}
