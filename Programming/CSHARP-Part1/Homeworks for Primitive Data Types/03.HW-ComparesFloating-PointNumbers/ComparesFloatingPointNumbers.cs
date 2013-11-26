/*Write a program that safely compares floating-point numbers with precision of 0.000001.
 * Examples:(5.3 ; 6.01)  false;  (5.00000001 ; 5.00000003)  true
*/
using System;
class ComparesFloatingPointNumbers
{
    static void Main()
    {
        double varDouble1 = 5.00000001d;
        double varDouble2 = 5.00000003d;
        //compares with precision 0.000001
        bool isEqualWithPrecision = (Math.Abs(varDouble1 - varDouble2) < 0.000001d);
        Console.WriteLine("Are two variables ({0} and {1})equal each other? {2}",varDouble1,varDouble2,isEqualWithPrecision);
        varDouble1 = 5.3d;
        varDouble2 = 6.01d;
        //compares with precision 0.000001
        isEqualWithPrecision = (Math.Abs(varDouble1 - varDouble2) < 0.000001d);
        Console.WriteLine("Are {1} and {2} equal? {0}", isEqualWithPrecision, varDouble1, varDouble2);
        
    }
}

