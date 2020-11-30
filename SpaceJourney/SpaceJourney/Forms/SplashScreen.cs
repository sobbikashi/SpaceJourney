using System;
using System.Windows.Forms;
using System.Media;

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
            Form mainWindow = new Form();
            mainWindow.Width = 1600;
            mainWindow.Height = 900;
            Game.Init(mainWindow);
            mainWindow.Show();
            Game.Draw();
            Visible = false;
            //SoundPlayer introSound = new SoundPlayer("Sounds\\intro.wav");
            //introSound.Play();
        }
    }
}
