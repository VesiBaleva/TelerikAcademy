/* Declare two string variables and assign them with “Hello” and “World”. 
 * Declare an object variable and assign it with the concatenation of the first two variables (mind adding an interval).
 * Declare a third string variable and initialize it with the value of the object variable
 * (you should perform type casting). */
using System;
class AssignStringWithObject
{
    static void Main()
    {
        string first = "Hello";
        string second = "World";
        object concatenation = first + " " + second;
        //display object value
        Console.WriteLine(concatenation);
        string third = (string) concatenation;
        //display after cast object to string
        Console.WriteLine(third);
    }
}

