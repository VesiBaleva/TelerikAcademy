 /* Write a program that exchanges bits 3, 4 and 5
  * with bits 24, 25 and 26 of given 32-bit unsigned integer. */

 using System;

    class ExchangeBits
    {
        static void Main()
        {
            uint number=0;
            try
            {
                Console.Write("Enter number: ");
                number = uint.Parse(Console.ReadLine());
            }
            catch (System.OverflowException)
            {
                Console.WriteLine("You entered number out of range or negative! Restart the program!");
            }
            //number in binary
            Console.WriteLine("Number -->"+Convert.ToString(number,2).PadLeft(32,'0'));
            //mask 7 (111) at position 2 
            int mask = 7;
            mask = mask << 2;
            int maskAndNumber = (int) (number & mask);
            int bitFirstGroup = maskAndNumber >> 2;
            //mask 7 (111) at position 23            
            mask = 7;
            mask = mask << 23;
            maskAndNumber = (int)(number & mask);
            int bitSecondGroup = maskAndNumber >> 23;
            //fill with 0 at positions 2, 3, 4
            mask = ~(7 << 2);
            number = (uint) (mask & number);
            // fill with 0 at positions 23, 24, 25
            mask = ~(7 << 23);
            number = (uint) (mask & number);
            // set bits at positions 2, 3, 4 with bits at position 23, 24, 25           
            number =(uint) (number | (bitSecondGroup << 2));
            // set bits at positions 23, 24, 25 with bits at position 2, 3, 4           
            number =(uint) (number | bitFirstGroup << 23);
            
            Console.WriteLine("Result -->{1} ({0})", number,Convert.ToString(number,2).PadLeft(32,'0'));
        }
    }

