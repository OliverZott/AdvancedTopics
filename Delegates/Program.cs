using System;
using System.Collections.Generic;
using System.Linq;

namespace Delegates
{
    class Program
    {

        public delegate bool Filters(string item);
        public delegate void Printer(string message);


        static void Main()
        {

            string separator = new String('-', 30);

            #region Example 1
            Console.WriteLine("\n" + separator + " Example 1 " + separator);
            String[] names = { "Alice", "Bob", "Siggi", "Magdalena", "Oliver", "Lissi", "Todd", "Al", "Petra", "Alex" };

            // Use delegate as method argument: methods for filtering can be used as variable.
            List<string> resultList = NamesLengthFilter(names, equalsFive);
            List<string> resultList2 = NamesLengthFilter(names, item => item.Length == 4);      // Use Lambda expression instead of methods
            //resultList2.OrderBy(i => i.Length).ToList().ForEach(i => Console.WriteLine($"Length: {i.Length} - {i}"));

            // Declare and initialize delegate
            Filters filter = lessThanFive;
            filter += greateThanFive;
            filter += equalsFive;
            //Console.WriteLine(filter("TestWord"));  

            // Only last method returned by delegate ... to get all delegate-methods:
            List<bool> lengthFilterResult = new();
            foreach (var del in filter.GetInvocationList())
            {
                var result = del.DynamicInvoke("TestWord");
                lengthFilterResult.Add((bool)result);
                //Console.WriteLine(result);
            }

            // get all delegate methods easier with Lambda Expressions
            List<bool> results = filter.GetInvocationList().Select(del => (bool)del.DynamicInvoke("TestWord")).ToList();
            Console.WriteLine(String.Join(", ", results));

            #endregion

            #region Example 2
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

        }


        #region Example 1 - Simple Delegate implementation with methods and chaining 
        // Filter methods used as delegate
        public static bool lessThanFive(string input)
        {
            return input.Length < 5;
        }
        public static bool greateThanFive(string input)
        {
            return input.Length > 5;
        }
        public static bool equalsFive(string input)
        {
            return input.Length == 5;
        }

        // Function to check for string length for items in a sting array
        public static List<string> NamesLengthFilter(string[] names, Filters filter)
        {
            List<string> result = new();

            foreach (var name in names)
            {
                if (filter(name))
                {
                    result.Add(name);
                }
            }


            return result;
        }
        #endregion

        #region Example 2 - Chaining delegates (methods)
        public static void Print(string message)
        {
            Console.WriteLine(message);
        }
        public static void PrintTwice(string message)
        {
            Console.WriteLine(message + " - twice");
            Console.WriteLine(message + " - twice");
        }
        #endregion
    }
}
