/*A dictionary is stored as a sequence of text lines containing words and their explanations. 
 * Write a program that enters a word and translates it by using the dictionary. Sample dictionary:
 * .NET – platform for applications from Microsoft
 * CLR – managed execution environment for .NET
 * namespace – hierarchical organization of classes
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 class SearchInDictionary
 {
     static string Translate(string word)
     {
         
         var dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
         dictionary.Add(".NET", "platform for applications from Microsoft");
         dictionary.Add("CLR", "managed execution environment for .NET");
         dictionary.Add("namespace", "hierarchical organization of classes");
         return dictionary[word];
     }
     static void Main()
     {
         try
         {
             Console.Write("Enter a word: ");
             string word = Console.ReadLine();
             Console.WriteLine("{0} - {1}", word, Translate(word));
         }
         catch (KeyNotFoundException)
         {
             Console.WriteLine("There is not any description!");
         }
     }
 
 }

