/* Write a boolean expression that returns if the bit at position p (counting from 0) 
 * in a given integer number v has value of 1. Example: v=5; p=1  false.
*/
using System;

class HasValue1
{
    static void Main()
    {
        Console.Write("Enter any integer value: ");
        int v = int.Parse(Console.ReadLine());
        Console.WriteLine(Convert.ToString(v,2).PadLeft(32,'0'));
        Console.Write("Enter position from 0 to 31:" );
        int p = int.Parse(Console.ReadLine());
        if (p >= 0 && p <= 31)
        {
            bool hasValue1 = true;
            int mask = 1 << p;
            int vAndmask = v & mask;
            int bit = vAndmask >> p;
            hasValue1 = (bit == 1);
            Console.WriteLine("v={0}; p={1} -> {2}", v, p, hasValue1);
        }
        else
        {
            Console.WriteLine("Enter position from 0 to 31");
        }
    }
}

