/* Write an expression that calculates rectangle’s area by given width and height.
*/
using System;

    class Program
    {
        static void Main()
        {
            Console.Write("Enter width for the rectangle ");
            int width = int.Parse(Console.ReadLine());
            Console.Write("Enter height for the rectangle ");
            int height = int.Parse(Console.ReadLine());
            int area = width*height;
            Console.WriteLine("The rectangle's area is {0}!",area);
        }
    }

