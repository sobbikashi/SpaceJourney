using System.Windows.Forms;
using System.Drawing;
using SpaceJourney.Objects;
using System;
using System.Collections.Generic;

namespace SpaceJourney
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        //Задаем фон игрового поля
        static Image background = Image.FromFile("Images\\background.png");
        static Timer timer = new Timer();
        static Game()
        {
        }
        #region Отработка нажатия кнопок
        public static void Form_KeyDown(object sender, KeyEventArgs e)
        {

            if ((e.KeyCode == Keys.A) || (e.KeyCode == Keys.Left)) mainShip.Left();
            if ((e.KeyCode == Keys.D) || (e.KeyCode == Keys.Right)) mainShip.Right();
            if ((e.KeyCode == Keys.W) || (e.KeyCode == Keys.Up)) mainShip.Up();
            if ((e.KeyCode == Keys.S) || (e.KeyCode == Keys.Down)) mainShip.Down();
            #region проба смены моделек
            if (e.KeyCode == Keys.H)
            {
                MainShip.mainShipImage = Image.FromFile("Images\\planetExpress_damaged.png");
            }
            if (e.KeyCode == Keys.G)
            {
                MainShip.mainShipImage = Image.FromFile("Images\\planetExpress_damaged_more.png");
            }
            if (e.KeyCode == Keys.F)
            {
                MainShip.mainShipImage = Image.FromFile("Images\\planetExpress.png");
            }
            #endregion
            if (e.KeyCode == Keys.Escape)
            {
                timer.Stop();
            }
            if (e.KeyCode == Keys.Enter)
            {
                timer.Start();
            }
            if (e.KeyCode == Keys.F4)
            {
                Application.Exit();
            }
            if (e.KeyCode == Keys.Space)
            {
                mainShip.Shot();
            }
        }
        #endregion


        #region Переменные
        //инициализация корабля
        private static MainShip mainShip = new MainShip(new Point(100, 314), new Point(10, 10), new Size(150, 75));
        //инициализация вражеского корабля/кораблей
        private static EnemyShip enemyShip = new EnemyShip(new Point(1000, 314), new Point(2, 2), new Size(100, 40));
        //инициализация пиу-пиу лазеров
        static public List<GreenLasers> lasers = new List<GreenLasers>();
        //задали базовое количество ХП = 3
        static int health = 3;
        //private static MyHUD_0 hp_0_border = new MyHUD_0(new Point(0, 700), new Size(250, 200));
        //private static MyHUD_1 hp_1_bender = new MyHUD_1(new Point(0, 710), new Size(250, 150));
        //private static MyHUD_2 hp_2_lila = new MyHUD_2(new Point(0, 710), new Size(250, 150));
        //private static MyHUD_3 hp_3_fry = new MyHUD_3(new Point(0, 710), new Size(250, 150));
        #endregion
        #region Инициализация
        public static void Init(Form form)
        {
            // Графическое устройство для вывода графики            
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            timer.Interval = 5;
            timer.Tick += Timer_Tick;
            timer.Start();
            form.KeyDown += Form_KeyDown;
        }
        #endregion

        #region
        //static public void Load() { 
        //}
        #endregion

        public static void Draw()
        {
            // Проверяем вывод графики
            Buffer.Graphics.DrawImage(background, 0, 0);
            foreach (GreenLasers greenLaser in lasers)
                greenLaser.Draw();
            mainShip.Draw();
            enemyShip.Draw();
            //hp_0_border.Draw();
            //hp_1_bender.Draw();
            //hp_2_lila.Draw();
            //hp_3_fry.Draw();
            Buffer.Render();
        }
        public static void Update()
        {
            mainShip.Update();
            enemyShip.Update();
            foreach (GreenLasers greenLaser in lasers)
                greenLaser.Update();
            //hp_0_border.Update();
            //hp_1_bender.Update();
            //hp_2_lila.Update();
            //hp_3_fry.Update();
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }



    }
}
