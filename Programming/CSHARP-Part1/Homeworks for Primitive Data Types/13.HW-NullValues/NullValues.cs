/* Create a program that assigns null values to an integer and to double variables.
 * Try to print them on the console, try to add some values or the null literal to them and see the result.*/
using System;

class NullValues
{
    static void Main()
    {
        //assign null value to varInteger
        int? varInteger = null;
        //assign 0 to varInt
        int varInt = 0;
        Console.WriteLine("This is null {0} value of an integer variable and its .hasValue is {1}",varInteger,varInteger.HasValue);
        //assign null value to double variable;
        double? varDouble = null;
        Console.WriteLine("This is null {0} value of a double variable and its .hasValue is {1}", varDouble, varDouble.HasValue);
        varInteger = 5;
        varDouble = 5.5;
        Console.WriteLine("{0} and {1}",varInteger,varDouble);
        varInteger = null;
        //print empty space when simple print varInteger
        Console.WriteLine("{0} and {1}",varInteger,varDouble);
        //print null value as a 0 when use GetValueOrDefault()
        Console.WriteLine("{0} and {1}", varInteger.GetValueOrDefault(), varDouble.GetValueOrDefault());
        //if has value, not null assign a value to varInt and print varInt
        if (varInteger.HasValue == true)
        {
            varInt = varInteger.Value;
            Console.WriteLine(varInt);
        }
        //assign an integer value and hasValue become true.
        varInteger =10;
        if (varInteger.HasValue == true)
        {
            varInt = varInteger.Value;
            Console.WriteLine(varInt);
        }
    }
}

