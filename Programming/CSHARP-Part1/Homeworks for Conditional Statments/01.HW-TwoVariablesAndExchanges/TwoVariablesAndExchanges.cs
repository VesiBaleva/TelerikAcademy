/* Write an if statement that examines two integer variables and
 * exchanges their values if the first one is greater than the second one.*/
using System;
class TwoVariablesAndExchanges
{
    static void Main(string[] args)
    {
        Console.Write("Enter first value: ");
        int first = int.Parse(Console.ReadLine());
        Console.Write("Enter second value: ");
        int second = int.Parse(Console.ReadLine());
        if (first > second)
        {
            //exchanging value in case when first value is greater second with third  temporary variable
            int temp = first;
            first = second;
            second = temp;
        }
        Console.WriteLine("First -> {0}, second -> {1}", first,second);
    }
}

