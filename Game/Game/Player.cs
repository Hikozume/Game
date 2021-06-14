using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    class Player
    {
        public int PosX{ get; set; }
        private int frame=0;
        public bool OnMove { get; set; }
        public int PosY { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
        public int Size { get; set; }
        private Image Idle;
        private Image ModelStat;
        public Image Model { get; set; }
        public Dictionary<string,List<Image>> Animations { get; set; }

        public Player()
        {
            Health = 100;
            Armor = 100;
            Model = Sprites.Sprites.IDK;
            Size = 100;
            PosX = 0;
            PosY = 0;
            Animations = new Dictionary<string, List<Image>>();
            Animations.Add("Idle", SetAnimation(13, 0));
            Animations.Add("Run", SetAnimation(8, 1));
            Animations.Add("Attack", SetAnimation(10, 4));
            Animations.Add("Jump", SetAnimation(6, 5));
            Animations.Add("Death", SetAnimation(7, 7));
            Idle = Animations["Idle"][0];
            ModelStat = Idle;
        }

        private List<Image> SetAnimation(int animFrames, int row)
        {
            var frames = new List<Image>();
            Image part;
            Graphics g;
            for (int i = 0; i < animFrames; i++)
            {
                part = new Bitmap(96, 96);
                g = Graphics.FromImage(part);
                g.DrawImage(Model, new Rectangle(new Point(0,0), new Size(96, 96)), 98*i, 96*row, 96, 96, GraphicsUnit.Pixel);
                frames.Add(new Bitmap(part));              
            }
            return frames;
        }
        public void Move(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    PosX += 10;
                    OnMove = true;
                    ModelStatus("Run");
                    break;
                case Keys.Left:
                    PosX -= 10;
                    OnMove = true;
                    ModelStatus("Run");
                    break;
                case Keys.Up:
                    OnMove = true;
                    ModelStatus("Attack");
                    break;
            }
        }

        public void PlayAnimation(Graphics g)
        {
            if(OnMove==true) g.DrawImage(ModelStat, PosX, PosY);
            else g.DrawImage(Idle, PosX, PosY);

            // Model = Animations["Idle"][0];
        }

        private Image ModelStatus(string animName)
        {
            if (OnMove == true)
            {
                ModelStat = Animations[animName][frame];
                frame++;
                if (frame >= Animations[animName].Count) frame = 0;
                return ModelStat;
            }
            if (OnMove == false)
            {
                frame = 0;
                ModelStat = Idle;
                return ModelStat;
            }
            return ModelStat;           
        }

    }
}
