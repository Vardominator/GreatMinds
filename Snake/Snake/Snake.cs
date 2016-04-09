using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakePiece 
{

    class SnakePiece : DrawableRectangle
    {

        private int direction;

        public int Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public SnakePiece(int x, int y, int w, int h, Color color)
        {
            
            PosX = x;
            PosY = y;
            Width = w;
            Height = h;

            SbDraw = new SolidBrush(color);
            SbErase = new SolidBrush(Color.White);

            hitbox = new Rectangle(PosX, PosY, Width, Height);

        }

        public override void Erase(Graphics gfx)
        {
            gfx.FillRectangle(SbErase, PosX, PosY, Width, Height);
        }

        public override void Update()
        {

            // Snake steps are taken in increments of the width of the snake
            // This ensures that all pieces will follow the head in complete steps
            switch (direction)
            {
                case 1:
                    SpeedX = 0;
                    SpeedY = -Width;
                    break;
                case 2:
                    SpeedX = 0;
                    SpeedY = Width;
                    break;
                case 3:
                    SpeedX = Width;
                    SpeedY = 0;
                    break;
                case 4:
                    SpeedX = -Width;
                    SpeedY = 0;
                    break;
            }

            PosX += SpeedX;
            PosY += SpeedY;

            hitbox.X += SpeedX;
            hitbox.Y += SpeedY;

            if(PosX < 0)
            {
                PosX = ScreenX;
            }
            if(PosX > ScreenX)
            {
                PosX = 0;
            }
            if(PosY < 0)
            {
                PosY = ScreenY;
            }
            if(PosY > ScreenY)
            {
                PosY = 0;
            }


        }

        public override void Draw(Graphics gfx)
        {
            gfx.FillRectangle(SbDraw, PosX, PosY, Width, Height);
        }

    }




}
