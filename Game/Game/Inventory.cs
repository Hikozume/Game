using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game.Properties;

namespace Game
{
    public partial class Inventory : Form
    {
        List<Items> items = new List<Items>();
        int CurrentIndex = 0;

        public Inventory()
        {
            InitializeComponent();
            StartItems();
            timer1.Interval = 20;
            timer1.Tick += new EventHandler(Update);
            KeyDown += new KeyEventHandler(Press);
            KeyUp += new KeyEventHandler(Unpress);
            label1.Text = items.ElementAt(CurrentIndex).Name;
            label2.Text = items.ElementAt(CurrentIndex).Count.ToString();
        }

        public void Press(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.I)
                this.Hide();
        }

        public void Update(object sender, EventArgs e)
        {
            Invalidate();
        }

        public void Unpress(object sender, KeyEventArgs e)
        {  
            
        }

        private void StartItems()
        {
            items.Add(new Items("Medium Bandage", 2, x => x.ToString()));
            items.Add(new Items("Small Bandage", 4, x => x.ToString()));
        }


        private void Next_Click(object sender, EventArgs e)
        {
            if (CurrentIndex + 1 == items.Count)
                CurrentIndex = 0;
            else
                CurrentIndex++;
            label1.Text = items.ElementAt(CurrentIndex).Name;
            label2.Text = items.ElementAt(CurrentIndex).Count.ToString();
        }

        private void Previous_Click(object sender, EventArgs e)
        {
            if (CurrentIndex == 0)
                CurrentIndex = items.Count - 1;
            else
                CurrentIndex--;
            label1.Text = items.ElementAt(CurrentIndex).Name;
            label2.Text = items.ElementAt(CurrentIndex).Count.ToString();
        }

        private void Use_Click(object sender, EventArgs e)
        {
            items.ElementAt(CurrentIndex).Count -= 1;
            label2.Text = items.ElementAt(CurrentIndex).Count.ToString();
            items.ElementAt(CurrentIndex).Сhange(2);
        }
    }
}
