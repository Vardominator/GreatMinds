using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DigitRecognizer
{
    class DigitFinder
    {

        private List<int> digitsFound;

        public List<int> DigitsFound
        {
            get
            {
                if(digitCount > 0)
                {
                    return digitsFound;
                }
                else
                {
                    throw new Exception("No digits found");
                }
            }
        }

        private List<Rectangle> digitBoxes;

        public List<Rectangle> DigitBoxes
        {
            get { return digitBoxes; }
            set { digitBoxes = value; }
        }

        private int stepSize;

        public int StepSize
        {
            get { return stepSize; }
            set { stepSize = value; }
        }


        private int digitCount;

        public int DigitCount
        {
            get { return digitCount; }
            set { digitCount = value; }
        }


        public DigitFinder()
        {
            digitCount = 0;
            digitsFound = new List<int>();
            digitBoxes = new List<Rectangle>();
        }


        public void RunThrough(Bitmap image)
        {

            ///
            /// Make rectangles that have a width and height which divide the bitmap evenly.
            /// Increase size of the width and height and make sure bitmap.Width % rect.width == 0
            ///

            int imageWidth = image.Width;
            int imageHeight = image.Height;

            Rectangle initialRectangle = new Rectangle(0, 0, image.Width / 10, image.Height / 100);


            for (int i = 0; i < imageWidth; i++)
            {
                for (int j = 0; j < imageHeight; j++)
                {

                }
            }

        }

        public void AddRectangle(int x1, int y1, int x2, int y2)
        {

            digitBoxes.Add(new Rectangle(x1, y2, x2 - x1, y2 - y1));
           
        }

        public void DrawRectangle(Rectangle newBox, Bitmap image)
        {
           
        }

    }
}
