using System;
using System.Drawing;

namespace ExtensionMethods
{
    public static class Extensions
    {


        // Extension for Point Object
        public static Distance DistanceTo(this Point p1, Point p2)
        {

            int xDist = p2.X - p1.X;
            int yDist = p2.Y - p1.Y;
            Console.WriteLine($"Distance between the points is: " + 
                $"\n{xDist} in x-direction" + 
                $"\n{yDist} in y-direction");

            return new Distance() { XDistance = xDist, YDistance = yDist } ;
        }



        /// <summary>
        /// Sorting array with custom bubble-sort implementation
        /// </summary>
        /// <param name="array"></param>
        public static void Sort(this int[] array)
        {
            int temp = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }
            }

        }

        /// <summary>
        /// Sorting array with custom bubble-sort implementation and optional reversing
        /// </summary>
        /// <param name="array"></param>
        /// <param name="reverse">Optional parameter for descending order</param>
        public static void Sort(this int[] array, bool reverse = false)
        {

            array.Sort();

            if (reverse)
            {
                Array.Reverse(array);
            }

        }

        public static void Reverse(this int[] array)
        {
            Array.Reverse(array);
        }
    }
}
