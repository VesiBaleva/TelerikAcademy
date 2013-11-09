using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AllPermutations
{
    class AllPermutation
    {
        static void Main()
        {
            Console.Write("n=");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            bool[] used = new bool[n];

            Loops(array, 0, used);
        }

        static void Loops(int[] array, int index, bool[] used)
        {
            if (index == array.Length)
            {
                Console.WriteLine(string.Join(" ", array));
                return;
            }
            else
            {

               for (int i = 0; i < array.Length; i++)
               {
                   if (!used[i])
                   {
                       used[i] = true;
                       array[index] = i + 1;
                       Loops(array, index + 1, used);
                       used[i] = false;
                   }
               }
            }

        }
    }
}
