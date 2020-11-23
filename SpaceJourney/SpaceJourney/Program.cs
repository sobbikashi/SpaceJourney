using System;
using System.Windows.Forms;

namespace SpaceJourney
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {           
            using (Form SplashScreen = new SplashScreen())
            {                
                Application.Run(SplashScreen);
            }
        }
    }
}
