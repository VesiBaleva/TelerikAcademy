using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Variations
{
    class Variations
    {
        static void Main()
        {
            int n = 3;
            int k = 2;
            string[] words = new string[] { "hi", "a", "b"};
            int[] array = new int[k];
            Console.WriteLine(string.Join(", ", words));
            Console.WriteLine("->");
            Loops(array,words, 0,n);
        }

        static void Loops(int[] array,string[] words, int nestingLevel, int n)
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
                for (var i = 0; i < n; i++)
                {
                    array[nestingLevel] = i;
                    Loops(array, words, nestingLevel + 1, n);
                }
            }

        }
    }
}
