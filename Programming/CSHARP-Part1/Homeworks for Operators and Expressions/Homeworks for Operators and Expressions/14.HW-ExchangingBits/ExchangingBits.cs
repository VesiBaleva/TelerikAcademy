/* Write a program that exchanges bits {p, p+1, …, p+k-1) with bits 
 * {q, q+1, …, q+k-1} of given 32-bit unsigned integer.
  */
using System;

    class ExchangingBits
    {
         static void Main()
        {
            uint number = 0;
            byte p = 0;
            byte q = 0;
            byte k = 0;
            try
            {
                Console.Write("Enter positive integer number or very big number: ");
                number = uint.Parse(Console.ReadLine());
            }
            catch (System.OverflowException)
            {
                Console.WriteLine("\nYou enter negative number! \nAt this moment your number become 0 or restart a program !!!");
            }
            Console.Write("\nEnter position -> p = ");
            p = byte.Parse(Console.ReadLine());
            Console.Write("\nEnter position -> q = ");
            q = byte.Parse(Console.ReadLine());
            do
            {
                Console.Write("\nEnter (k+q<32) -> k = ");
                k = byte.Parse(Console.ReadLine());
            } while ((k + q) > 32 || (k + p) > 32);
            //replace p bits with bits at positions and replace q bits with bits at positions 
            p--;
            q--;
            byte bitP=0;
            byte bitQ=0;
            byte temp=0;
            // binary representation of entered number
            Console.WriteLine("\n"+Convert.ToString(number, 2).PadLeft(32, '0')+"   ---> "+number);
            for (byte i = 0; i < k; i++, p++, q++)               //k is count of itteration starts form p to p+k-1 
            {                                                   //also starts from q to q+k-1
                // mask 1 at position p
                int mask = 1 << p;
                uint numberAndMask = (uint)(number & mask);
                // resieve bit at position p
                bitP = (byte)(numberAndMask >> p);
                //mask 1 at position q
                mask = 1 << q;
                numberAndMask = (uint)(number & mask);
                //resieve bit at position q
                bitQ = (byte)(numberAndMask >> q);
                //swipe bits
                temp=bitP;
                bitP=bitQ;
                bitQ=temp;
                //check bit at position p with bit at position q
                if (bitP == 0)
                {
                    int maskNegaive = ~(1 << p);
                    number = (uint) (number & maskNegaive);
                }
                if (bitP == 1)
                {
                    mask = 1 << p;
                    number = (uint)(number | mask);
                }
                //check bit at position q with bit at position p
                if (bitQ == 0)
                {
                    int maskNegaive = ~(1 << q);
                    number = (uint) (number & maskNegaive);
                }
                if (bitQ == 1)
                {
                    mask = 1 << q;
                    number = (uint)(number | mask);
                }
              
            }
             //binary representation of number with exchanging bits
             Console.Write("\n"+Convert.ToString(number, 2).PadLeft(32, '0')+"   ---> ");
             Console.WriteLine(number);
        }   
     
    }

