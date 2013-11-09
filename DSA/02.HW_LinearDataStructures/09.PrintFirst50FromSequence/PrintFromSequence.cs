using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.PrintFirst50FromSequence
{
    public class PrintFromSequence
    {
        static void Main()
        {
            Console.WriteLine("Enter number n: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number of items for print: ");
            int first50 = int.Parse(Console.ReadLine());

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(n);

            Console.WriteLine("N = {0}", n);
            Console.WriteLine("First items = {0}", first50);
            Console.Write("Sequence =");

            int index = 0;
            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                Console.Write(" {0}", current);
                index++;

                if (index == first50)
                {
                    Console.WriteLine();
                    break;
                }
                queue.Enqueue(current + 1);
                queue.Enqueue(2 * current+1);
                queue.Enqueue(current + 2);
            }
        }
    }
}
