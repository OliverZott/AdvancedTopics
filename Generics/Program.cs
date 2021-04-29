using System;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {

            //
            // -------------------- 20.+21. Example 4 - Operator Overloading & Indexer  --------------------
            //
            MyList<int> list1 = new() { 2, 3, 5, 8 };
            MyList<int> list2 = new() { 1, 1, 1, 1 };
            MyList<int> list3 = list1 + list2;
            foreach (int ele in list3)
            {
                Console.WriteLine(ele);
            }


            //
            // -------------------- 19. Example 3 - Generic Class  --------------------
            //
            /*
            MyList<int> listOne = new();
            listOne.Add(12);
            listOne.Add(3);
            listOne.Add(42);
            foreach (int ele in listOne)
            {
                Console.WriteLine(ele);
            }

            for (int i = 0; i < listOne.Count; i++)
            {
                var backwardsCount = listOne.Count - 1 - i;
                var item = listOne[listOne.Count - 1 - i];
                Console.WriteLine(item);
            }
            //*/


            //
            // -------------------- 18. Example 3 - Object specific generics  --------------------
            //
            /*
            Person p1 = new Person { Age = 27 };
            Person p2 = new() { Age = 27 };
            Console.WriteLine(AreEqual(p1, p2));
            Console.WriteLine(p1.CompareTo(p2));
            //*/


            //
            // -------------------- 17. Example 2 - Sorting collections --------------------
            //
            /*
            int[] intArray = { 2, 5, 8, 1, 2, 42, 9, 46, 9, 12, 34, 62, 79, 45, 62, 0 };
            string[] strArray = { "aabc", "abba", "baac", "babc", "abac" };

            var sortedArray = MySort(strArray);
            System.Console.WriteLine(string.Join(", ", sortedArray));
            //*/



            //
            // -------------------- 16. Example 1 - Simple method --------------------
            //
            /*
            Console.WriteLine($"{AreEqual("a", "a")}");
            Console.WriteLine($"{AreEqual(1, 1)}");
            Console.WriteLine($"{AreEqual(true, true)}");
            //*/
        }



        //
        // -------------------- 17. Example 2 - Sorting collections --------------------
        //
        public static T[] MySort<T>(T[] array) where T : IComparable<T>
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
        //*
        public static bool AreEqual0(object obj1, object obj2)
        {
            return obj1 == obj2;
        }
        public static bool AreEqual1<T>(T num1, T num2)
        {
            return num1.Equals(num2);
        }
        // more "specific" generic method
        public static bool AreEqual<T>(T num1, T num2) where T : IComparable<T>
        {
            return num1.CompareTo(num2) == 0;
        }
        //*/
    }
}
