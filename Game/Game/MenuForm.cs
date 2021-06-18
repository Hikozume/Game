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

namespace Game
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            this.BackgroundImage = Resources.MainMenuWith2Buttons;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void DontKnowForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
