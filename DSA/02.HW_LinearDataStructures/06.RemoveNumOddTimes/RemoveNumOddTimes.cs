using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.RemoveNumOddTimes
{
    class RemoveNumOddTimes
    {
        private static List<int> EnterNumbers()
        {
            List<int> numbers = new List<int>();

            Console.WriteLine("Enter integer numbers /for end press Enter/: ");
            int num = 0;

            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

            string[] str = Console.ReadLine().Split(delimiterChars);

            for (int i = 0; i < str.Length; i++)
            {
                if (int.TryParse(str[i], out num))
                {
                    numbers.Add(num);
                }
            }

            return numbers;
        }

        private static void CountNums(List<int> list, IDictionary<int, int> numbersCount)
        {
            foreach (int item in list)
            {
                int count = 1;

                if (numbersCount.ContainsKey(item))
                {
                    count = numbersCount[item] + 1;
                }
                numbersCount[item] = count;
            }
        }

        private static List<int> GetNumbersEvenTimes(List<int> list, IDictionary<int, int> result)
        {
            List<int> resultList = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                if (result[list[i]] % 2 == 0)
                {
                    resultList.Add(list[i]);
                }
            }

            return resultList;
        }

        private static void PrintResult(List<int> result)
        {
            foreach (var item in result)
	        {
                Console.Write("{0} ", item);
	        }
            Console.WriteLine();
        }

        private static void Main()
        {
            List<int> list = EnterNumbers();

            IDictionary<int,int> numbersCount = new Dictionary<int,int>();

            CountNums(list, numbersCount);

            List<int> resultList = GetNumbersEvenTimes(list,numbersCount);

            PrintResult(resultList);
        }
    }
}
