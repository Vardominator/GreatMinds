using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRMCurriculumSnippets
{
    class Paddle : Sprite
    {
        
        private int positionX;
        private int positionY;
        private int width;
        private int height;
        private Rectangle hitbox;

        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public Paddle(Rectangle ballHitbox)
        {
            //...
        }
        
        public Paddle(int posX, int posY, int width, int height)
        {
            //...
        }

        public void Update(int screenWidth, int screenHeight)
        {
            //...
        }

        public void Draw(Graphics graphics)
        {
            //...
        }

    }

    public class Graphics
    {
    }

    public class Rectangle
    {
        public bool Intersects(object hitbox)
        {
            return null;
        }
    }



    public enum CharacterState
    {
        Standing,
        Running,
        Walking,
        Jumping,
        Alive,
        Dead
    }



}
