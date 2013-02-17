/*Write a method that checks if the element at given position in given array of integers
 * is bigger than its two neighbors (when such exist).
*/
using System;
  class TwoNeighbors
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

        static void Main(string[] args)
        {
            int[] array = { 1, 3, 5, 2, -5, 3 - 1, 1, 1, 2, 1, 5, 8, 1, 10, 2, 2, 3, 4 };
            foreach (var item in array)
            {
                Console.Write("{0} ", item);
            }

            Console.Write("Enter a position of the element to check is bigger than his two neighbors: ");
            int position = int.Parse(Console.ReadLine());
            if (position>=0 && position<=array.Length)
            {
                Console.WriteLine("The number in position {0} is {1} and is bigger than two neighbors -> {2}", position, array[position], CheckThanNeighbors(array, position));
            }
            else
            {
                Console.WriteLine("Position {0} is not in a range of the array!",position);
            }
            Console.WriteLine();
        }
    }

