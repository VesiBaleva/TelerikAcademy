/* Declare  two integer variables and assign them with 5 and 10 and after that exchange their values.
*/
using System;

class ExchangeVariables
{
    static void Main()
    {
        int one = 5;
        int two = 10;
        Console.WriteLine("One: {0}\t Two: {1}",one,two);
        int temp = 0;
        temp = one;
        one = two;
        two = temp;
        Console.WriteLine("One: {0}\t Two: {1}", one, two);

    }
}

