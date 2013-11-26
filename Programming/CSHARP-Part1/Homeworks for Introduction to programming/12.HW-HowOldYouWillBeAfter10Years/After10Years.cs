/* Write a program to read your age from the console and print how old you will be after 10 years.
*/
using System;

class After10Years
{
    static void Main()
    {
        Console.Write("How old are you? ");
        byte age = byte.Parse(Console.ReadLine());
        DateTime AgeAfterYears = new DateTime(age,1,1);
        AgeAfterYears = AgeAfterYears.AddYears(10);
        Console.WriteLine("After ten years you will be {0} years old!",AgeAfterYears.Year);
    }
}

