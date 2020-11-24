using System.Drawing;
using SpaceJourney.Objects;

namespace SpaceJourney.Objects.HUD
{
    abstract class HUD
    {
        protected Point Pos;       
        protected Size Size;
        public bool NeedToRemove;



        public HUD()
        {
            Pos = new Point(0, 0);            
            Size = new Size(0, 0);
            NeedToRemove = false;
        }

        public HUD(Point pos, Size size)
        {
            Pos = pos;            
            Size = size;
        }


        public abstract void Draw();

        public abstract void Update();
    }

    class MyHUD : HUD
    {
        static public Image imageHP = Image.FromFile("Images\\hpbar3point.png");
        public MyHUD(Point pos, Size size) : base(pos, size)
        {
            
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(imageHP, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {            
        }
    }

}

