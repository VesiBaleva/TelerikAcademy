using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.ShortestSequenceNtoM
{
    class ShortestSequence
    {
        public static void Main()
        {
            Console.WriteLine("Enter a positive number for starting sequence:");
            int n = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter a positive number for finishing sequence:");
            int m = int.Parse(Console.ReadLine());
                        
            Stack<int> stack = new Stack<int>();
            stack.Push(m);

            while (m / 2 >= n)
            {
                m = m / 2;
                stack.Push(m);
            }

            while (m - 2 >= n)
            {
                m = m - 2;
                stack.Push(m);
            }

            while (m - 1 >= n)
            {
                m = m - 1;
                stack.Push(m);
            }

            PrintNumbers(stack);
        }

        private static void PrintNumbers(Stack<int> numbers)
        {
            Console.WriteLine("Print numbers:");
            Console.WriteLine(string.Join(",", numbers));
        }
    }
}
