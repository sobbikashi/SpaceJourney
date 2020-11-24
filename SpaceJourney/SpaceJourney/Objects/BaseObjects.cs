﻿using System.Drawing;




namespace SpaceJourney.Objects
{
    abstract class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        public bool NeedToRemove;



        public BaseObject()
        {
            Pos = new Point(0, 0);
            Dir = new Point(0, 0);
            Size = new Size(0, 0);
            NeedToRemove = false;


        }

        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public abstract void Draw();

        public abstract void Update();
    }

    class MainShip : BaseObject
    {
        public static Image mainShipImage = Image.FromFile("Images\\planetExpress.png");
        public MainShip(Point pos, Point dir, Size size) : base (pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(mainShipImage, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {

        }
        public void Left()
        {
            if (Pos.X > 0) Pos.X = Pos.X - Dir.X;
        }

        //событие по нажатию кнопки Вправо
        public void Right()
        {
            if (Pos.X < Game.Width) Pos.X = Pos.X + Dir.X;
        }

        //событие по нажатию кнопки Вверх
        public void Up()
        {
            if (Pos.Y > 0) Pos.Y = Pos.Y - Dir.Y;
        }

        //событие по нажатию кнопки Вниз
        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y = Pos.Y + Dir.Y;
        }


    }

    class EnemyShip : BaseObject
    {
       static Image EnemyShipImage = Image.FromFile("Images\\enemy.png");
        public EnemyShip(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(EnemyShipImage, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;          
        }
    }
    class GreenLasers : BaseObject
    {
        public GreenLasers(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }
        static Image greenLaser = Image.FromFile("Images\\greenlaser.png");
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(greenLaser, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            //описываем перемещение по оси Y
            Pos.X = Pos.X + Dir.X;
            if (Pos.X == 1600)
            {
                //Game.score = Game.score + 100;
                NeedToRemove = true;
            }

        }
    }
}
         
    
