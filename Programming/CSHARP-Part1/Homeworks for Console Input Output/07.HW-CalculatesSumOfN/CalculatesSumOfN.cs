/*Write a program that gets a number n
 * and after that gets more n numbers
 * and calculates and prints their sum. 
 */
using System;

    class CalculatesSumOfN
    {
        static void Main()
        {
            Console.Write("Enter some numbers n (on an one row) separate by intervals : ");
            string lineNumbers = Console.ReadLine();
            string[] numbers = lineNumbers.Split(' ');
            int sum = 0;
            foreach (string number in numbers)
            {
                sum += Convert.ToInt32(number);
            }
            Console.WriteLine("The sum is : {0,10}",sum);
            
        }
    }

