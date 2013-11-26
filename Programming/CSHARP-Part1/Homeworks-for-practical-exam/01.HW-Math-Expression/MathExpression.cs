using System;
using System.Globalization;
using System.Threading;
class MathExpression
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
        double n=double.Parse(Console.ReadLine());
        double m=double.Parse(Console.ReadLine());
        double p=double.Parse(Console.ReadLine());
        if (m != 0 && p != 0)
        {
            double numerator = n * n + (1 / (m * p) + 1337);
            double denominator = n - (128.523123123 * p);
            int sinM = (int)(m % 180);
            double expression = 0;
            if (denominator != 0)
                expression = (numerator / denominator) + Math.Sin((double)(sinM));
            Console.WriteLine("{0:0.000000}", expression);
        }
    }
}

