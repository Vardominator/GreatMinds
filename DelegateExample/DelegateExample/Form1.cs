using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelegateExample
{
    public partial class Form1 : Form
    {
        Graphics graphics;

        public delegate void DrawFunc(Pen pen, int x, int y, int width, int height);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {

            graphics = CreateGraphics();

            drawObject(graphics.DrawEllipse, Pens.Red, 10, 10, 50, 50);

            var myAction = new Action<Pen, int, int, int, int>(graphics.DrawRectangle);
        }

        private void drawObject(DrawFunc drawThis, Pen pen, int x, int y, int width, int height)
        {
            drawThis(pen, x, y, width, height);
            
        }
    }
}
