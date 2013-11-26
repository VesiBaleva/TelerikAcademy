/* Write an expression that extracts from a given integer i
 * the value of a given bit number b. Example: i=5; b=2  value=1.*/
using System;

class ExtractBitNumber
{
    static void Main()
    {
        Console.Write("Enter an integer number i = ");
        int i = int.Parse(Console.ReadLine());
        Console.WriteLine(Convert.ToString(i,2).PadLeft(32,'0'));
        Console.Write("Enter bit number b from 0 to 31 = ");
        int b = int.Parse(Console.ReadLine());
        if (b >= 0 && b <= 31)
        {
            int mask = 1 << b;
            int iAndMask = i & mask;
            int bit = iAndMask >> b;
            Console.WriteLine("i={0}, b={1} -> value {2}",i,b,bit);
        }
        else
        {
            Console.WriteLine("Enter bit number between [0,31] !!!");
        }
    }
}

