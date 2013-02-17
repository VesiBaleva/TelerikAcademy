/*Write a program that reads a list of words, separated by spaces and prints the list in an alphabetical order.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class WordsInAlphabeticalOrder
    {
        static void Main()
        {
            Console.WriteLine("Enter any words: ");
            string text = Console.ReadLine();
            StringBuilder separatorBuild = new StringBuilder();
            
            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsPunctuation(text[i]) || Char.IsSeparator(text[i]))
                {
                    separatorBuild.Append(text[i]);
                }
            }
            char[] separators = separatorBuild.ToString().ToCharArray();
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            List<string> distinctWords = new List<string>(words.Distinct());
            var sortedWords = distinctWords.OrderBy(x => x);
            foreach (var item in sortedWords)
            {
                Console.WriteLine(item);
            }
        }
    }

