using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Properties;
using System.Windows.Forms;
using System.Threading;

namespace Game
{
    //comm
    //comm2 04/06/21
    public partial class Form1 : Form
    {
        Player player;
        Cobra cobra;
        Inventory inventory;

        new readonly List<Keys> Controls = new List<Keys>()
        {
            Keys.Down,
            Keys.Space,
            Keys.Right,
            Keys.Left
        };

        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            timer1.Interval = 20;
            timer1.Tick += new EventHandler(Update);
            KeyDown += new KeyEventHandler(Press);
            KeyUp += new KeyEventHandler(Unpress);
            this.BackgroundImage = Resources.StartLock;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            Initialization();
        }

        public void Initialization()
        {            
            MenuForm menu = new MenuForm();
            menu.ShowDialog();
            player = new Player();
            cobra = new Cobra();
            cobra.PosX = 500;
            cobra.PosY = Screen.PrimaryScreen.Bounds.Size.Height - 70;
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
            Graphics g = e.Graphics;
            player.PlayAnimation(g);
            cobra.PlayAnimation(g);
            timer1.Start();
            // graph.DrawImage(player.Model, new Rectangle(new Point(50,50),new Size(100,100)),0,0,96,96,GraphicsUnit.Pixel);
        }

        // Может быть реализовать таймер сюда чтобы показовало снесенное ХП
        //Label HP = new Label()
        //{
        //    Size = new Size(25, 25)
        //};
        //public bool MessageHP()
        //{
        //    if (Math.Abs(player.PosX - cobra.PosX) <= 20)
        //    {
        //        HP.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
        //        HP.Location = new System.Drawing.Point(cobra.PosX+10, cobra.PosY+10);
        //        HP.Text = "-10";
        //        base.Controls.Add(HP);
        //        HP.Visible = true;
        //        return true;
        //    }
        //    else
        //    {
        //        HP.Visible = false;
        //        return false;
        //    }
        //}

        public void Press(object sender, KeyEventArgs e)
        {
            Health.Text = "Health " + player.Health.ToString();
            MesageToExit();
            if(Controls.Contains(e.KeyCode))
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
                    //load.Show();
                    //Thread.Sleep(1000);
                    //load.Hide();
                    Level2 level = new Level2();
                    level.Show();
                    this.Hide();
                }
            }
            if (e.KeyCode == Keys.Space)
            {
                player.OnMove = true;
                player.Direction = "Idle";
                player.Status = "Attack";
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
