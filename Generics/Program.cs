﻿using System;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {

            //
            // -------------------- 17. Example 2 - Sorting collections --------------------
            //
            int[] intArray = { 2, 5, 8, 1, 2, 42, 9, 46, 9, 12, 34, 62, 79, 45, 62, 0 };
            string[] strArray = { "aabc", "abba", "baac", "babc", "abac" };

            var sortedArray = MySort(strArray);
            System.Console.WriteLine(string.Join(", ", sortedArray));













            //
            // -------------------- 16. Example 1 - Simple method --------------------
            //
            /*
            Console.WriteLine($"{AreEqual("a", "a")}");
            Console.WriteLine($"{AreEqual(1, 1)}");
            Console.WriteLine($"{AreEqual(true, true)}");
            */
        }



        //
        // -------------------- 17. Example 2 - Sorting collections --------------------
        //
        public static T[] MySort<T>(T[] array) where T : IComparable
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {

                    if (array[i].CompareTo(array[j]) > 0)
                    {
                        T temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            Array.Reverse(array);
            return array;
        }






        //
        // -------------------- 16. Example 1 - Simple method --------------------
        //
        /*
        public static bool AreEqual0(object obj1, object obj2)
        {
            return obj1 == obj2;
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
        */
    }
}