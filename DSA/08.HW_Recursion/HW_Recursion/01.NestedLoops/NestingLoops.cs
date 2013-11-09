using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.NestedLoops
{
    class NestingLoops
    {
        static void Main()
        {
            Console.Write("n=");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];

            Loops(array, n, 0);
        }

        static void Loops(int[] array, int sizeOfArray, int nestingLevel)
        {
            if (nestingLevel == sizeOfArray)
            {
                Console.WriteLine(string.Join(" ",array));
                return;
            }
            else
            {
                for (int i = 0; i < sizeOfArray; i++)
                {
                    array[nestingLevel] = i + 1;
                    Loops(array, sizeOfArray, nestingLevel + 1);
                
                
                }                
            }

        }
    }
}
