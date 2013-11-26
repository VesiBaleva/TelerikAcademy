/* Write a program that reads 3 integer numbers from the console and prints their sum.*/
using System;

class ReadFromConsole
{
    static void Main()
    {
        Console.Write("Enter one number: ");
        int one = Int32.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        int two = Int32.Parse(Console.ReadLine());
        Console.Write("Enter three number: ");
        int three = Int32.Parse(Console.ReadLine());
        int sum = one + two + three;
        Console.WriteLine("The sum of {0} + {1} + {2} = {3}", one,two, three, sum);
    }
}

