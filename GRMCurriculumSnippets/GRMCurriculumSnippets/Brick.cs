using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRMCurriculumSnippets
{
    class Brick
    {

        public static int BrickCount;

        private Vector2 position;
        private Rectangle hitbox;
        private int width;
        private int height;
        
        public Rectangle Hitbox
        {
            get { return hitbox; }
            set { hitbox = value; }
        }


        //...

        public Brick(Vector2 position, Rectangle hitbox, int width, int height)
        {
            this.position = position;
            this.hitbox = hitbox;
            this.width = width;
            this.height = height;
        }

        //...


        // ... Fields and contstructors


        public void Draw(SpriteBatch spriteBatch)
        {
            //...
        }

        public void Update(Ball ball)
        {
            if (hitbox.Intersects(ball.hitbox))
            {
                //...
            }
        }

    }

    class PowerUpBrick : Brick
    {
        
        //... Fields: All public and protected fields will be inhertied from Brick

        public PowerUpBrick(Vector2 position, Rectangle hitbox, int width, int height) 
            : base(position, hitbox, width, height)
        {
            //...Construction unique to PowerUpBrick
        }

        //... Methods: All public and protected methods will be inherited from Brick

    }


    public class Ball
    {
        public Rectangle hitbox;
    }

    public class SpriteBatch
    {
    }

    public class Vector2
    {
    }
}
