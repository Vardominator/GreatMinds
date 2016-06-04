using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    class InsertionSort
    {
        static void Main(string[] args)
        {

            int[] testArray = { 31, 41, 59, 26, 41, 58 };

            for (int i = 1; i < testArray.Length; i++)
            {

                int something = testArray[i];

                int j = i - 1;

                while(j >= 0 && something < testArray[j])
                {
                    // keeping moving shit to the right
                    testArray[j + 1] = testArray[j];
                    j--;
                }
                // After the last j-- the final spot is left open to fill on by the appropriate value
                testArray[j + 1] = something;

            }

            for (int i = 0; i < testArray.Length; i++)
            {
                Console.WriteLine(testArray[i]);
            }
            Console.ReadKey();

        }
    }
}
