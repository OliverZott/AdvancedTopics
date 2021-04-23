using System;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{AreEqual("bd", "as")}");
            Console.WriteLine($"{AreEqual1(23, 23)}");
            Console.WriteLine($"{AreEqual1(23, 23)}");
        }


        public static bool AreEqual1<T>(T num1, T num2)
        {
            return num1.Equals(num2);
        }

        // more "specific" generic method
        public static bool AreEqual<T>(T num1, T num2) where T : IComparable
        {
            return num1.CompareTo(num2) == 0;
        }
    }
}
