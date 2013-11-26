/* Write a program that shows the sign (+ or -) of the product of three real numbers without calculating it.
 * Use a sequence of if statements.
*/
using System;

class SignProduct
{
    static void Main()
    {
        Console.WriteLine("Enter three real numbers (on a separate line)");
        double number1 = double.Parse(Console.ReadLine());
        double number2 = double.Parse(Console.ReadLine());
        double number3 = double.Parse(Console.ReadLine());
        if (number1 == 0 || number2 == 0 || number3 == 0)
        {
            Console.WriteLine("The sign of the product is 0!");
        }
        if (number1 < 0 && number2 > 0 && number3 > 0)
        {
            Console.WriteLine("The sign of the product is -!");
        }
        if (number2 < 0 && number1 > 0 && number3 > 0)
        {
            Console.WriteLine("The sign of the product is -!");
        }
        if (number3 < 0 && number2 > 0 && number1 > 0)
        {
            Console.WriteLine("The sign of the product is -!");
        }
        if (number1 < 0 && number2 < 0 && number3 > 0)
        {
            Console.WriteLine("The sign of the product is +!");
        }
        if (number1 < 0 && number3 < 0 && number2 > 0)
        {
            Console.WriteLine("The sign of the product is +!");
        }
        if (number2 < 0 && number3 < 0 && number1 > 0)
        {
            Console.WriteLine("The sign of the product is +!");
        }
        if (number1 > 0 && number2 > 0 && number3 > 0)
        {
            Console.WriteLine("The sign of the product is +!");
        }
        if (number1 < 0 && number2 < 0 && number3 < 0)
        {
            Console.WriteLine("The sign of the product is -!");
        }
    }
}

