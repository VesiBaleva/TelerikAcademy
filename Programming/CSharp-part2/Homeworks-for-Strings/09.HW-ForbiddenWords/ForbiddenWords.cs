/*We are given a string containing a list of forbidden words and a text containing some of these words. 
 * Write a program that replaces the forbidden words with asterisks. Example:
 *                  Microsoft announced its next generation PHP compiler today. 
 *                  It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR
 * Words: "PHP, CLR, Microsoft"
 * The expected result:
                    ********* announced its next generation *** compiler today.
 *                  It is based on .NET Framework 4.0 and is implemented as a dynamic language in ***.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ForbiddenWords
    {
        static void Main()
        {
            string input = "Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
            string result = input;
            string forbidden = "PHP, CLR, Microsoft";
            string[] forbidenWords = forbidden.Split(',');
            foreach (var item in forbidenWords)
            {
                string word=item.Trim();
                result = result.Replace(word,new string('*',word.Length));                
            }
            Console.WriteLine(input);
            Console.WriteLine();
            Console.WriteLine("Forbidden word: {0}",forbidden);
            Console.WriteLine();
            Console.WriteLine(result);
        }
    }

