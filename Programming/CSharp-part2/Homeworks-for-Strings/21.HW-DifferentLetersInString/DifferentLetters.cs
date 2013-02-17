/*Write a program that reads a string from the console and prints all different letters 
 * in the string along with information how many times each letter is found. 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21.HW_DifferentLetersInString
{
    class DifferentLetters
    {
        static void Main()
        {
            Console.WriteLine("Enter any words or phrase: ");
            string txt = Console.ReadLine();
            StringBuilder lettersBuild = new StringBuilder();
            for (int i = 0; i < txt.Length; i++)
            {
                if (Char.IsLetter(txt[i]))
                {
                    lettersBuild.Append(txt[i]);
                }

            }
            
            string txtDistinct=lettersBuild.ToString();
            Dictionary<char, int> lettersDict = new Dictionary<char, int>();
            for (int i = 0; i < txtDistinct.Length; i++)
            {
                if (lettersDict.ContainsKey(txtDistinct[i]))
                {
                    lettersDict[txtDistinct[i]]++;
                }
                else
                {
                    lettersDict.Add(txtDistinct[i], 1);
                }
            }
            foreach (var item in lettersDict)
            {
                Console.WriteLine("{0} {1}",item.Key,item.Value);
            }
            Console.WriteLine();             

        }
    }
}
