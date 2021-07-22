using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Game.Properties;

namespace Game
{
    public partial class Level2 : Form
    {
        Player player;
        Inventory inventory = new Inventory();
        Loading load = new Loading();
        Levels levels = new Levels();

        new readonly List<Keys> Controls = new List<Keys>()
        {
            //Keys.Up,
            Keys.Down,
            Keys.Space,
            Keys.Right,
            Keys.Left
        };

        public Level2()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            timer1.Interval = 20;
            timer1.Tick += new EventHandler(Update);
            KeyDown += new KeyEventHandler(Press);
            KeyUp += new KeyEventHandler(Unpress);
            this.BackgroundImage = Resources.SecondLocation;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            Initialization();
        }

        public void Initialization()
        {
            //MenuForm menu = new MenuForm();
            //menu.ShowDialog();
            player = new Player();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            player.PlayAnimation(g);
            timer1.Start();
        }

        public void Press(object sender, KeyEventArgs e)
        {
            MesageToExit();
            if (Controls.Contains(e.KeyCode))
                player.Move(e);
            if (e.KeyCode == Keys.I)
                inventory.Show();
            if (e.KeyCode == Keys.Escape)
                Close();
            if (e.KeyCode == Keys.F && MesageToExit())
            {
                FormCollection fc = Application.OpenForms;
                bool open = false;

                foreach (Form frm in fc)
                    if (frm.Name == "Loading" && frm.Visible == true)
                        open = true;

                if (!open)
                {
                    load.Show();
                    Thread.Sleep(1000);
                    load.Hide();
                }
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

        Label LM = new Label()
        {
            Size = new Size(25, 25)
            //BackColor = Color.Transparent
        };

        public bool MesageToExit()
        {
            if (player.PosX >= Size.Width - 350)
            {
                LM.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
                LM.Location = new Point(this.Size.Width - 100, this.Size.Height - 100);
                LM.Text = "F";
                base.Controls.Add(LM);
                LM.Visible = true;
                return true;
            }
            else return false;
        }
    }
}
