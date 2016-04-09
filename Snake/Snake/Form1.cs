using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakePiece
{
    public partial class Form1 : Form
    {

        Graphics gfx;
        Bitmap bitmap;

        List<SnakePiece> snake;
        SnakePiece head;
        Food food;

        int step = 20;
        //Set screen size for all sprites

        Random rand;

        private int gameState = 1;

        public Form1()
        {

            InitializeComponent();

            bitmap = new Bitmap(ClientSize.Width, ClientSize.Height);
            gfx = Graphics.FromImage(bitmap);

            snake = new List<SnakePiece>();

            head = new SnakePiece(0, 0, 20, 20, Color.Black);

            snake.Add(head);

            rand = new Random();
            food = new Food(rand.Next(ClientSize.Width - 15), rand.Next(ClientSize.Height - 15), 15, 15, Color.Red);

            DrawableRectangle.screenX = ClientSize.Width;
            DrawableRectangle.screenY = ClientSize.Height;
            //DrawableRectangle.backColor = Color.White;
            
            // Enable timer
            timer1.Enabled = true;

            // Set timer interval
            timer1.Interval = 100;
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            food.Erase(gfx);
            

            for(int i = 0; i < snake.Count; i++)
            {
                snake[i].Erase(gfx);
            }

            foreach (SnakePiece piece in snake)
            {
                piece.Update();
                piece.Draw(gfx);
            }

            if (head.hitbox.IntersectsWith(food.hitbox))
            {

                food.Update();

                int tailDirection = snake[snake.Count - 1].Direction;
                int tailX = snake[snake.Count - 1].PosX;
                int tailY = snake[snake.Count - 1].PosY;

                SnakePiece newPiece;

                // 1: North, 2: South, 3: East, 4: West
                switch (tailDirection)
                {
                    case 1:
                        newPiece = new SnakePiece(tailX, tailY + step, 20, 20, Color.Black);
                        newPiece.Direction = tailDirection;
                        snake.Add(newPiece);
                        break;
                    case 2:
                        newPiece = new SnakePiece(tailX, tailY - step, 20, 20, Color.Black);
                        newPiece.Direction = tailDirection;
                        snake.Add(newPiece);
                        break;
                    case 3:
                        newPiece = new SnakePiece(tailX - step, tailY, 20, 20, Color.Black);
                        newPiece.Direction = tailDirection;
                        snake.Add(newPiece);
                        break;
                    case 4:
                        newPiece = new SnakePiece(tailX + step, tailY, 20, 20, Color.Black);
                        newPiece.Direction = tailDirection;
                        snake.Add(newPiece);
                        break;
                }
                
            }


            for (int i = 1; i < snake.Count; i++)
            {
                if (head.Hitbox.IntersectsWith(snake[i].Hitbox))
                {
                    timer1.Enabled = false;
                    MessageBox.Show("It's over!");
                }
            }


            for (int i = snake.Count - 1; i > 0; i--)
            {
                // Set the previous direction for every piece
                snake[i].Direction = snake[i - 1].Direction;
            }

            food.Draw(gfx);

            pictureBox1.Image = bitmap;

        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.W:
                    head.Direction = 1;
                    return;
                case Keys.S:
                    head.Direction = 2;
                    return;
                case Keys.D:
                    head.Direction = 3;
                    return;
                case Keys.A:
                    head.Direction = 4;
                    return;
            }
             
        }
    }
}
