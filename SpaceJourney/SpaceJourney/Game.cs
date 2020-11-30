using System.Windows.Forms;
using System.Drawing;
using SpaceJourney.Objects;
using System;
using System.Collections.Generic;
using SpaceJourney.Objects.HUD;

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
        static bool isKeyPressed = false;
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
                MyHUD.imageHP = Image.FromFile("Images\\hpbar2point.png");

            }
            if (e.KeyCode == Keys.G)
            {
                MainShip.mainShipImage = Image.FromFile("Images\\planetExpress_damaged_more.png");
                MyHUD.imageHP = Image.FromFile("Images\\hpbar1point.png");
            }
            if (e.KeyCode == Keys.F)
            {
                MainShip.mainShipImage = Image.FromFile("Images\\planetExpress.png");
                MyHUD.imageHP = Image.FromFile("Images\\hpbar3point.png");
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
                if (!isKeyPressed)
                {
                    mainShip.Shot();
                    isKeyPressed = true;
                }

            }
        }
        private static void Form_KeyUp(object sender, KeyEventArgs e)
        {
            isKeyPressed = false;

        }
        #endregion
        //static bool left, right, up, down, pew;
        //public static void Form_KeyDown(object sender, KeyEventArgs e)
        //{
        //    switch (e.KeyCode)
        //    {
        //        case Keys.W: { up = true; break; }
        //        case Keys.S: { down = true; break; }
        //        case Keys.A: { left = true; break; }
        //        case Keys.D: { right = true; break; }
        //        case Keys.Space: { pew = true; break; }
        //        case Keys.F4: { Application.Exit(); break; }
        //        case Keys.Escape: { timer.Stop(); break; }
        //        case Keys.Enter: { timer.Start(); break; }
        //    }
        //    if (up) mainShip.Up();
        //    if (down) mainShip.Down();
        //    if (left) mainShip.Left();
        //    if (right) mainShip.Right();
        //    if ((pew) & (isKeyPressed))
        //    {
        //        mainShip.Shot();
        //        //isKeyPressed = true;
        //    }               
        //}
        //private static void Form_KeyUp(object sender, KeyEventArgs e)
        //{
        //    switch (e.KeyCode)
        //    {
        //        case Keys.W: { up = false; break; }
        //        case Keys.S: { down = false; break; }
        //        case Keys.A: { left = false; break; }
        //        case Keys.D: { right = false; break; }
        //        case Keys.Space: { pew = false; isKeyPressed = false; break; }
        //    }           

        //}



        #region Переменные
        //инициализация корабля
        private static MainShip mainShip = new MainShip(new Point(100, 314), new Point(10, 10), new Size(150, 75));
        //инициализация вражеского корабля/кораблей
        private static EnemyShip enemyShip = new EnemyShip(new Point(1000, 314), new Point(2, 2), new Size(100, 40));
        //инициализация пиу-пиу лазеров
        static public List<GreenLasers> lasers = new List<GreenLasers>();
        //задали базовое количество ХП = 3
        static int health = 3;
        
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
            timer.Interval = 1;
            timer.Tick += Timer_Tick;
            timer.Start();
            form.KeyDown += Form_KeyDown;
            form.KeyUp += Form_KeyUp;
        }
        #endregion

        #region HUD
        //Инициализация HUD
        private static MyHUD myHUD = new MyHUD(new Point(0, 710), new Size(290, 140));
        #endregion

        #region Загрузка объектов
        static public void Load()
        {
            
        }
        #endregion

        public static void Draw()
        {
            // Проверяем вывод графики
            Buffer.Graphics.DrawImage(background, 0, 0);
            foreach (GreenLasers greenLaser in lasers)
                greenLaser.Draw();
            mainShip.Draw();
            enemyShip.Draw();
            myHUD.Draw();
            
            Buffer.Render();
        }
        public static void Update()
        {
            mainShip.Update();
            enemyShip.Update();
            foreach (GreenLasers greenLaser in lasers)
                greenLaser.Update();
            myHUD.Update();
           
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }



    }
}
