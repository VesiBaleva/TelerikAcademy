/* Sort 3 real values in descending order using nested if statements.*/
using System;

class SortThreeDesc
{
    static void Main()
    {
        Console.WriteLine("Enter three real number /on a separate line/");
        float a = float.Parse(Console.ReadLine());
        float b = float.Parse(Console.ReadLine());
        float c = float.Parse(Console.ReadLine());
        float first = 0;
        float second = 0;
        float third = 0;

        if (a <= b && b <= c)
        {
            first = a;
            second = b;
            third = c;
        }
        else if (a <= c && c <= b)
        {
            first = a;
            second = c;
            third = b;
        }
        else if (c <= a && a <= b)
        {
            first = c;
            second = a;
            third = b;
        }
        else if (c <= b && b <= a)
        {
            first = c;
            second = b;
            third = a;
        }
        else if (b <= a && a <= c)
        {
            first = b;
            second = a;
            third = c;
        }
        else if (b <= c && c <= a)
        {
            first = b;
            second = c;
            third = a;
        }
        else
        {
            Console.WriteLine("The program can not order!!!");
        }
        Console.WriteLine("\nThe result is sorted: {2} {1} {0}",first,second,third);
    }
}

