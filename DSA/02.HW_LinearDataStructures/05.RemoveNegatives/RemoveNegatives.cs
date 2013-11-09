using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.RemoveNegatives
{
    public class RemoveNegatives
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

        private static List<int> RemoveNegativesNumbers(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] < 0)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }

            return list;
        }

        private static void PrintResult(List<int> result)
        {
            if (result.Count==0)
            {
                Console.WriteLine("List has no positive integers.");
            }
            else
            {
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < result.Count; i++)
                {
                    sb.AppendFormat("{0} ", result[i]);
                }

                Console.WriteLine(sb.ToString());
            }
        }

        private static void Main()
        {
            List<int> list = EnterNumbers();

            List<int> result = RemoveNegativesNumbers(list);

            PrintResult(result);
        }
    }
}
