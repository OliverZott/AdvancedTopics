using System;
using System.Drawing;
using System.Linq;

namespace ExtensionMethods
{
    public static class Program
    {
        static void Main(string[] args)
        {

            // Example 2
            // Extension methods for objects
            Point pointOne = new Point(20, 30);
            Point pointTwo = new Point(19, 15);

            pointOne.DistanceTo(pointTwo);
            Distance dist = pointOne.DistanceTo(pointTwo);
            Console.WriteLine(dist.XDistance);

            // Example 1
            int[] array = { 5, 2, 17, 43, 7, 548, 23, 5, 7, 87, 23 };

            array.Sort(true);
            array.ToList().ForEach(i => Console.WriteLine(i));


        }


    }
}
