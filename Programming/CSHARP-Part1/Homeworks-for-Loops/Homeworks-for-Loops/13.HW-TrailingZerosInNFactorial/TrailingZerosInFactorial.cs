using System;
using System.Numerics;

    class TrailingZerosInFactorial
    {
        static void Main()
        {
            Console.Write ("Enter number N = ");
            int number = int.Parse(Console.ReadLine());
            BigInteger result=0;
            Console.WriteLine();
            for (int i = 5; i <= number; i *= 5)
            {
                result += number / i;
            }
            Console.WriteLine("The trailing zeros in {0} is {1} ",number,result);
        } 
    }

