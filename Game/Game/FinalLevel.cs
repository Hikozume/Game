using Game.Properties;
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
    public partial class FinalLevel : Form
    {
        Player player;

        new readonly List<Keys> Controls = new List<Keys>()
        {
            Keys.Down,
            Keys.Space,
            Keys.Right,
            Keys.Left
        };

        public FinalLevel()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            timer1.Interval = 20;
            timer1.Tick += new EventHandler(Update);
            KeyDown += new KeyEventHandler(Press);
            KeyUp += new KeyEventHandler(Unpress);
            this.BackgroundImage = Resources.FinalLock;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            //Health.Text = player.Health.ToString();
            base.Controls.Add(FinalMessage);
            FinalMessage.Visible = true;
            Initialization();
        }

        public void Initialization()
        {
            player = new Player();
        }

        public void Press(object sender, KeyEventArgs e)
        {
            if (Controls.Contains(e.KeyCode))
                player.Move(e);
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
            if (e.KeyCode == Keys.Space)
            {
                player.OnMove = true;
                player.Direction = "Idle";
                player.Status = "Attack";
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

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            player.PlayAnimation(g);
            timer1.Start();
        }

        Label FinalMessage = new Label()
        {
            Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point, 204),
            Size = new Size(450, 500),
            Location = new Point(550, 350),
            BackColor = Color.Transparent,
            Text = "Congratulations, you have passed the demo version of our game and your score is:" + Points.point.ToString()
        };

        private void FinalLevel_Load(object sender, EventArgs e)
        {

        }
    }
}
