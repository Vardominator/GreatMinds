using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMRElementarySorting
{
    class Program
    {

        static Random random = new Random();

        static void Main(string[] args)
        {

            int[] testArray = new int[20];

            generateArrayVals(testArray);
            //bubbleSort(testArray);
            //selectionSort(testArray);
            insertionSort(testArray);
            printArray(testArray);

        }

        static void generateArrayVals(int[] inputArray)
        {

            for (int index = 0; index < inputArray.Length; index++)
            {

                inputArray[index] = random.Next(0, 101);

            }

        }

        static void bubbleSort(int[] unsortedArray)
        {

            for (int i = unsortedArray.Length - 1; i >= 0; i--)
            {
                for(int j = 0; j < i; j++)
                {

                    if(unsortedArray[j] > unsortedArray[j + 1])
                    {

                        swap(unsortedArray, j, j + 1);

                    }

                }
            }

        }

        static void swap(int[] array, int firstIndex, int secondIndex)
        {

            int temp = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = temp;

        }

        static void selectionSort(int[] unsortedArray)
        {

            int minIndex = 0;

            for (int i = 0; i < unsortedArray.Length - 1; i++)
            {

                minIndex = i;

                for(int j = i + 1; j < unsortedArray.Length; j++)
                {

                    if(unsortedArray[j] < unsortedArray[minIndex])
                    {
                        minIndex = j;
                    }

                }

                if (minIndex != i)
                {
                    swap(unsortedArray, i, minIndex);
                }

            }

        }


        static void insertionSort(int[] unsortedArray)
        {
            
            for(int i = 1; i < unsortedArray.Length; i++)
            {
                int currentValue = unsortedArray[i];

                int j = i - 1;

                while(j >= 0 && currentValue < unsortedArray[j])
                {

                    unsortedArray[j + 1] = unsortedArray[j];
                    j--;

                }
                unsortedArray[j + 1] = currentValue;

            }

        }


        static void printArray(int[] inputArray)
        {

            Console.Write("[");

            for (int index = 0; index < inputArray.Length - 1; index++)
            {

                Console.Write(string.Format("{0}, ", inputArray[index]));

            }

            Console.WriteLine(string.Format("{0}]", inputArray[inputArray.Length - 1]));

        }
    }
}
