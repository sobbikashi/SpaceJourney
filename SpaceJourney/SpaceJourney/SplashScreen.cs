using System;
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
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form MainWindow = new Form();
            MainWindow.Width = 1600;
            MainWindow.Height = 900;
            Game.Init(MainWindow);
            MainWindow.Show();
            Game.Draw();
            Visible = false;
        }
    }
}
