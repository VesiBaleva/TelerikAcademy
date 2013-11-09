using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.HW_CombinationOfDuplicates
{
    class CombinationOfDuplcates
    {
      static void Main()
      {
          Console.Write("n=");
          int n = int.Parse(Console.ReadLine());
          Console.Write("k=");
          int k = int.Parse(Console.ReadLine());
          int[] array = new int[k];
      
          Loops(array, n, 0, 0);
      }
      
      static void Loops(int[] array, int n, int nestingLevel, int start)
      {
          if (nestingLevel == array.Length)
          {
              Console.WriteLine(string.Join(" ", array));
              return;
          }
          else
          {
      
              for (int i=start; i < n; i++)
              {
                  array[nestingLevel] = i+1;
                  Loops(array, n, nestingLevel+1, i);
              }
          }
      
      }

    }
}
