using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakePiece
{
    class Food : DrawableRectangle
    {

        Random rand;
        //public static int screenX;
        //public static int screenY;

        public Food(int x, int y, int w, int h, Color color)
        {

            PosX = x;
            PosY = y;
            Width = w;
            Height = h;

            SbErase = new SolidBrush(Color.White);
            SbDraw = new SolidBrush(color);

            hitbox = new Rectangle(PosX, PosY, Width, Height);

            // Random placement of food
            rand = new Random();

        }

        public override void Erase(Graphics gfx)
        {
            gfx.FillRectangle(SbErase, PosX, PosY, Width, Height);
        }

        public override void Update()
        {
            
            PosX = rand.Next(ScreenX);
            PosY = rand.Next(ScreenY);
            hitbox.X = PosX;
            hitbox.Y = PosY;

        }

        public override void Draw(Graphics gfx)
        {
            gfx.FillRectangle(SbDraw, PosX, PosY, Width, Height);
        }

    }
}
