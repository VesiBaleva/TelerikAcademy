﻿/* Which of the following values can be assigned to a variable of type float
 * and which to a variable of type double: 34.567839023, 12.345, 8923.1234857, 3456.091?
*/
using System;

class AssignFloatDouble
{
    static void Main()
    {
        double first = 34.567839023;
        float second = 12.345f;
        double third = 8923.1234857;
        float fourth = 3456.091f;
        Console.WriteLine("{0} | {1} | {2} | {3}",first,second,third,fourth);
    }
}
