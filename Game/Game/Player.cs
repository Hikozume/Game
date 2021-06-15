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
        private bool flip;
        private int jumpHeight;
        private bool inAir;
        public string Status { get; set; }
        public bool OnMove { get; set; }
        public int PosY { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
        public string Direction { get; set; }
        public int Size { get; set; }

        private Image Idle;
        private Image Model;
        private Image Sprite;
        public Dictionary<string,List<Image>> Animations { get; set; }

        public Player()
        {
            Health = 100;
            Armor = 100;
            Sprite = Sprites.Sprites.IDK;
            Size = 100;
            PosX = 0;
            PosY = 200;
            Animations = new Dictionary<string, List<Image>>();
            Animations.Add("Idle", SetAnimation(13, 0));
            Animations.Add("Run", SetAnimation(8, 1));
            Animations.Add("Attack", SetAnimation(10, 4));
            Animations.Add("Jump", SetAnimation(6, 5));
            Animations.Add("Death", SetAnimation(7, 7));
            Idle = Animations["Idle"][0];
            Model = Idle;        
        }

        private List<Image> SetAnimation(int animFrames, int row,bool flip=false)
        {
            var frames = new List<Image>();
            Image part;
            Graphics g;
            for (int i = 0; i < animFrames; i++)
            {
                part = new Bitmap(96, 96);
                g = Graphics.FromImage(part);
                g.DrawImage(Sprite, new Rectangle(new Point(0,0), new Size(Size, Size)), 98*i, 96*row, 96, 96, GraphicsUnit.Pixel);           
                frames.Add(new Bitmap(part));

            }
            return frames;
        }
        public void Move(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    Direction = "Right";
                    OnMove = true;
                    Status = "Run";
                    break;
                case Keys.Left:
                    Direction = "Left";
                    OnMove = true;
                    Status = "Run";
                    break;
                case Keys.Space:
                    OnMove = true;
                    Direction = "Idle";
                    Status = "Attack";
                    break;
                case Keys.Up:
                    Direction = "Up";
                    OnMove = true;
                    if (inAir) break;
                    inAir = true;
                    jumpHeight = PosY;
                    PosY -= 150;
                    Status = "Jump";
                    break;
            }
        }

        public void PlayAnimation(Graphics g)=> g.DrawImage(ModelStatus(), PosX, PosY);


        private Image ModelStatus()
        {
            Bitmap newFrame = new Bitmap(Model);

            if (inAir)
            {
                if (PosY == jumpHeight) inAir = false;
                else
                {
                    newFrame = new Bitmap(Animations["Jump"][2]);
                    PosY += 2;
                    if (flip) newFrame.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    return Model = newFrame;
                }

            }
            if (OnMove == true)
            {
                if (Direction == "Left")
                {
                    PosX -= 10;
                    flip = true;
                }
                if (Direction == "Right")
                {
                    PosX += 10;
                    flip = false;
                }
                newFrame = new Bitmap(Animations[Status][frame]);                
                frame++;
                if (frame >= Animations[Status].Count) frame = 0;
            }
            if (OnMove == false)
            {
                frame = 0;
                Status = "Idle";
                newFrame = new Bitmap(Idle);
            }
            if (flip) newFrame.RotateFlip(RotateFlipType.RotateNoneFlipX);
            return Model=newFrame;
        }

    }
}
