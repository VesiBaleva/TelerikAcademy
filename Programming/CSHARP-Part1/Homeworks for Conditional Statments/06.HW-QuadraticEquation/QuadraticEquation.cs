/* Write a program that enters the coefficients a, b and c of a quadratic equation
		a*x2 + b*x + c = 0
		and calculates and prints its real roots. Note that quadratic equations may have 0, 1 or 2 real roots.
*/
using System;

class QuadraticEquation
{
    static void Main()
    {
        Console.WriteLine("Enter coefficients a, b and c of a quadratic equation.");
        Console.Write("a=");
        double a = int.Parse(Console.ReadLine());
        Console.Write("b=");
        double b = int.Parse(Console.ReadLine());
        Console.Write("c=");
        double c = int.Parse(Console.ReadLine());
        double d = b * b - 4 * a * c;
        double x1 = 0, x2 = 0;
        if (a == 0)
        {
            if (b != 0)
            {
                x1 = -c / b;
                Console.WriteLine("The equation has one root -> {0}",x1);
            }
            else
            {
                Console.WriteLine("Your quadratic equation can not be solved!");
            }
        }
        else
        {
            if (d == 0)
            {
                Console.WriteLine("The quadratic equation has one real root!");
                x1 = x2 = -b / (2 * a);
                Console.WriteLine("x1=x2={0}", x1);
            }
            if (d > 0)
            {
                Console.WriteLine("The quadratic equation has two real roots!");
                x1 = (-b + Math.Sqrt(d)) / (2 * a);
                x2 = (-b - Math.Sqrt(d)) / (2 * a);
                Console.WriteLine("x1={0} and x2={1}", x1, x2);
            }
            if (d < 0)
            {
                Console.WriteLine("The quadratic equation has not any real roots!");
            }
        }
    }
}

