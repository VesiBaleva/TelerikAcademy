/* Write a program that finds the biggest of three integers using nested if statements.*/

using System;

class BiggestOfThree
{
    static void Main()
    {
        Console.WriteLine("Enter three integer value /on a separate line/!");
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        int biggest=0;
        if (a > b)
        {
            if (a > c)
            {
                biggest = a;
            } else
            {
                biggest = c;
            }
        }
        else if (b > c)
        {
            biggest = b;
        }
        else
        {
            biggest = c;
        }
        Console.WriteLine("The biggest of three integer value is {0}",biggest);
    }
}

