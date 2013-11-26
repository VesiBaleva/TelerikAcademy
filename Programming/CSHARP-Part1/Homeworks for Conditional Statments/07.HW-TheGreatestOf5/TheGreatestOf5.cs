/* Write a program that finds the greatest of given 5 variables.*/
using System;

class TheGreatestOf5
{
    static void Main()
    {
        Console.WriteLine("Enter 5 values on separate line:");
        decimal a = decimal.Parse(Console.ReadLine());
        decimal b = decimal.Parse(Console.ReadLine());
        decimal c = decimal.Parse(Console.ReadLine());
        decimal d = decimal.Parse(Console.ReadLine());
        decimal e = decimal.Parse(Console.ReadLine());
        decimal max = 0;
        max = a;
        if (max<=b)
        {
            max=b;
        }
        if (max<=c)
        {
            max=c;
        }
        if (max<=d)
        {
            max=d;
        }
        if (max <= e)
        {
            max = e;
        }
        Console.WriteLine("The greatest of given five values is {0}", max);
    }
}

