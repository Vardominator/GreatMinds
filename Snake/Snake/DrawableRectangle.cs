using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakePiece
{

    abstract class DrawableRectangle
    {

        private int posX;
        private int posY;

        public static int screenX;
        public static int screenY;

        public static Color backColor;

        private int width;
        private int height;
        private int speedX;
        private int speedY;
        private SolidBrush sbDraw;
        private SolidBrush sbErase;

        public Rectangle hitbox;
       
        public int PosX
        {
            get { return posX; }
            set { posX = value; }
        }

        public int PosY
        {
            get { return posY; }
            set { posY = value; }
        }

        public int ScreenX
        {
            get { return screenX; }
            set { screenX = value; }
        }

        public int ScreenY
        {
            get { return screenY; }
            set { screenY = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public int SpeedX
        {
            get { return speedX; }
            set { speedX = value; }
        }

        public int SpeedY
        {
            get { return speedY; }
            set { speedY = value; }
        }

        public SolidBrush SbDraw
        {
            get { return sbDraw; }
            set { sbDraw = value; }
        }

        public SolidBrush SbErase
        {
            get { return sbErase; }
            set { sbErase = value; }
        }

        public Rectangle Hitbox
        {
            get { return hitbox; }
            set { hitbox = value; }
        }

        public abstract void Erase(Graphics gfx);

        public abstract void Update();

        public abstract void Draw(Graphics gfx);


    }
}
