/* We are given integer number n, value v (v=0 or 1) and a position p.
 * Write a sequence of operators that modifies n to hold the value v at the position p
 * from the binary representation of n.
    Example: n = 5 (00000101), p=3, v=1  13 (00001101)
	n = 5 (00000101), p=2, v=0  1 (00000001)*/

using System;

class ModifyN
{
    static void Main()
    {
        Console.Write("Enter an integer number n = ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(Convert.ToString(n,2).PadLeft(32,'0'));
        Console.Write("Enter v = 0 or 1 : ");
        int v = int.Parse(Console.ReadLine());
        Console.Write("Enter position p - [0-31] : ");
        byte p = byte.Parse(Console.ReadLine());
        int mask = 1;
        int result=n;
        if ((v==0 || v==1) && (p>=0 &&p<=31))
        {
            if (v == 0)
            {
                mask = 1 << p;
                mask = ~mask;
                result = n & mask;
            }
            if (v == 1)
            {
                mask = 1 << p;
                result = n | mask;
            }

            Console.Write("n={0}, v={1}, p={2} -> result = {3}",n,v,p,result);
            Console.WriteLine(" ({0})",Convert.ToString(result,2).PadLeft(32,'0'));
        }
        else
        {
            Console.WriteLine("Enter correct data for v and for p !!!");
        }
    }
}

