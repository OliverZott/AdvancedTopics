using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqAndLambda
{
    class Program
    {
        static void Main(string[] args)
        {

            string sentence = "I love cats.";
            string[] catNames = { "Kosto", "Garfield", "Bob", "John" };
            int[] numbers = new int[10];

            Random rng = new Random();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rng.Next(-10, 10);
            }


            // Array to List - Two versions
            Console.WriteLine(" ---------------------- using ToList().ForEach() ----------------------");
            numbers.ToList().ForEach(Console.WriteLine);

            Console.WriteLine(" ---------------------- using new List<int>(numbers) ----------------------");
            var numberList = new List<int>(numbers);
            numberList.ForEach(Console.WriteLine);


            // Using LINQ
            Console.WriteLine(" ---------------------- using LINQ ----------------------");
            var getNumbers = from number in numbers select number;
            Console.WriteLine(string.Join(',', getNumbers));



        }
    }
}
