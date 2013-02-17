/*Write a program that can solve these tasks:
Reverses the digits of a number
Calculates the average of a sequence of integers
Solves a linear equation a * x + b = 0
		
 * Create appropriate methods.
		Provide a simple text-based menu for the user to choose which task to solve.
		Validate the input data:
The decimal number should be non-negative
The sequence should not be empty
a should not be equal to 0
*/
using System;

class SolveAnyTasks
{
    public static decimal ReverseDigit(decimal number)
    {
        decimal reversedNumber = decimal.MinValue;
        byte reminder;
        string reversed = "";
        if (number > 1)
        {
            while (number > 1)
            {
                reminder = (byte)(number % 10);
                reversed += reminder;
                number = number / 10;
            }
            reversedNumber = decimal.Parse(reversed);
        }
        else
        {
            reversedNumber = number;
        }

        return reversedNumber;
    }

    static double GetAverage(int[] arr)
    {
        int sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }

        return (double)sum / arr.Length;
    }

    static double CalculateEquation(int a, int b)
    {
        return (double)-b / a;
    }

    // Validate the input data
    static void InputReverseDigits()
    {
        Console.Write("Enter any number:");
        decimal a = decimal.Parse(Console.ReadLine());
        if (a < 0)
        {
            Console.WriteLine("Number a should not be equal to 0");
        }
        else
        {
            Console.WriteLine("Reversed number: {0}", ReverseDigit(a)); 
        }
    }

    static void InputAverage()
    {
        Console.WriteLine("Enter array size:");
        int size = int.Parse(Console.ReadLine());
        if (size <= 0)
        {
            Console.WriteLine("The number should be greater than 0!");
        }
        else
        {
            int[] arr = new int[size];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("GetAverage: " + GetAverage(arr));
        }
    }

    static void InputEquation()
    {
        Console.WriteLine("Enter a and b:");

        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());

        if (a != 0)
        {
            Console.WriteLine("Solve equation: {0}", CalculateEquation(a, b));
        }
        else
        { 
            Console.WriteLine("a should not be zero!");
        }
    }

    static void Main()
    {
        Console.WriteLine("0: Reverse Digits");
        Console.WriteLine("1: Get Average");
        Console.WriteLine("2: Solves a linear equation a * x + b = 0");

        int n = int.Parse(Console.ReadLine());
        switch (n)
        {
            case 0: InputReverseDigits(); break;
            case 1: InputAverage(); break;
            case 2: InputEquation(); break;
            default: Console.WriteLine("Not Selected! Try Again!"); break;
        }
    }
}

