using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;

namespace _01.CountNums
{
    public class CountDoubles
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("Enter array of doubles:");
            string enteredDoubles = Console.ReadLine();

            Console.WriteLine("Dictionary<TKey,TValue>");
            Console.WriteLine("-----------------------");

            IDictionary<double, int> doublesCount = new Dictionary<double, int>();

            doublesCount = CountDoublesNums(enteredDoubles);

            PrintResult(doublesCount);
        }

        private static void PrintResult(IDictionary<double, int> doublesCount)
        {
            foreach (var num in doublesCount)
            {
                Console.WriteLine("{0} --> {1} times",num.Key,num.Value);
            }
        }

        private static IDictionary<double, int> CountDoublesNums(string nums)
        {
            IDictionary<double, int> doublesCount = new Dictionary<double, int>();

            string[] str = nums.Split(new char[] { ' ', ','},StringSplitOptions.RemoveEmptyEntries);
            double[] arrayDoubles = new double[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                arrayDoubles[i] = double.Parse(str[i]);
            }

            foreach (var num in arrayDoubles)
            {
                int count = 1;
                if (doublesCount.ContainsKey(num))
                {
                    count = doublesCount[num] + 1;
                }
                doublesCount[num] = count;
            }

            return doublesCount;
        }        
    }
}
