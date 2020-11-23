using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceJourney
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form MainWindow = new Form();
            MainWindow.Width = 1280;
            MainWindow.Height = 768;
            Game.Init(MainWindow);
            MainWindow.Show();
            Game.Draw();
            this.Visible = false;
        }
    }
}
