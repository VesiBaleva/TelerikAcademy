/* Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732  true.*/
using System;

    class CheckThirdDigitIs7
    {
        static void Main()
        {
            Console.Write("Enter any number: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("Will check its third digit is 7...");
            number = Math.Abs(number);
            int numberDiv100 = number / 100;
            int numberMod10 = numberDiv100 % 10;
            bool isThirdDigit7 = true;
            if (numberMod10 == 7)
            {
                Console.WriteLine("The third digit of {0} from right-to-left is True!", number);
            }
            else
            {
                Console.WriteLine("The third digit of {0} from right-to-left is False!", number);
                isThirdDigit7 = false;
            }
            Console.WriteLine("{0} -> {1}",number, isThirdDigit7);
        }
    }

