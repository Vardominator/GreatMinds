using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            Random rand = new Random();


            int[] vals = new int[1000];

            for (int i = 0; i < vals.Length; i++)
            {
                vals[i] = rand.Next(1001);
                //Console.WriteLine(vals[i]);
            }

            for (int i = vals.Length - 1; i > 0; i--)
            {

                int maxIndex = i;
                int temp = 0;

                for(int j = 0; j < i; j++)
                {
                    if(vals[j] > vals[maxIndex])
                    {
                        maxIndex = j;
                    }
                }

                temp = vals[i];
                vals[i] = vals[maxIndex];
                vals[maxIndex] = temp;
            }

           
            


            for (int i = 0; i < vals.Length; i++)
            {
                //Console.WriteLine(vals[i]);
            }

            int[] testArr = new int[10];
            int[] LeftArr = { 2, 5, 9, 15, 20, 40};
            int[] RightArr = { 1, 2, 3, 10, 25 };

            merge(testArr, LeftArr, RightArr);

            for (int i = 0; i < testArr.Length; i++)
            {
                Console.WriteLine(testArr[i]);
            }


            Console.ReadKey();
        }

        public static void merge(int[] A, int[] Left, int[] Right)
        {
            int i = 0;
            int j = 0;

            for (int k = 0; k < A.Length; k++)
            {
                if (i < Left.Length && Left[i] <= Right[j])
                {
                    A[k] = Left[i];
                    i++;
                }
                else
                {
                    A[k] = Right[j];
                    j++;
                }
            }
        }
    }
}
