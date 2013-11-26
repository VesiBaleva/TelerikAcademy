/* Write a program that reads the radius r of a circle and prints its perimeter and area.*/
using System;

class PerimeterAndArea
{
    static void Main()
    {
        Console.Write("Enter radius r = ");
        float r = float.Parse(Console.ReadLine());
        float p = (float) (2 * Math.PI * r);
        float s = (float) (Math.PI * r * r);
        Console.WriteLine("The perimeter is {0:f} and area is {1:f} ",p,s);
        
    }
}

