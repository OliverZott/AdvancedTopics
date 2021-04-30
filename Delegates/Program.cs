using System;
using System.Collections.Generic;
using System.Linq;

namespace Delegates
{
    class Program
    {

        public delegate bool Filters(string item);
        public delegate void Printer(string message);
        public delegate int CheckLength(string message);


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

            List<bool> results0 = new();
            foreach (var del in filter.GetInvocationList())
            {
                var result = del.DynamicInvoke("TestWord");
                results0.Add((bool)result);
                //Console.WriteLine(result);
            }

            List<bool> results1 = filter.GetInvocationList().Select(del => (bool)del.DynamicInvoke("TestWord")).ToList();
            //Console.WriteLine(String.Join(", ", results1));

            // Use Method to get all return values from delegate-methods
            List<bool> filterResults = GetAllResults<bool>(filter, "TestWord");
            filterResults.ForEach(i => Console.WriteLine(i));

            CheckLength checkLength = x => x.Length;
            checkLength += x => x.Length + 1;
            checkLength += x => x.Length + 2;
            List<int> lengthResults = GetAllResults<int>(checkLength, "TestWord");
            lengthResults.ForEach(i => Console.WriteLine(i));
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
        // Method to fetch all return values of delegate-methods
        public static List<T> GetAllResults<T>(Delegate del, object parameter = null)
        {
            List<T> result = del.GetInvocationList()
                                .Select(d => (T)d.DynamicInvoke(parameter))
                                .ToList();
            return result;
        }
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
