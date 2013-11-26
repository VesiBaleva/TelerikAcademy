/*Write a program that reads the coefficients a, b and c
 * of a quadratic equation ax2+bx+c=0 and solves it (prints its real roots).
*/ 
using System;

class QuadraticEquation
{
    static void Main()
    {
        Console.Write("Enter coefficient a: ");
        double a = double.Parse(Console.ReadLine());
        if (a != 0)
        {
            Console.Write("Enter coefficient b: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Enter coefficient c: ");
            double c = double.Parse(Console.ReadLine());
            double d = (b * b) - (4 * a * c);
            double x = 0;
            double x1 = 0, x2 = 0;
            if (d < 0) Console.WriteLine("The quadratic equation doesn't have real roots !!!");
            if (d == 0)
            {
                x = -b / (2 * a);
                Console.WriteLine("The quadratic equation have one real root !!! -> {0}", x);
            }
            if (d > 0)
            {
                x1 = (-b + Math.Sqrt(d)) / (2 * a);
                x2 = (-b - Math.Sqrt(d)) / (2 * a);
                Console.WriteLine("The quadratic equation have two real roots witch is {0:F3} and {1:F3} !!! ", x1, x2);
            }
        }
        else Console.WriteLine("Enter another value of a because a doesn't have equal to 0");

    }
}

