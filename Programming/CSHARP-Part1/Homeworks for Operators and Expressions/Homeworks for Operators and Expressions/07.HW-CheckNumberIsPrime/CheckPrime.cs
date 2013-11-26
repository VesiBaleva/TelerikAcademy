/* Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.*/
using System;

class CheckPrime
{
    static void Main()
    {
        Console.Write("Please, enter positive number from 1 to 100: ");
        int number = int.Parse(Console.ReadLine());
        bool prime = true;
        if (number <= 100 && number > 0)
        {
            
            int maxDivider = (int) Math.Sqrt(number);
            for (int i = 2; i <= maxDivider; i++)
            {
                if (number % i == 0)
                {
                    prime = false;
                }
            }
        }
        else
        {
            Console.WriteLine("Your entered number is out of range !!!");
        }
        Console.WriteLine("Is your entered number prime? {0}",prime);
        Console.WriteLine(prime ? number + " is prime " : number + " is not prime!");
    }
}

