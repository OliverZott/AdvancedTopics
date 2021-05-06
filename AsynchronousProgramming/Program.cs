using System;
using System.Threading.Tasks;

namespace AsynchronousProgramming
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            // Task Creation - methods
            // Task t1 = new Task(ConcatenateCharsFirst);
            // t1.Start();
            // Task t2 = Task.Run(new Action(ConcatenateCharsFirst))


            const int count = 200000;
            const char charToConcatenate = '-';


            /*
            var t = Task.Factory.StartNew(() => ConcatenateCharsFirst(charToConcatenate, count));
            Console.WriteLine("In progress (while concatenated)");
            t.Wait();
            Console.WriteLine($"\nCompleted (after concatenated). String length = {t.Result.Length}");
            */

            Console.WriteLine("Before starting async method.");
            var t = ConcatenateCharsAsync(charToConcatenate, count);
            //t2.Wait();
            Console.WriteLine("After starting async method.");
            Console.WriteLine($"\nMethod two example with Length = {t.Result.Length}.");


        }


        private static string ConcatenateCharsFirst(char charToConcatenate, int count)
        {
            var concatenatedString = string.Empty;

            for (var i = 0; i < count; i++)
            {
                concatenatedString += '1';

                if (i % 10000 == 0)
                {
                    Console.Write('.');
                }
            }

            return concatenatedString;
        }


        private static string ConcatenateChars(char charToConcatenate, int count)
        {
            var concatenatedString = string.Empty;

            for (var i = 0; i < count; i++)
            {
                concatenatedString += '1';

                if (i % 10000 == 0)
                {
                    Console.WriteLine($"Step {i / 10000}");
                }
            }

            return concatenatedString;
        }


        private static async Task<string> ConcatenateCharsAsync(char charToConcatenate, int count)
        {

            var t = Task<string>.Factory.StartNew(() => ConcatenateChars(charToConcatenate, count));

            Console.WriteLine("Inside async method, after Task.Start");

            return await t;

        }


    }
}
