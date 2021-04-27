﻿using System.Windows.Forms;
using System.Drawing;
using SpaceJourney.Objects;
using System;
using System.Collections.Generic;
using SpaceJourney.Objects.HUD;
using System.Media;

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

        static Timer timer = new Timer();
        static Game()
        {
        }
        #region Отработка нажатия кнопок

        //public static void Form_KeyDown(object sender, KeyEventArgs e)
        //{

        //    if ((e.KeyCode == Keys.A) || (e.KeyCode == Keys.Left)) mainShip.Left();
        //    if ((e.KeyCode == Keys.D) || (e.KeyCode == Keys.Right)) mainShip.Right();
        //    if ((e.KeyCode == Keys.W) || (e.KeyCode == Keys.Up)) mainShip.Up();
        //    if ((e.KeyCode == Keys.S) || (e.KeyCode == Keys.Down)) mainShip.Down();
        //    #region проба смены моделек
        //    //if (e.KeyCode == Keys.H)
        //    //{
        //    //    MainShip.mainShipImage = Image.FromFile("Images\\planetExpress_damaged.png");
        //    //    MyHUD.imageHP = Image.FromFile("Images\\hpbar2point.png");

        //    //}
        //    //if (e.KeyCode == Keys.G)
        //    //{
        //    //    MainShip.mainShipImage = Image.FromFile("Images\\planetExpress_damaged_more.png");
        //    //    MyHUD.imageHP = Image.FromFile("Images\\hpbar1point.png");
        //    //}
        //    //if (e.KeyCode == Keys.F)
        //    //{
        //    //    MainShip.mainShipImage = Image.FromFile("Images\\planetExpress.png");
        //    //    MyHUD.imageHP = Image.FromFile("Images\\hpbar3point.png");
        //    //}
        //    #endregion
        //    if (e.KeyCode == Keys.Escape)
        //    {
        //        timer.Stop();
        //    }
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        timer.Start();
        //    }
        //    if (e.KeyCode == Keys.F4)
        //    {
        //        Application.Exit();
        //    }
        //    if (e.KeyCode == Keys.Space)
        //    {
        //        if (!isKeyPressed)
        //        {
        //            mainShip.Shot();
        //            isKeyPressed = true;
        //        }

        //    }
        //}
        //private static void Form_KeyUp(object sender, KeyEventArgs e)
        //{
        //    isKeyPressed = false;

        //}
        #endregion

        public static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W: { up = true; break; }
                case Keys.S: { down = true; break; }
                case Keys.A: { left = true; break; }
                case Keys.D: { right = true; break; }
                case Keys.Space: { pew = true; break; }
                case Keys.F4: { Application.Exit(); break; }
                case Keys.Escape: { timer.Stop(); break; }
                case Keys.Enter: { timer.Start(); break; }
                case Keys.L: { AddEnemy(); break; }
                case Keys.K:
                    {
                        foreach (EnemyShip enemyShip in enemyShips)
                        {
                            enemyShip.NeedToRemove = true;
                        }
                        break;
                    }
                case Keys.H: { health--; break; }

            }
            if (up) mainShip.Up();
            if (down) mainShip.Down();
            if (left) mainShip.Left();
            if (right) mainShip.Right();
            if ((pew) & (isSpacePressed))
            {
                mainShip.Shot();
                isSpacePressed = false;

            }
        }
        private static void Form_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W: { up = false; break; }
                case Keys.S: { down = false; break; }
                case Keys.A: { left = false; break; }
                case Keys.D: { right = false; break; }
                case Keys.Space: { pew = false; isSpacePressed = true; break; }
            }

        }



        #region Переменные
        public static Random random = new Random();
        //инициализация корабля
        private static MainShip mainShip = new MainShip(new Point(100, 314), new Point(10, 10), new Size(150, 75));

        //инициализация вражеского корабля/кораблей
        public static List<EnemyShip> enemyShips = new List<EnemyShip>();

        //инициализация пиу-пиу лазеров
        public static List<GreenLasers> lasers = new List<GreenLasers>();

        public static List<FallingBody> crewMembers = new List<FallingBody>();
        //задали базовое количество ХП = 3
        static int health = 3;
        static Image background = Image.FromFile("Images\\background.png");
        public static Image mainShipImage = Image.FromFile("Images\\planetExpress.png");
        static Image enemyShipImage = Image.FromFile("Images\\enemy1.png");
        static Image enemyShipBroken = Image.FromFile("Images\\project_Explosion.png");
        static Image greenLaserImage = Image.FromFile("Images\\greenlaser.png");
        public static SoundPlayer laserPew = new SoundPlayer("Sounds\\pew.wav");
        public static bool left, right, up, down, pew, isSpacePressed = true;
        static Image currentMember = Image.FromFile("Images\\fr_out.png");
        public static SoundPlayer testSound = new SoundPlayer("Sounds\\yeah.wav");
        public static Image imageHP = Image.FromFile("Images\\hpbar3point.png");
        public static int enemySpawnTimer = 0;

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
            Load();
        }
        #endregion

        #region HUD
        //Инициализация HUD
        private static MyHUD myHUD = new MyHUD(new Point(0, 710), new Size(290, 140));

        #endregion

        #region Загрузка объектов

        static public void AddEnemy()
        {
            for (int i = 0; i < 2; i++)
            {
                enemyShips.Add(new EnemyShip(new Point(Game.Width, Game.random.Next(0, Game.Height)), new Point(5, 5), new Size(100, 40)));
            }
        }
        static public void Load()
        {
            AddEnemy();

        }
        #endregion

        public static void Draw()
        {
            // Проверяем вывод графики
            Buffer.Graphics.DrawImage(background, 0, 0);
            switch (health)
            {
                case 3: 
                    imageHP = Image.FromFile("Images\\hpbar3point.png");
                    mainShipImage = Image.FromFile("Images\\planetExpress.png");
                    break; 
                case 2: 
                    imageHP = Image.FromFile("Images\\hpbar2point.png"); 
                    mainShipImage = Image.FromFile("Images\\planetexpress_damaged.png");
                    break;
                case 1:
                    imageHP = Image.FromFile("Images\\hpbar1point.png");
                    mainShipImage = Image.FromFile("Images\\planetexpress_damaged_more.png");
                    break; 
            }
            mainShip.Draw(mainShipImage);
            myHUD.Draw(imageHP);
            foreach (GreenLasers greenLaser in lasers)
            {
                greenLaser.Draw(greenLaserImage);
            }
            foreach (EnemyShip enemyShip in enemyShips)
            {
                enemyShip.Draw(enemyShipImage);
            }
            foreach (FallingBody crewMember in crewMembers)
            {
                crewMember.Draw(currentMember);
            }

            Buffer.Render();
        }
        public static void Update()
        {
            mainShip.Update();
            myHUD.Update();
            enemySpawnTimer++;
            if ((enemySpawnTimer%100) == 0)
            {
                AddEnemy();
            }

            foreach (EnemyShip enemyShip in enemyShips)
            {
                enemyShip.Update();
                if (mainShip.Collision(enemyShip))
                {

                    if (health == 3)
                    {
                        currentMember = Image.FromFile("Images\\fr_out.png");
                    }
                    else if (health == 2)
                    {
                        currentMember = Image.FromFile("Images\\bender_out.png");

                    }
                    else
                    {
                        currentMember = Image.FromFile("Images\\lila_out.png");
                        mainShipImage = Image.FromFile("Images\\project_Explosion.png");
                    }

                    
                    health--;
                    mainShip.FallingMember();
                    enemyShip.NeedToRemove = true;
                    

                }
            }
            foreach (GreenLasers greenLaser in lasers)
            {
                greenLaser.Update();
                foreach (EnemyShip enemyShip in enemyShips)
                {

                    if (greenLaser.Collision(enemyShip))
                    {
                        greenLaser.NeedToRemove = true;
                        enemyShip.NeedToRemove = true;
                        testSound.Play();
                    }
                   
                }
            }

            foreach (FallingBody crewMember in crewMembers)
            {
                crewMember.Update();
            }


            lasers.RemoveAll(item => item.NeedToRemove);
            enemyShips.RemoveAll(item => item.NeedToRemove);
            crewMembers.RemoveAll(item => item.NeedToRemove);


        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

    }
}
