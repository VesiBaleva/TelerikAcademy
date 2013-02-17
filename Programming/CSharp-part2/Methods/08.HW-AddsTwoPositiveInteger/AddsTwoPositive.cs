/*Write a method that adds two positive integer numbers represented as arrays of digits
 * (each array element arr[i] contains a digit; the last digit is kept in arr[0]).
 * Each of the numbers that will be added could have up to 10 000 digits.
*/

using System;
using System.Collections.Generic;

    class AddsTwoPositive
    {
        static void PrintNumber(byte[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item);
            }

            Console.WriteLine();
        }

        static void PrintNumber(List<byte> result)
        {
            Console.Write("The result is -> ");
            for (int i = result.Count-1; i >= 0; i--)
            {
                Console.Write(result[i]);
            }
            Console.WriteLine();
        }


        static List<byte> Add(byte[] arr1, byte[] arr2)
        {

            Array.Reverse(arr1);
            Array.Reverse(arr2);
 
            int i = 0, carry = 0;

            List<byte> result=new List<byte>();
            
            byte currentDigit1=0;
            byte currentDigit2=0;
            int currentTotal = 0;

            for (i=0; i < Math.Max(arr1.Length,arr2.Length); i++)
            {
                if (i>=arr1.Length)
                {
                    currentDigit1=0;
                }
                else
                {
                    currentDigit1=arr1[i];
                }
                if (i>=arr2.Length)
                {
                    currentDigit2=0;
                }
                else
                {
                    currentDigit2=arr2[i];
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

        static void Main()
        {
            byte[] arr1 = { 2 };
            byte[] arr2 = {6,7,8,9,9,9,9,9,8};
            List<byte> result=new List<byte>();
            PrintNumber(arr1);
            PrintNumber(arr2);
            result = Add(arr1, arr2);
            PrintNumber(result);

        }
    }

