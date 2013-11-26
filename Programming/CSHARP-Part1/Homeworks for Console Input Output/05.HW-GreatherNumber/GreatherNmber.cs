/*Write a program that gets two numbers from the console
 * and prints the greater of them. Don’t use if statements.
 */ 
using System;

class GreatherNmber
{
    static void Main()
    {
        byte numberX = byte.Parse(Console.ReadLine());
        byte numberY = byte.Parse(Console.ReadLine());
        Console.WriteLine("The greather number of two of them {0} and {1} is {2}",numberX,numberY, Math.Max(numberX,numberY));
    }
}

