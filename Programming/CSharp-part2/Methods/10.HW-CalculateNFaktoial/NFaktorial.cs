/* Write a program to calculate n! for each n in the range [1..100]. 
 * Hint: Implement first a method that multiplies a number represented 
 * as array of digits by given integer number.*/
using System;
using System.Collections.Generic;

    class NFaktorial
    {
        // Print reversed
        static void PrintNumber(List<byte> arr)
        {
            for (int i = arr.Count-1; i >= 0; i--) Console.Write(arr[i]); 
            Console.WriteLine();
        }

        static List<byte> Add(List<byte> arr1, List<byte> arr2)
        {
            int i = 0, carry = 0;
            List<byte> result = new List<byte>();
            byte currentDigit1 = 0;
            byte currentDigit2 = 0;
            int currentTotal = 0;
            for (i = 0; i < Math.Max(arr1.Count, arr2.Count); i++)
            {
                if (i >= arr1.Count)
                {
                    currentDigit1 = 0;
                }
                else
                {
                    currentDigit1 = arr1[i];
                }
                if (i >= arr2.Count)
                {
                    currentDigit2 = 0;
                }
                else
                {
                    currentDigit2 = arr2[i];
                }
                currentTotal = (byte)(currentDigit1 + currentDigit2 + carry);
                carry = currentTotal / 10;
                currentTotal %= 10;
                result.Add((byte)currentTotal);
            }
            if (carry == 1)
            {
                result.Add(1);
            }
            return result;
        }

        static List<byte> Multiply(List<byte> x, int y)
        {
            List<byte> result = new List<byte>();
            
            for (int i = 0; i < y; i++)
            {
                result = Add(result, x);
            }
            return result;
        }

        static void Main()
        {
            List<byte> factorial =  new List<byte>();
            factorial.Add(1);

            for (int i = 1; i <= 100; i++)
            {
                factorial = Multiply(factorial, i);
                PrintNumber(factorial);
            }
        }
    }

