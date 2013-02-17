/*Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. 
 * Display them in the standard date format for Canada.
*/
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


    class ExtractDates
    {
        static void Main()
        {
            string text = "I was born at 14.06.1980. My sister was born at 9.2.2012. In 5/1999 I graduated my high school. The law says (see section 7.3.12) that we are allowed to do this (section 7.4.2.9).";
            Console.WriteLine(text);
            Match match = Regex.Match(text, @"\b([0]?[1-9]|[1|2][0-9]|[3][0|1])[./-]([0]?[1-9]|[1][0-2])[./-]([0-9]{4})\b");
            Console.WriteLine("The dates in the text is:");
            while (match.Success)
            {
                //Console.WriteLine(match.ToString());
                
                try
                {
                    DateTime date = DateTime.ParseExact(match.ToString(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    Console.WriteLine(date.ToString(CultureInfo.GetCultureInfo("en-CA").DateTimeFormat.ShortDatePattern));
                }
                catch (FormatException)
                {
                    
                }

                match = match.NextMatch();
            }
        }
    }

