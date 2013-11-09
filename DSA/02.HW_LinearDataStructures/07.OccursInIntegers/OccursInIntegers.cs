using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.OccursInIntegers
{
    class OccursInIntegers
    {
        private static int[] EnterNumbers()
        {
            Console.WriteLine("Enter integer numbers between 0 to 1000 /for end press Enter/: ");
            
            int num = 0;

            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

            string[] str = Console.ReadLine().Split(delimiterChars);

            int[] array = new int[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                if (int.TryParse(str[i], out num) && (num >= 0) && (num <= 1000))
                {
                    array[i] = num;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("The number is not in a range!");
                }
            }

            return array;
        }

        private static void CountNums(int[] array, IDictionary<int, int> numbersCount)
        {
            foreach (int item in array)
            {
                int count = 1;

                if (numbersCount.ContainsKey(item))
                {
                    count = numbersCount[item] + 1;
                }
                numbersCount[item] = count;                
            }
        }

        private static void PrintResult(IDictionary<int,int> result)
        {
            List<int> list = result.Keys.ToList();

            list.Sort();

            foreach (var item in list)
            {
                Console.WriteLine("{0} --> {1}", item, result[item]);
            }
            Console.WriteLine();
        }

        private static void Main()
        {
            int[] array = EnterNumbers();

            IDictionary<int, int> numbersCount = new Dictionary<int, int>();

            CountNums(array, numbersCount);

            PrintResult(numbersCount);
        }
    }
}
