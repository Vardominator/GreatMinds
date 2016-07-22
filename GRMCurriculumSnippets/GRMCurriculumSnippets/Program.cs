using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRMCurriculumSnippets
{
    class Program
    {

        static void Main(string[] args)
        {

            GenericList<int, string> genericList = new GenericList<int, string>();

        }


        public static void TestSum()
        {

            int[] intArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            string[] stringArray = { "Hello", "everyong" };

            Print(intArray);
            Print(stringArray);

        }

        static void Print<T>(T[] array)
        {

            foreach (T item in array)
            {
                Console.WriteLine(item);
            }

        }


    }

    public class Sprite
    {
        //...
    }

    public class DrawableRectangle : Sprite
    {
        //...
    }

    public class DrawableCircle : Sprite
    {
        //...
    }

}
