/* program that prints the entire ASCII table of characters on the console */
using System;

class ASCIIcodeTable
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.GetEncoding("Windows-1252");
        Console.WriteLine("DEC\tOCT\tHEX\tBIN\tSymbol");
        for (int i = 0; i <= byte.MaxValue; i++)
        {
            Console.WriteLine("{0}\t{1}\t{2:x}\t{3}\t{4}", i, Convert.ToString(i, 8), i, Convert.ToString(i, 2).PadLeft(8,'0'), (char)i);
        }
       /* for (int i = 0; i <= byte.MaxValue; i+=8)
        {
            for (int j = 0; j < 8;j++ )  Console.Write("{0}\t{1} ", i+j, (char)(i+j));
            Console.WriteLine();
        } */
    }
}

