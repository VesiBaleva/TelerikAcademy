using System;
using System.Numerics;
class CatalanNumber
{
    static void Main()
    {
        int n = 0;
        do
        {
            Console.Write("Enter your number N (N>=0) = ");
            n = int.Parse(Console.ReadLine());
        } while (n<0);
        BigInteger chislitel = 1;
        BigInteger znamenatel1 = 1;
        BigInteger result;
        
        //Zadachata moje da se svede do presmyatane na chislitel kato proizvedenie na chislata ot n+2 do 2*n
        //znamenatelya da se predstavi kato n!
        for (int i = (2 * n); i > (n + 1); i--)
        {
            chislitel *= i;
        }
        for (int i = n; i >= 1; i--)
        {
            znamenatel1 *= i;
        }
        result = chislitel / znamenatel1;
        Console.WriteLine(result);
    }

}

