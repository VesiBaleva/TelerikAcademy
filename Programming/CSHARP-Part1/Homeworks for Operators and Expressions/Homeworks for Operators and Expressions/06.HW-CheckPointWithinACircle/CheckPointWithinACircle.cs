/* Write an expression that checks if given point (x,  y) is within a circle K(O, 5).*/
using System;

    class CheckPointWithinACircle
    {
        static void Main()
        {
            Console.Write("Enter x of your point: ");
            int x = int.Parse(Console.ReadLine());
            Console.Write("Enter y of your point: ");
            int y = int.Parse(Console.ReadLine());
            int r = 5;
            int distance=x*x+y*y;
            bool isPointWithin = (distance < (r * r));
            Console.WriteLine("The point is in the circle - {0}",isPointWithin);
        }
    }

