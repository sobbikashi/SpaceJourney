using System.Drawing;




namespace SpaceJourney.Objects
{
    abstract class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;



        public BaseObject()
        {
            Pos = new Point(0, 0);
            Dir = new Point(0, 0);
            Size = new Size(0, 0);


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
        static Image mainShipImage = Image.FromFile("Images\\1.png");
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
        

    }
}
         
    
