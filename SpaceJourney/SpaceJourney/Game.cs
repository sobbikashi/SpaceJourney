using System.Windows.Forms;
using System.Drawing;
using SpaceJourney.Objects;
using System.IO;
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
            //if (e.KeyCode == Keys.Space)
            //{
            //    mainShip.Shot();
            //}
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
        }
        #endregion
        

        private static MainShip mainShip = new MainShip(new Point(100, 314), new Point(10, 10), new Size(100, 75));
        private static EnemyShip enemyShip = new EnemyShip(new Point(1000, 314), new Point(2, 2), new Size(50, 34));
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

        public static void Draw()
        {
            // Проверяем вывод графики
            Buffer.Graphics.Clear(Color.Black);
            mainShip.Draw();
            enemyShip.Draw();
            Buffer.Render();
        }
        public static void Update()
        {
            mainShip.Update();
            enemyShip.Update();
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }


    }
}
