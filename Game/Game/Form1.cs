using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    //comm
    //comm2 04/06/21
    public partial class Form1 : Form
    {
        Player player;
        List<Keys> Controls = new List<Keys>()
        {
            Keys.Up,
            Keys.Down,
            Keys.Space,
            Keys.Right,
            Keys.Left
        };
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 20;
            timer1.Tick += new EventHandler(Update);
            KeyDown += new KeyEventHandler(Press);
            KeyUp += new KeyEventHandler(Unpress);
            Initialization();

        }

        public void Initialization()
        {
            player = new Player();
        }


        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //var model = player.Model;
            //Image part = new Bitmap(96, 96);
            //Graphics g = Graphics.FromImage(part);
            //var list = new List<Image>();
            //g.DrawImage(player.Model, new Rectangle(new Point(0,0), new Size(100, 100)), 0, 0, 96, 96, GraphicsUnit.Pixel);
            //list.Add(part);

            player.PlayAnimation(g);
            timer1.Start();
            // graph.DrawImage(player.Model, new Rectangle(new Point(50,50),new Size(100,100)),0,0,96,96,GraphicsUnit.Pixel);


        }
        public void Press(object sender, KeyEventArgs e)
        {
            if (Controls.Contains(e.KeyCode))
            {
                player.Move(e);
            }
        }

        public void Unpress(object sender, KeyEventArgs e)
        {
            player.OnMove = false;
        }
        public void Update(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
