/*Write a program that reads a string from the console and lists all different words in the string along 
 * with information how many times each word is found.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22.HW_DifferentWords
{
    class DifferentWords
    {
        static void Main()
        {
            Console.WriteLine("Enter any words or phrase: ");
            string txt = Console.ReadLine();
                       
            StringBuilder separatorBuild=new StringBuilder();
                        
            for (int i = 0; i < txt.Length; i++)
            {
                if (Char.IsPunctuation(txt[i]) || Char.IsSeparator(txt[i]))
                {
                    separatorBuild.Append(txt[i]);
                }
            }
            
            char[] separators = separatorBuild.ToString().ToCharArray();
            string[] words = txt.Split(separators,StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < words.Length; i++)
            {
                if (dict.ContainsKey(words[i]))
                {
                    dict[words[i]]++;
                }
                else
                {
                    dict.Add(words[i],1);
                }

            }
            //order list by frequence words in given string
            var sortedWords = dict.OrderByDescending(x => x.Value).ThenBy(x=>x.Key);
            foreach (var item in sortedWords)
            {
                Console.WriteLine("{0} - {1}", item.Key, item.Value);
            }
            Console.WriteLine();              

        }
    }
}
