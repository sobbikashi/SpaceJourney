using System.Drawing;
using System.Media;
using SpaceJourney.Objects;

namespace SpaceJourney
{
    abstract class Express
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;



        public Express()
        {
            Pos = new Point(0, 0);
            Dir = new Point(0, 0);
            Size = new Size(0, 0);


        }

        public Express(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public abstract void Draw();

        public abstract void Update();
    }

    class MainShip : Express
    {
        public static Image mainShipImage = Image.FromFile("Images\\ht.gif");
        SoundPlayer laserPew = new SoundPlayer("Sounds\\pew.wav");
        public MainShip(Point pos, Point dir, Size size) : base(pos, dir, size)
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
        public void Shot()
        {
            Game.lasers.Add(new GreenLasers(new Point(Pos.X + 80, Pos.Y+10), new Point(20, 0), new Size(50, 10)));
            laserPew.Play();

        }


    }
}
