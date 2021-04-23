using System;
using System.Linq;

namespace ExtensionMethods
{
    public static class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 5, 2, 17, 43, 7, 548, 23, 5, 7, 87, 23 };

            // Extension method 
            array.Sort(true);
            array.ToList().ForEach(i => Console.WriteLine(i));

        }


    }
}
