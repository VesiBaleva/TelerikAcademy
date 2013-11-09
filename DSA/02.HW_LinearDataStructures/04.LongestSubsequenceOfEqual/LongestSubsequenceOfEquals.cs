using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.LongestSubsequenceOfEqual
{
    public class LongestSubsequenceOfEquals
    {
        public static List<int> EnterNumbers()
        {
            List<int> numbers = new List<int>();

            Console.WriteLine("Enter number /for end press Enter/: ");
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

        public static List<int> GetLongestSeq(List<int> list)
        {
            List<int> resultList = new List<int>();

            int maxCountSeq = 1;
            int currentCountSeq = 1;
            int currentStartIndex = 0;
            int maxStartIndex = 0;

            int i = 0;
            if (list.Count == 0)
            {
                throw new ArgumentException("The sequence of numbers cannot be empty!");
            }

            if (list == null)
            {
                throw new ArgumentNullException("The sequence of numbers is null.");
            }

            while (i < list.Count - 1)
            {
                currentStartIndex = i;

                currentCountSeq = 1;

                while (list[i] == list[i + 1])
                {
                    currentCountSeq++;
                    i++;
                    if (i == list.Count - 1)
                    {
                        break;
                    }
                }

                if (maxCountSeq < currentCountSeq)
                {
                    maxStartIndex = currentStartIndex;
                    maxCountSeq = currentCountSeq;
                }

                i++;
            }

            for (int j = 0; j < maxCountSeq; j++)
            {
                resultList.Add(list[maxStartIndex]);
            }

            return resultList;
        }

        public static void PrintResult(List<int> resultList)
        {
            Console.WriteLine("{0} -> {1}", String.Join(", ", resultList), resultList.Count);
        }

        public static void Main()
        {
            List<int> list = EnterNumbers();

            List<int> resultList = GetLongestSeq(list);

            PrintResult(resultList);
           
        }
    }
}
