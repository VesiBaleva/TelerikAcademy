/* Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...*/
using System;

class Program
{
    static void Main()
    {
        int i = 2;
        int j = -3;
        for (int k = 3; k <= 7; k++)
        {
            Console.Write("{0}, {1}", i, j);
            i += 2;
            j -= 2;
            Console.Write(", ");
        }
        Console.WriteLine();
    }
}

