using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.SortingList
{
    class SortingList
    {
        static List<int> EnterNumbers()
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

        static void Main()
        {
            List<int> list=EnterNumbers();

            list.Sort();

            Console.WriteLine("Increase sortered -> {0}", String.Join(", ", list));
        }
    }
}
