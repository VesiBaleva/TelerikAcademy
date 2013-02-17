/* Write a method that reverses the digits of given decimal number. Example: 256  652
 */
using System;

    class ReversesDigitOfNumber
    {
        public static decimal ReverseDigit(decimal number)
        {
            decimal reversedNumber=decimal.MinValue;
            decimal div;
            byte reminder;
            string reversed = "";
            while (number>1)
            {
                reminder =(byte)(number % 10);
                reversed += reminder;
                number=number/10;                
            }
            reversedNumber = decimal.Parse(reversed);
            return reversedNumber;
        }
        static void Main(string[] args)
        {
            Console.Write("Enter number: ");
            decimal number = decimal.Parse(Console.ReadLine());
            decimal reversedNum = ReverseDigit(number);
            Console.WriteLine("{0} -> {1}",number,reversedNum);
        }
    }

