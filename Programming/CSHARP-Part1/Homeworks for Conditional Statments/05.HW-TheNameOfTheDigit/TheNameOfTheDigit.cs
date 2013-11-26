/* Write program that asks for a digit and depending on the input shows the name of that digit (in English) 
 * using a switch statement.
*/
using System;

class TheNameOfTheDigit
{
    static void Main()
    {
        Console.Write("Enter your digit: ");
        string nameDigit;
        byte digit = 0;
        bool parseSuccess = byte.TryParse(Console.ReadLine(),out digit);
        if (parseSuccess)
        {            
            switch (digit)
            {
                case 0:
                    nameDigit = "zero";
                    break;
                case 1:
                    nameDigit = "one";
                    break;
                case 2:
                    nameDigit = "two";
                    break;
                case 3:
                    nameDigit = "three";
                    break;
                case 4:
                    nameDigit = "four";
                    break;
                case 5:
                    nameDigit = "five";
                    break;
                case 6:
                    nameDigit = "six";
                    break;
                case 7:
                    nameDigit = "seven";
                    break;
                case 8:
                    nameDigit = "eight";
                    break;
                case 9:
                    nameDigit = "nine";
                    break;
                default:
                    nameDigit = "not digit";
                    Console.WriteLine("This is number, not digit!");
                    break;
            }
            Console.WriteLine("This digit is {0}!",nameDigit);
        }
        else
        {
            Console.WriteLine("Enter only one positive digit (0 to 9)!");
        }
    }
}

