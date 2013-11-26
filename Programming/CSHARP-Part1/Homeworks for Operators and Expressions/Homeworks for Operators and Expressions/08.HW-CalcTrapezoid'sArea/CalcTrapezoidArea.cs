/* Write an expression that calculates trapezoid's area by given sides a and b and height h.*/
using System;

class CalcTrapezoidArea
{
    static void Main()
    {
        Console.Write("Enter the length of the one base: ");
        double oneBase = double.Parse(Console.ReadLine());
        Console.Write("Enter the length of the other base: ");
        double otherBase = double.Parse(Console.ReadLine());
        Console.Write("Enter the length of the height: ");
        double height = double.Parse(Console.ReadLine());
        if (oneBase>0 && otherBase>0 && height>0)
            {
                double averageBases=(oneBase+otherBase)/2;
                double trapArea = averageBases * height;
                Console.WriteLine("The Trapezoid's area is {0}",trapArea);
            }
            else
            {
                Console.WriteLine("Enter positive values for the three lenghts !!!");
            }
    }
}

