using System;

namespace ExtensionMethods
{
    public static class Extensions
    {

        /// <summary>
        /// Sorting array with custom bubble-sort implementation
        /// </summary>
        /// <param name="array"></param>
        public static void Sort(this int[] array)
        {
            int temp = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }
            }

        }

        /// <summary>
        /// Sorting array with custom bubble-sort implementation and optional reversing
        /// </summary>
        /// <param name="array"></param>
        /// <param name="reverse">Optional parameter for descending order</param>
        public static void Sort(this int[] array, bool reverse = false)
        {

            array.Sort();

            if (reverse)
            {
                Array.Reverse(array);
            }

        }

        public static void Reverse(this int[] array)
        {
            Array.Reverse(array);
        }
    }
}
