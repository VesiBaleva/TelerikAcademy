using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SequenceOfPositiveNumbers
{
    class SumAndAverage
    {
        static List<int> EnterNumbers()
        {
            List<int> numbers = new List<int>();

            Console.WriteLine("Enter positive number /for end press Enter/: ");
            int num = 0;
                        
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

            string[] str = Console.ReadLine().Split(delimiterChars);

            for (int i = 0; i < str.Length; i++)
            {
                if (int.TryParse(str[i], out num))
                {
                    if (num > 0)
                    {
                        numbers.Add(num);
                    }
                }
            }
            
            return numbers;
        }

        static void PrintNumbers(List<int> numbers)
        {
            StringBuilder result = new StringBuilder();

            foreach (var item in numbers)
            {
                result.AppendFormat("{0}, ",item);
            }
            
            result.Remove(result.Length - 2, 2);

            Console.WriteLine(result.ToString());
        }

        
        static void Main()
        {
            List<int> numbers= EnterNumbers();

            int sum =numbers.Sum();
            double average = numbers.Average();

            PrintNumbers(numbers);

            
            Console.WriteLine("The sum is {0}",sum);
            Console.WriteLine("The average is {0}",average); 
        }
    }
}
