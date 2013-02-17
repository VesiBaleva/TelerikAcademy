/*Write a program that reads a string from the console and replaces all series of consecutive identical letters 
 * with a single one. Example: "aaaaabbbbbcdddeeeedssaa"  "abcdedsa".
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class ConsecutiveIndenticalLetters
    {
        static void Main()
        {
            string text = "aaaaabbbbbcdddeeeedssaa";
            StringBuilder textBuild = new StringBuilder();
            textBuild.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
               if (textBuild[textBuild.Length-1]!=text[i])
               {
                   textBuild.Append(text[i]);
               }
            }
            Console.WriteLine(text);
            Console.WriteLine("The result -> {0}",textBuild.ToString());
        }
    }

