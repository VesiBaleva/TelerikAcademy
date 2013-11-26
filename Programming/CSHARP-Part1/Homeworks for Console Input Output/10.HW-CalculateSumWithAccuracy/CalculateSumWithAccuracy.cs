/*Write a program to calculate the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...
 */ 
using System;

class CalculateSumWithAccuracy
{
    static void Main()
    {
        double oldSum=0.0;
        double sum=1.0;
        int i = 1;
        while (Math.Abs(sum-oldSum) > 0.001)
        {
            oldSum = sum;
            i++;
            if (i % 2 == 0)
            {
                sum += 1.0 / i;
            }
            else
            {
                sum -= 1.0 / i;
            }            
        }
        Console.WriteLine("Print sum : {0:F3} and last member is {1}",sum, i);
    }
}

