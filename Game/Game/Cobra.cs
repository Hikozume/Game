using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Game
{
    class Cobra
    {
        public int PosX { get; set; }
        private int frame = 0;
        private bool flip;
        public int point;
        public string Status { get; set; }
        public bool OnMove { get; set; }
        public int PosY { get; set; }
        public int Health { get; set; }
        public int Att { get; set; }
        public int Armor { get; set; }
        public string Direction { get; set; }
        public int Size { get; set; }

        public bool isDead = false;

        private Image Idle;
        private Image Model;
        private Image Sprite;
        public Dictionary<string, List<Image>> Animations { get; set; }

        public Cobra(int posX, int posY)
        {
            Health = 100;
            Armor = 10;
            point = 10;
            Att = 15;
            Sprite = Sprites.Sprites.new_Cobra;
            Size = 100;
            PosX = posX;
            PosY = posY;
            Animations = new Dictionary<string, List<Image>>();
            Animations.Add("Idle", SetAnimation(8, 0));
            Animations.Add("Run", SetAnimation(8, 1));
            Animations.Add("Attack", SetAnimation(6, 2));
            Animations.Add("Death", SetAnimation(6, 4));
            Idle = Animations["Idle"][0];
            Model = Idle;
        }
        private List<Image> SetAnimation(int animFrames, int row, bool flip = false)
        {
            var frames = new List<Image>();
            Image part;
            Graphics g;
            for (int i = 0; i < animFrames; i++)
            {
                part = new Bitmap(96, 96);
                g = Graphics.FromImage(part);
                g.DrawImage(Sprite, new Rectangle(new System.Drawing.Point(0, 0), new Size(Size, Size)), 98 * i, 96 * row, 96, 96, GraphicsUnit.Pixel);
                frames.Add(new Bitmap(part));
            }
            return frames;
        }

        public void Move(Player player)
        {
            //Player player = new Player();
            if (Health <= 0)
            {
                isDead = true;
                Status = "Death";
            }
            if (Math.Abs(player.PosX - PosX) > 20)
            {
                if ((player.PosX - PosX) < 0) Direction = "Left";
                else Direction = "Right";
                OnMove = true;
                Status = "Run";
            }
            else
            {
                OnMove = false;
                Direction = "Idle";
                Status = "Attack";
                player.Health -= 1;
            }
            //if (Math.Abs(player.PosX - PosX) <= 20)
            //{
            //    if (Direction == "Idle" && OnMove)
            //        OnMove = true;
            //    Direction = "Idle";
            //    Status = "Attack";
            //    player.Health -= 5;
            //}
        }


        public void PlayAnimation(Graphics g, Player player) => g.DrawImage(ModelStatus(player), PosX, PosY);
        private Image ModelStatus(Player player)
        {
            Move(player);
            Bitmap newFrame = new Bitmap(Model);
            if (Status=="Death")
            {
                newFrame = new Bitmap(Animations[Status][frame]);
                frame++;
                if (frame >= Animations[Status].Count)
                {
                    isDead = true;
                    newFrame = null;
                }
                return newFrame;
            }
            if (OnMove == true)
            {
                if (Direction == "Left")
                {
                    PosX -= 5;
                    flip = true;
                }
                if (Direction == "Right")
                {
                    PosX += 5;
                    flip = false;
                }
                newFrame = new Bitmap(Animations[Status][frame]);
                frame++;
                if (frame >= Animations[Status].Count) frame = 0;
            }
            if (OnMove == false)
            {
                if (frame >= Animations[Status].Count) frame = 0;
                newFrame = new Bitmap(Animations[Status][frame]);
                frame++;
            }
            if (flip) newFrame.RotateFlip(RotateFlipType.RotateNoneFlipX);
            return Model = newFrame;
        }
    }
}
