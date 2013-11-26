/*Write a program that reads an integer number n
 * from the console and prints all the numbers in the interval [1..n],
 * each on a single line. 
 */ 
using System;

    class PrintNumber1toN
    {
        static void Main()
        {
            Console.Write("Enter an integer number n = ");
            int n = Int32.Parse(Console.ReadLine());
            int inc=1;
            while (inc <= n)
            {
                Console.WriteLine("{0,5}",inc);
                inc++;
            }
        }
    }

