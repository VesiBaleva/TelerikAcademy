using System;

class SumNX
    {
        static void Main()
        {
            Console.Write("Enter number n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter number x = ");
            int x = int.Parse(Console.ReadLine());
            decimal sum = 1;
            decimal factorial=1;
            decimal power=1;
            for (int i=1;i<=n;i++)
            {
                factorial*=i;
                power*=x;
                sum += factorial / power;
            }
            Console.WriteLine("The sum S=1+1!/x+2!/x2+....+n!/xn is "+sum);
        }
    }

