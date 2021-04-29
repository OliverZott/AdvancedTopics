using System;
using System.Collections.Generic;
using System.Linq;

namespace Delegates
{
    class Program
    {

        public delegate bool Filters(string item);


        static void Main()
        {
            String[] names = { "Alice", "Bob", "Siggi", "Magdalena", "Oliver", "Lissi", "Todd", "Al" };

            List<string> resultList = NamesLengthFilter(names, equalsFive);

            // methods for filtering can be used as variables in method arguments
            resultList.OrderBy(i => i.Length).ToList().ForEach(i => Console.WriteLine($"Length: {i.Length} - {i}"));
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
    }
}
