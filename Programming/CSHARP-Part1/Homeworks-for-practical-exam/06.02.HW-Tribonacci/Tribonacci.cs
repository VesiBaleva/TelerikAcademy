using System;
using System.Numerics;
class Tribonacci
{
    static void Main()
    {
        BigInteger t1 = BigInteger.Parse(Console.ReadLine());
        BigInteger t2 = BigInteger.Parse(Console.ReadLine());
        BigInteger t3 = BigInteger.Parse(Console.ReadLine());
        ushort n = ushort.Parse(Console.ReadLine());        
        BigInteger tN = 0;
        if (n == 1) Console.WriteLine(t1);
        if (n == 2) Console.WriteLine(t2);
        if (n == 3) Console.WriteLine(t3);
        if (n >= 4)
        {
            for (int i = 4; i <= n; i++)
            {
                tN = t1 + t2 + t3;
                if (i == n) break;
                t1 = t2;
                t2 = t3;
                t3 = tN;
            }
            Console.WriteLine(tN);
        }
    }
}

