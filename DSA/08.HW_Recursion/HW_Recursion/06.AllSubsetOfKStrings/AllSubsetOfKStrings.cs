using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.AllSubsetOfKStrings
{
    class AllSubsetOfKStrings
    {
        static void Main()
        {
            int k = 2;
            string[] words = new string[] { "test", "rock", "fun" };
            int[] array = new int[k];
            Console.WriteLine(string.Join(", ", words));
            Console.WriteLine("->");
            Loops(array, words, 0, 0);
        }

        static void Loops(int[] array, string[] words, int nestingLevel, int start)
        {
            if (nestingLevel == array.Length)
            {
                List<string> selectedItems = new List<string>();
                foreach (var item in array)
                {
                    selectedItems.Add(words[item]);
                }

                Console.WriteLine(string.Join(" ", selectedItems));
                return;
            }
            else
            {
                for (var i = start; i < words.Length; i++)
                {
                    array[nestingLevel] = i;
                    Loops(array, words, nestingLevel + 1,i+1);
                }
            }

        }
    }
}
