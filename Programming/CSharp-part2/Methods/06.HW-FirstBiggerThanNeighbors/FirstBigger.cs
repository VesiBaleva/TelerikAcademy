/* Write a method that returns the index of the first element in array that is bigger than its neighbors,
 * or -1, if there’s no such element.
Use the method from the previous exercise.
*/
using System;


    class FirstBigger
    {
        public static bool CheckThanNeighbors(int[] array, int position)
        {
            if (position == 0 || position == array.Length - 1)
            {
                return false;
            }
            else
            {
                if (array[position] > array[position - 1] && array[position] > array[position + 1])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static int IndexOfFirstBigger(int[] array)
        {
            int index = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (CheckThanNeighbors(array, i))
                {
                    index = i;
                    break;
                }
            }
            return  index;
        }

        static void Main()
        {
            int[] array = { 101, 3, 2, 2, 3, 4, 5, 6, 6, 7, 8, 18, 28, 32, 34, 35, 62, 73, 72 };
            foreach (var item in array)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
            int index=IndexOfFirstBigger(array);
            if (index == -1)
            {
                Console.WriteLine("No such element! {0}", index);
            }
            else
            {
                Console.WriteLine("First bigger than neighbors is at position {0} -> {1}", index, array[index]);
            }

        }
    }

