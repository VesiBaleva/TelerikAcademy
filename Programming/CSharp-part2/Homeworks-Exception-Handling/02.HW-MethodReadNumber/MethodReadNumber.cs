/*Write a method ReadNumber(int start, int end) 
 * that enters an integer number in given range [start…end]. 
 * If an invalid number or non-number text is entered,
 * the method should throw an exception. Using this method write a program that enters 10 numbers:
			a1, a2, … a10, such that 1 < a1 < … < a10 < 100*/
using System;


    class MethodReadNumber
    {
        static int ReadNumber(int start, int end)
        {
            int n = int.MinValue;
            for (int i = 0; i < 10; i++)
            {
                n = int.Parse(Console.ReadLine());
                if (!(start < n && n < end)) throw new System.ArgumentOutOfRangeException();                
            }
            return n; 

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 10 numbers in range 1..100");


            try
            {
                int result = ReadNumber(1, 100);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");

            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Number is out of the diapasone!");
                
            }

        }
    }

