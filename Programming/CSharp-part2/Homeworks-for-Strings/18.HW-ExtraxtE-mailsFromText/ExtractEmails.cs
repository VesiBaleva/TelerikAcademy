/*Write a program for extracting all email addresses from given text.
 * All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


    class ExtractEmails
    {
        static void Main()
        {
            string text = "Please contact us by phone (+359 2 222 2222) or by email at example@abv.bg or at baj.ivan@yahoo.co.uk. This is not email test@test. This also @telerik.com. Neither this: a@a.b.";
            Console.WriteLine(text);
            foreach (var item in Regex.Matches(text, @"[\w.]{2,20}@[\w]{2,20}[.]{1}[\w.]{2,6}"))
            {
                Console.WriteLine(item);
            }
        }
    }

