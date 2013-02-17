/*Write a program that reverses the words in given sentence.
	Example: "C# is not C++, not PHP and not Delphi!"  "Delphi not and PHP, not C++ not is C#!".
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class ReverseWordsInSentence
    {
        static void Main()
        {
            string sentence = "C# is not C++, not PHP and not Delphi!";
                        
            char[] separator = { ' ', '!' ,','};
            string[] words = sentence.Split(separator,StringSplitOptions.RemoveEmptyEntries);

            StringBuilder result = new StringBuilder();

            int currentWords = words.Length - 1;

            string[] subSentence = sentence.Split(',');
            foreach (var item in subSentence)
            {
                string newitem = item.Trim();
                int countWordsSub = newitem.Split(' ').Length;
                for (int i = 0; i < countWordsSub; i++)
                {
                    result.AppendFormat("{0} ", words[currentWords]);
                    currentWords--;
                }
                result.Remove(result.ToString().Length - 1, 1);
                result.Append(", ");
            }
            result.Remove(result.ToString().Length - 2, 2);
            result.Append("!");
            Console.WriteLine(sentence);
            Console.WriteLine();
            Console.WriteLine(result.ToString());                        
        }
    }

