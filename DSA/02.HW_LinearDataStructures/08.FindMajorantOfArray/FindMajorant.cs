using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.FindMajorantOfArray
{
    public class FindMajorant
    {
        private static int[] EnterNumbers()
        {
            Console.WriteLine("Enter integer numbers /for end press Enter/: ");

            int num = 0;

            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

            string[] str = Console.ReadLine().Split(delimiterChars);

            int[] array = new int[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                if (int.TryParse(str[i], out num))
                {
                    array[i] = num;
                }                
            }

            return array;
        }

        private static IDictionary<int,int> CountNums(int[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentNullException("Sequence must not be empty!");
            }

            IDictionary<int,int> numbersCount = new Dictionary<int,int>();
            
            foreach (int item in array)
            {
                int count = 1;

                if (numbersCount.ContainsKey(item))
                {
                    count = numbersCount[item] + 1;
                }
                numbersCount[item] = count;
            }

            return numbersCount;
        }

        private static bool GetMajorant(int[] array, out int finded)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentNullException("Sequence must not be empty!");
            }

            finded = int.MinValue;
            IDictionary<int, int> result = CountNums(array);
            bool hasMajorant = false;

            foreach (var item in result)
            {
                if (item.Value >= (array.Length / 2) - 1)
                {
                    if (finded < item.Value)
                    {
                        finded = item.Key;
                        hasMajorant = true;
                    }
                }
            }
            
            return hasMajorant;
        }

        private static void Main()
        {
            int[] array = EnterNumbers();

            int majorant = int.MinValue;

            if (GetMajorant(array, out majorant))
            {
                Console.WriteLine("The majorant of the array --> {0}", majorant);
            }
            else
            {
                Console.WriteLine("The array has no majorant!");
            }
        }
    }
}
