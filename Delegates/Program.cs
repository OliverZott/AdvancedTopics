using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace Delegates
{
    public class Program
    {

        public delegate bool Filters(string item);
        public delegate void Printer(string message);
        public delegate int CheckLength(string message);


        public static void Main()
        {
            var separator = new string('-', 30);
            string[] names = { "Alice", "Bob", "Siggi", "Magdalena", "Oliver", "Lisi", "Todd", "Al", "Petra", "Alex" };


            #region Example 4 - Anonymous Methods

            Func<int, int, bool> checkIntegers = (i, j) => i < 8 + j;
            Action printSomething = () => Console.WriteLine("Printing");
            printSomething();
            Action<int, int> sumOfTwoNumbers = (i, j) =>
            {
                Console.WriteLine("First number: " + i);
                Console.WriteLine("Second number: " + j);
                Console.WriteLine("The sum is: " + (j + i));
            };
            sumOfTwoNumbers(7, 4);

            List<int> nums = new List<int>() { 1, 2, 3 };

            Func<string[], Func<string, bool>, List<string>> extractStrings2 = (array, func) =>
            {
                List<string> result = new();

                foreach (var item in array)
                {
                    if (func(item))
                    {
                        result.Add(item);
                    }
                }

                return result;
            };
            Func<string, bool> lessThanFive2 = x => x.Length < 5;

            List<string> namesLessThanFive2 = extractStrings2(names, lessThanFive2);
            namesLessThanFive2.ForEach(Console.WriteLine);

            #endregion



            #region Example 3 - Func and Action

            Func<string, bool> lessThanFive = LessThanFive;
            Func<string, bool> greaterThanSix = x => x.Length > 6;
            Action<string> printer = PrintTwice;
            printer += Print;

            List<string> namesLessThanFive = ExtractStrings(names, greaterThanSix);
            namesLessThanFive.ForEach(Console.WriteLine);
            printer("message test!");

            #endregion



            #region Example 2 - Delegate Chain

            Console.WriteLine("\n" + separator + " Example 2 " + separator);

            //assigning Print-method to Printer-delegate and save it in p-delegate value - PUBLISHER
            Printer p = Print;

            // chaining delegates - SUBSCRIBERS
            p += PrintTwice;
            p += Print;
            p += Print;
            p -= Print;
            p("message");

            // show all delegates
            foreach (var del in p.GetInvocationList())
            {
                Console.WriteLine(del.Method);
            }
            Delegate[] delegates = p.GetInvocationList();

            #endregion



            #region Example 1

            Console.WriteLine("\n" + separator + " Example 1 " + separator);

            List<string> resultList = NamesLengthFilter(names, EqualsFive);
            List<string> resultList2 = NamesLengthFilter(names, item => item.Length == 4);
            //resultList2.OrderBy(i => i.Length).ToList().ForEach(i => Console.WriteLine($"Length: {i.Length} - {i}"));

            Filters filter = LessThanFive;
            filter += GreaterThanFive;
            filter += EqualsFive;
            //Console.WriteLine(filter("TestWord"));  

            List<bool> results0 = new();
            foreach (var del in filter.GetInvocationList())
            {
                var result = del.DynamicInvoke("TestWord");
                results0.Add((bool)result);
                //Console.WriteLine(result);
            }

            List<bool> results1 = filter.GetInvocationList()
                .Select(del => (bool)del.DynamicInvoke("TestWord"))
                .ToList();
            //Console.WriteLine(String.Join(", ", results1));


            var filterResults = GetAllDelegateResults<bool>(filter, "TestWord");
            filterResults.ForEach(i => Console.WriteLine(i));

            CheckLength checkLength = x => x.Length;
            checkLength += x => x.Length + 1;
            checkLength += x => x.Length + 2;
            List<int> lengthResults = GetAllDelegateResults<int>(checkLength, "TestWord");
            lengthResults.ForEach(Console.WriteLine);   // method group instead of lambda

            #endregion

        }


        #region Example 1 - Simple Delegate implementation with methods and chaining

        private static List<T> GetAllDelegateResults<T>(Delegate del, object parameter = null)
        {
            List<T> result = del.GetInvocationList()
                                .Select(d => (T)d.DynamicInvoke(parameter))
                                .ToList();
            return result;
        }

        private static bool LessThanFive(string input)
        {
            return input.Length < 5;
        }

        private static bool GreaterThanFive(string input)
        {
            return input.Length > 5;
        }

        private static bool EqualsFive(string input)
        {
            return input.Length == 5;
        }

        private static List<string> ExtractStrings(string[] strings, Func<string, bool> func)
        {
            return strings.Where(func).ToList();
        }

        private static List<string> NamesLengthFilter(string[] names, Filters filter)
        {
            return names.Where(name => filter(name)).ToList();
        }

        #endregion




        #region Example 2 - Chaining delegates (methods)

        private static void Print(string message)
        {
            Console.WriteLine(message);
        }
        private static void PrintTwice(string message)
        {
            Console.WriteLine(message + " - twice");
            Console.WriteLine(message + " - twice");
        }

        #endregion
    }
}
