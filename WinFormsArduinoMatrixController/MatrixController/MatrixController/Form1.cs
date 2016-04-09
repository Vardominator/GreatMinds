using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixController
{
    public partial class Form1 : Form
    {
        SerialPort arduinoPort = new SerialPort("COM103", 9600);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            arduinoPort.Open();

            int pixelsPerRow = 8;
            int pixelsPerCol = 8;

            for (int row = 0; row < pixelsPerRow; row++)
            {
                for (int col = 0; col < pixelsPerCol; col++)
                {
                    Button button = new Button();
                    button.Size = new Size(30, 30);
                    button.Location = new Point(button.Width * col + 20, button.Height * row + 20);
                    button.Tag = new Point(col, row);
                    button.Click += button_Click;
                    button.BackColor = Color.Black;

                    Controls.Add(button);
                }
            }

        }

        void button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            if (colorPicker.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                clickedButton.BackColor = colorPicker.Color;                
                Point pixel = (Point)clickedButton.Tag;

                string message = String.Format("*{0},{1},{2},{3},{4}#", pixel.X, pixel.Y, colorPicker.Color.R, colorPicker.Color.G, colorPicker.Color.B);

                arduinoPort.Write(message);
            }
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
            if(arduinoPort.IsOpen)
            {
                arduinoPort.Close();
            }            
        }
    }
}
