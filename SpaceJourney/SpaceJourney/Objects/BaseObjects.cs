using System.Drawing;





namespace SpaceJourney.Objects
{
    interface ICollision
    {
        bool Collision(ICollision obj);
        Rectangle Rect { get; }
    }
    abstract class BaseObject : ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        public bool NeedToRemove;
        protected Image Image;



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

        public abstract void Draw(Image image);

        public abstract void Update();

        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);
        public Rectangle Rect => new Rectangle(Pos, Size);
    }
   

    class MainShip : BaseObject
    {
        
        public MainShip(Point pos, Point dir, Size size) : base (pos, dir, size)
        {
        }       
        public override void Update()
        {

        }
        public void Left()
        {
            if (Pos.X > 0)
            {
                do
                {
                    Pos.X = Pos.X - Dir.X;
                }
                while (!Game.left);
                
            }
                
        }

        //событие по нажатию кнопки Вправо
        public void Right()
        {
            if (Pos.X < Game.Width)
            {
                do
                {
                    Pos.X = Pos.X + Dir.X;
                }
                while (!Game.right);
            }
               
        }

        //событие по нажатию кнопки Вверх
        public void Up()
        {
            if (Pos.Y > 0) 
            {
                do
                {
                    Pos.Y = Pos.Y - Dir.Y;
                }
                while (!Game.up);
            }
        }

        //событие по нажатию кнопки Вниз
        public void Down()
        {
            if (Pos.Y < Game.Height) 
             {
                do
                {
                    Pos.Y = Pos.Y + Dir.Y;
                }
                while (!Game.down);
            }
        }

        public override void Draw(Image objectImage)
        {
            Game.Buffer.Graphics.DrawImage(objectImage, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public void Shot()
        {
            Game.lasers.Add(new GreenLasers(new Point(Pos.X + 80, Pos.Y + 10), new Point(20, 0), new Size(50, 10)));
            Game.laserPew.Play();
        }
        public void FallingMember()
        {
            Game.crewMembers.Add(new FallingBody(new Point(Pos.X, Pos.Y + 20), new Point(0, 5), new Size(30, 60)));
        }

    }

    class EnemyShip : BaseObject
    {
        
        public EnemyShip(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw(Image objectImage)
        {
            Game.Buffer.Graphics.DrawImage(objectImage, Pos.X, Pos.Y, Size.Width, Size.Height);
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
        
        public override void Draw(Image objectImage)
        {
            Game.Buffer.Graphics.DrawImage(objectImage, Pos.X, Pos.Y, Size.Width, Size.Height);
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
    class BackgroundObject : BaseObject
    {

        public BackgroundObject(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw(Image objectImage)
        {
            Game.Buffer.Graphics.DrawImage(objectImage, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
        }
    }

    class FallingBody : BaseObject
    {

        public FallingBody(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }
        public override void Draw(Image objectImage)
        {
            Game.Buffer.Graphics.DrawImage(objectImage, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.Y == 1200)
            {
                NeedToRemove = true;
            }
        }
        


        
    }

}


