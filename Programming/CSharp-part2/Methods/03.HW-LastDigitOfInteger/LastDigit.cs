/*Write a method that returns the last digit of given integer as an English word. 
 * Examples: 512  "two", 1024  "four", 12309  "nine".
*/
using System;

    class LastDigit
    {
        static string LastDigitOfInt(int number)
        {
            string lastDigitName = "";
            int lastDigit = int.MinValue;

            lastDigit = Math.Abs(number) % 10;
            switch (lastDigit)
            {
                case 0: lastDigitName = "zero"; break;
                case 1: lastDigitName = "one"; break;
                case 2: lastDigitName = "two"; break;
                case 3: lastDigitName = "three"; break;
                case 4: lastDigitName = "four"; break;
                case 5: lastDigitName = "five"; break;
                case 6: lastDigitName = "six"; break;
                case 7: lastDigitName = "seven"; break;
                case 8: lastDigitName = "eight"; break;
                case 9: lastDigitName = "nine"; break;
            }
            return lastDigitName;
        }

        static void Main()
        {
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("{0} -> {1}",number,LastDigitOfInt(number));
        }
    }

