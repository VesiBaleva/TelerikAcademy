/* Write a program, that reads from the console an array of N integers and an integer K,
 * sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K.*/
using System;

    class LargestNumber
    {
        static void Main()
        {
            Console.WriteLine("Enter number for length of the array: ");
            int length = int.Parse(Console.ReadLine());
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
            {
                Console.Write("{0} item -> ",i);
                array[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(array);
            for (int i = 0; i < length; i++)
            {
                Console.Write("{0} ",array[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Enter integer K: ");
            int k = int.Parse(Console.ReadLine());
            int index = Array.BinarySearch(array, k);
            
            if (index < -1)
            {
                Console.WriteLine("The largest number in the array which is < {0} -> {1}", k, array[~index - 1]);
            }
            else if (~index == 0)
            {
                Console.WriteLine("Not found!");
            }
            else
            {
                Console.WriteLine("The largest number in the array which is equal to {0} -> {1}", k, array[index]);
            }

        }
    }

