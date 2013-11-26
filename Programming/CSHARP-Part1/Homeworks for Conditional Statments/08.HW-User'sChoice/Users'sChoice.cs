/* Write a program that, depending on the user's choice inputs int, double or string variable.
 * If the variable is integer or double, increases it with 1.
 * If the variable is string, appends "*" at its end. 
 * The program must show the value of that variable as a console output. Use switch statement.
*/
using System;

class UserChoice
{
    static void Main()
    {
        Console.WriteLine("User's choice:");
        Console.WriteLine("1 - for input integer");
        Console.WriteLine("2 - for input double");
        Console.WriteLine("3 - for input string");
        sbyte choice = sbyte.Parse(Console.ReadLine());
        Console.Clear();
        switch (choice)
        {
            case 1:
                Console.WriteLine("You enter integer variable!");
                int intVar = int.Parse(Console.ReadLine());
                intVar++;
                Console.WriteLine("Your number become -> {0}",intVar);
                break;
            case 2:
                Console.WriteLine("You enter double variable!");
                double doubleVar = double.Parse(Console.ReadLine());
                doubleVar++;
                Console.WriteLine("Your number become -> {0}",doubleVar);
                break;
            case 3:
                Console.WriteLine("You enter string variable!");
                string str = Console.ReadLine();
                str = str + "*";
                Console.WriteLine("Your string become -> {0}",str);
                break;
            default:
                Console.WriteLine("Your choice is out of the range!");
                break;
        }

    }
}

