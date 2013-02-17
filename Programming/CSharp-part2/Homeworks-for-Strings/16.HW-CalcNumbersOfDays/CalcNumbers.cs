/*Write a program that reads two dates in the format: day.month.year and calculates the number of days between them. Example:
Enter the first date: 27.02.2006
Enter the second date: 3.03.2004
Distance: 4 days
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class CalcNumbers

    {
        static void Main()
        {
            Console.Write("Enter first date in format day.month.year: ");
            string text = Console.ReadLine();
            string format = "d.MM.yyyy";
            DateTime first = DateTime.ParseExact(text,format,CultureInfo.InvariantCulture);
            Console.Write("Enter second date in format day.month.year: ");
            text = Console.ReadLine();
            DateTime second = DateTime.ParseExact(text, format, CultureInfo.InvariantCulture);
            Console.WriteLine("{0} days",(second-first).Days);
        }
    }

