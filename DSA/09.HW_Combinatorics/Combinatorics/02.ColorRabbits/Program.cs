using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ColorRabbits
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int[] rabbits = new int[count];
            for (int i = 0; i < count; i++)
            {
                rabbits[i] = int.Parse(Console.ReadLine());
                rabbits[i] = rabbits[i] + 1;
            }

            IDictionary<int, int> itemsCount = new Dictionary<int, int>();
            
            foreach (var item in rabbits)
            {
                int countRab = 1;
                if (itemsCount.ContainsKey(item))
                {
                    countRab = itemsCount[item] + 1;
                }
                itemsCount[item] = countRab;
            }

            int sum = 0;
            foreach (var item in itemsCount)
            {
                  int value = (int)Math.Ceiling((double)item.Value/item.Key)*item.Key;
                  sum+=value;
            
            }

            Console.WriteLine(sum);

        }
    }
}
