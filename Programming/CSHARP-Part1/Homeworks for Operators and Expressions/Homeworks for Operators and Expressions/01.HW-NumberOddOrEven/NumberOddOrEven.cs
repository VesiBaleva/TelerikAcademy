/* Write an expression that checks if given integer is odd or even.*/
using System;

class NumberOddOrEven
{
    static void Main()
    {
        Console.Write("Enter your number: ");
        int number = int.Parse(Console.ReadLine());
            if (number % 2 == 0)
            {
                Console.WriteLine("You entered an odd value {0}", number);
            }
            else
            {
                Console.WriteLine("You entered an even value {0}", number);
            }      
        
    }
}

