using System;
class Trapezoid
{
    static void Main()
    {
        byte n = byte.Parse(Console.ReadLine());
        byte top = n;
        byte bottom = (byte) (2 * n);
        byte height = (byte)(n + 1);
        for (int i = 1, k=top+1; i <= height; i++, k--)
        {
            for (int j = 1; j <= bottom; j++)
            {
                if (j == k)
                {
                    Console.Write("*");
                }
                else if (i == 1 && j > k)
                {
                    Console.Write("*");
                }
                else if (i == height)
                {
                    Console.Write("*");
                }
                else if (j == bottom)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            }
            Console.WriteLine();
        }
    }
}

