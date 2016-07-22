using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMRCurriculumArraysLinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {


            int[] randomNumbers = new int[10];

            int numbersLength = randomNumbers.Length;

            string[] cars = { "Tesla", "BMW", "Alpha Romeo", "Porsche", "Ferrari" };


            Random random = new Random();

            for (int index = 0; index < numbersLength; index++)
            {
                randomNumbers[index] = random.Next(0, 101);
            }

            for (int index = 0; index < randomNumbers.Length; index++)
            {

                Console.WriteLine(string.Format("Index: {0}, Value: {1}", index, randomNumbers[index]));

            }


            string[,] carModels = new string[,]
            {
                {"Roadster", "Model S", "Model X" },    // Tesla
                {"328i", "i8","M5" },                   // BMW
                {"Spide", "GT", "Brera" }               // Alpha Romeo
            };

            int[,] random2dArray = new int[5, 4];

            for (int row = 0; row < random2dArray.GetLength(0); row++)
            {
                for (int column = 0; column < random2dArray.GetLength(1); column++)
                {
                    random2dArray[row, column] = random.Next(0, 101);
                }
            }

        }
    }
}
