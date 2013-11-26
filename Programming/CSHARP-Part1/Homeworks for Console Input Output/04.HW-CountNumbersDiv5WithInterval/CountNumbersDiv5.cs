/*
 * Write a program that reads two positive integer numbers
 * and prints how many numbers p exist between them such
 * that the reminder of the division by 5 is 0 (inclusive). Example: p(17,25) = 2.
 */
using System;
    class CountNumbersDiv5
    {
        static void Main()
        {
            Console.Write("Enter number a: ");
            int numberA=0;
            bool isNumberA = int.TryParse(Console.ReadLine(), out numberA);
            int numberB = 0;
            Console.Write("Enter number b: ");
            bool isNumberB = int.TryParse(Console.ReadLine(), out numberB);
            if (isNumberA && isNumberB)
            {
                int count = 0, num = 1;
                byte k = 0;
                if (numberA <= numberB && numberA > 0 && numberB > 0)
                {
                    while ((numberA + k) % 5 != 0)
                    {
                        k++;
                    };
                    if ((numberA + k) > numberB) num = 0;
                    count = (numberB - (numberA + k)) / 5 + num;
                    Console.WriteLine("Your count numbers whos divited of 5 without remainders is: {0,5}", count);
                }
                else
                {
                    Console.WriteLine("Enter valid interval with positive lower and upper limits!!!");
                }
            }
            else
            {
                Console.WriteLine("Enter valid numbers without any simbols!!!");
            }
        }
    }

