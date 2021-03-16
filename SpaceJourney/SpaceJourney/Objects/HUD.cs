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


        public abstract void Draw(Image image);

        public abstract void Update();
    }

    class MyHUD : HUD
    {
              
        public MyHUD(Point pos, Size size) : base(pos, size)
        {
            
        }
        public override void Draw(Image objectImage)
        {
            Game.Buffer.Graphics.DrawImage(objectImage, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        public override void Update()
        {            
        }
    }

}

