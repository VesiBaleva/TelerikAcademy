using System;

class Euclid
{
    static void Main()
    {
        Console.Write("Enter one number a = ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter another number b = ");
        int b = int.Parse(Console.ReadLine());
        int temp = 0;
        int gcd = b;
        if (a > 0 && b > 0)
        {
            if (b > a)
            {
                temp = b;
                b = a;
                a = temp;
            }
            while (a % b != 0)
            {
                gcd = b;
                b = a % b;
                a = gcd;
            }
            gcd = b;
            Console.WriteLine("The GCD is " + gcd);
        }
        else
        {
            Console.WriteLine("Enter number a and b grater than 0!");
        }
    }
}

