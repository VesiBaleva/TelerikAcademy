using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Dividers
{
    class Program
    {
        static void Main(string[] args)
        {
            int len = int.Parse(Console.ReadLine());
            int[] array = new int[len];
            for (int i = 0; i < len; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(array);
            var list = new SortedDictionary<int,int>();
            PermuteRep(array, 0, array.Length,list);

            Console.WriteLine(list.First().Value);
               

            
        }

        static void PermuteRep(int[] arr, int start, int n, SortedDictionary<int,int> list)
        {
            var printResult = Print(arr);

            if (list.Count != 0)
            {
                if (!list.ContainsKey(printResult.Key))
                {
                    list.Add(printResult.Key,printResult.Value);
                }
            }
            else
            {
                list.Add(printResult.Key, printResult.Value);
            }

            for (int left = n - 2; left >= start; left--)
            {
                for (int right = left + 1; right < n; right++)
                {
                    if (arr[left] != arr[right])
                    {
                        Swap(ref arr[left], ref arr[right]);
                        PermuteRep(arr, left + 1, n,list);
                    }
                }

                // Undo all modifications done by the
                // previous recursive calls and swaps
                var firstElement = arr[left];
                for (int i = left; i < n - 1; i++)
                {
                    arr[i] = arr[i + 1];
                }
                arr[n - 1] = firstElement;
            }
        }

        static KeyValuePair<int,int> Print<T>(T[] arr)
        {
            int number = int.Parse(string.Join("", arr));

            int divs = FindDividers(number);

            return new KeyValuePair<int,int>(divs,number);
        }

        static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }

        static int FindDividers(int number)
        {
            int count = 0;

            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    count++;
                }
            }

            return count;
        }

        
    }
}
