/* Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.*/
using System;

class CheckThirdBit0or1
{
    static void Main()
    {
        Console.Write("Enter any number: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(Convert.ToString(n,2).PadLeft(32,'0'));
        int mask = 8;
        int isThirdBit1 = n & mask;
        
        if (isThirdBit1 == mask)
        {
            Console.WriteLine("The third bit is 1");
        }
        else
        {
            Console.WriteLine("The third bit is 0");
        }
    }
}

