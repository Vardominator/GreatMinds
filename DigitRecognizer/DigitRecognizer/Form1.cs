using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitRecognizer
{

    public partial class Form1 : Form
    {
        
        bool canPaint = false;
        int width = 10;
        int height = 10;

        Graphics gfx;

        Bitmap bitmap;
        bool mouseClicked = false;

        int drawRadius;

        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gfx = Graphics.FromImage(bitmap);
            gfx.Clear(Color.FromArgb(0, 0, 0));
            pictureBox1.BackColor = Color.FromArgb(129, 129, 129);
            timer1.Enabled = true;
            predictedNumber.Font = new Font("Arial", 24, FontStyle.Bold);
            trackBar1.Value = 10;
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            pictureBox1.Image = bitmap;

        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            canPaint = true;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            canPaint = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseClicked = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseClicked = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (canPaint && mouseClicked)
            {
   
                gfx.FillEllipse(Brushes.White, e.X - width / 2, e.Y - height / 2, width, height);

            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            gfx.Clear(Color.FromArgb(0,0,0));
        }

        private void predict_Click(object sender, EventArgs e)
        {
            try
            {
                // change resolution
                Bitmap newBitmap = new Bitmap(bitmap, new Size (20, 20));
                newBitmap.Save(@"C:\Users\barse\Desktop\OngoingSoftwareProjects\DigitRecognizer\scaledImage.jpg", ImageFormat.Jpeg);

                octaveOutput.Text = "Image Saved!";

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.StackTrace);
            }
           

        }


        private void Train_Click(object sender, EventArgs e)
        {

            Process process = new Process();
            process.StartInfo.FileName = @"C:\Users\barse\Desktop\OngoingSoftwareProjects\DigitRecognizer\run.bat";
            process.StartInfo.WorkingDirectory = @"C:\Users\barse\Desktop\OngoingSoftwareProjects\DigitRecognizer";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;

            process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);


            process.Start();
            process.BeginOutputReadLine();
            process.WaitForExit();

        }

        static void OutputHandler(object sendingProcess, DataReceivedEventArgs outline)
        {
            Console.WriteLine(outline.Data);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            width = trackBar1.Value;
            height = trackBar1.Value;
        }
    }
}
