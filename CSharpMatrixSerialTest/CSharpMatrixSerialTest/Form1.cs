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

namespace CSharpMatrixSerialTest
{
    public partial class Form1 : Form
    {

        //SerialPort arduinoPort = new SerialPort("COM9", 19200);

        // Dimensions of matrix
        int numCol = 8;
        int numRow = 8;


        public Form1()
        {

            
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //arduinoPort.Open();

            for(int row = 0; row < numRow; row++)
            {
                for(int col = 0; col < numCol; col++)
                {
                    // Create button
                    Button button = new Button();

                    // Set button params
                    button.Size = new Size(30, 30);
                    button.Location = new Point(button.Width * col + 20, button.Height * row + 20);
                    button.Tag = new Point(col, row);
                    button.BackColor = Color.Black;

                    // Click functionality
                    button.Click += Button_Click;

                    // Add button to form
                    Controls.Add(button);
                }
            }

        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            MessageBox.Show(clickedButton.Tag.ToString());
            if(colorPicker.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                clickedButton.BackColor = colorPicker.Color;
                Point pixel = (Point)clickedButton.Tag;

                string message = String.Format("{0},{1},{2},{3},{4}#", pixel.X, pixel.Y, colorPicker.Color.R, colorPicker.Color.G, colorPicker.Color.B);

                //arduinoPort.Write(message);
                MessageBox.Show(message);

            }
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
            //if (arduinoPort.IsOpen)
            //{
            //    arduinoPort.Close();
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = "clear";
            arduinoPort.Write(message);
        }
    }
}
