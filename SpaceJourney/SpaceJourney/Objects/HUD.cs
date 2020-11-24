using System.Drawing;
using SpaceJourney.Objects;

namespace SpaceJourney.Objects
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
    //class MyHUD_0 : HUD
    //{
    //    public static Image hp_0_image = Image.FromFile("Images\\hpbar.png");       
    //    public MyHUD_0(Point pos, Size size) : base(pos, size)
    //    {
    //    }
    //    public override void Draw()
    //    {
    //        Game.Buffer.Graphics.DrawImage(hp_0_image, Pos.X, Pos.Y, Size.Width, Size.Height);
    //    }
    //    public override void Update()
    //    {
    //    }                
    //}
    //class MyHUD_1 : HUD
    //{
    //    public static Image hp_1_image = Image.FromFile("Images\\hpbar_bender.png");
    //    public MyHUD_1(Point pos, Size size) : base(pos, size)
    //    {
    //    }
    //    public override void Draw()
    //    {
    //        Game.Buffer.Graphics.DrawImage(hp_1_image, Pos.X, Pos.Y, Size.Width, Size.Height);
    //    }
    //    public override void Update()
    //    {
    //    }
    //}
    //class MyHUD_2 : HUD
    //{
    //    public static Image hp_2_image = Image.FromFile("Images\\hpbar_lila.png");
    //    public MyHUD_2(Point pos, Size size) : base(pos, size)
    //    {
    //    }
    //    public override void Draw()
    //    {
    //        Game.Buffer.Graphics.DrawImage(hp_2_image, Pos.X, Pos.Y, Size.Width, Size.Height);
    //    }
    //    public override void Update()
    //    {
    //    }
    //}

    //class MyHUD_3 : HUD
    //{
    //    public static Image hp_3_image = Image.FromFile("Images\\hpbar_fr.png");
    //    public MyHUD_3(Point pos, Size size) : base(pos, size)
    //    {
    //    }
    //    public override void Draw()
    //    {
    //        Game.Buffer.Graphics.DrawImage(hp_3_image, Pos.X, Pos.Y, Size.Width, Size.Height);
    //    }
    //    public override void Update()
    //    {
    //    }
    //}
    //class MyHUD : HUD
    //{
    //    public MyHUD (Point pos, Size size): base (pos, size)
    //    {

    //    }
    //}

}

