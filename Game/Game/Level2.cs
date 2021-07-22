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
        Inventory inventory;
        Ghoul ghoul;
        Cobra cobra;

        new readonly List<Keys> Control = new List<Keys>()
        {
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
            player = new Player();
            ghoul = new Ghoul(500, Screen.PrimaryScreen.Bounds.Size.Height - 70);
            cobra = new Cobra(750, Screen.PrimaryScreen.Bounds.Size.Height - 70);
            inventory = new Inventory(player);
            base.Controls.Add(Health);
            base.Controls.Add(Score);
            Health.Text = "Health " + player.Health.ToString();
            Health.Visible = true;
            Score.Text = "Score " + Points.point.ToString();
            Score.Visible = true;
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Health.Text = "Health " + player.Health.ToString();
            Graphics g = e.Graphics;
            player.PlayAnimation(g);
            if(!ghoul.isDead)ghoul.PlayAnimation(g, player);
            if (!cobra.isDead)cobra.PlayAnimation(g, player);
            timer1.Start();
        }

        public void Press(object sender, KeyEventArgs e)
        {
            MesageToExit();
            if (Control.Contains(e.KeyCode))
                player.Move(e);
            if (e.KeyCode == Keys.I)
                inventory.Show();
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
            if (e.KeyCode == Keys.F && MesageToExit())
            {
                FormCollection fc = Application.OpenForms;
                bool open = false;

                foreach (Form frm in fc)
                    if (frm.Name == "Loading" && frm.Visible == true)
                        open = true;

                if (!open)
                {
                    FinalLevel level = new FinalLevel();
                    level.Show();
                    this.Hide();
                }
            }
            if (e.KeyCode == Keys.Space)
            {
                player.OnMove = true;
                player.Direction = "Idle";
                player.Status = "Attack";
                if (Math.Abs(player.PosX - ghoul.PosX) <= 20 && ghoul.Health >= 0)
                {
                    ghoul.Health -= 10;
                }
                if (ghoul.Health == 0)
                {
                    Points.point += ghoul.point;
                    Score.Text = "Score " + Points.point.ToString();
                }
                if (Math.Abs(player.PosX - cobra.PosX) <= 20 && cobra.Health >= 0)
                {
                    cobra.Health -= 10;
                }
                if (cobra.Health == 0)
                {
                    Points.point += cobra.point;
                    Score.Text = "Score " + Points.point.ToString();
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
        };

        public bool MesageToExit()
        {
            if (player.PosX >= Size.Width - 250)
            {
                LM.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
                LM.Location = new Point(this.Size.Width - 100, this.Size.Height - 100);
                LM.Text = "F";
                base.Controls.Add(LM);
                LM.Visible = true;
                return true;
            }
            else
            {
                LM.Visible = false;
                return false;
            }
        }

        Label Health = new Label()
        {
            Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 204),
            Size = new Size(130, 30),
            Location = new Point(900, 25)
        };

        Label Score = new Label()
        {
            Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, 204),
            Size = new Size(130, 30),
            Location = new Point(900, 50)
        };
    }
}
