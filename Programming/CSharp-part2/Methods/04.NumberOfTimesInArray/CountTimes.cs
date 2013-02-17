/* Write a method that counts how many times given number appears in given array. 
 * Write a test program to check if the method is working correctly.
*/
using System;

    class CountTimes
    {
        public static int CountNumberAppearans(int[] array,int number)
        {
            int count = 0;
            
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number) count++;
            }
            return count;
        }
        static void Main()
        {
            int[] array = { 1, 3, 5, 2, -5, 3 - 1, 1, 1, 2, 1, 5, 8, 1, 10, 2, 2, 3, 4 };
            foreach (var item in array)
            {
                Console.Write("{0} ",item);                
            }
            Console.Write("Enter a number from this array: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Your number {0} appears {1} times in this array.",number,CountNumberAppearans(array,number));

        }
    }

