using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.LinkedListQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedListQueue<int> queue = new LinkedListQueue<int>();

            for (int i = 1; i <= 5; i++)
            {
                queue.Enqueue(i);
            }

            Console.WriteLine("Count: {0}", queue.Count);

            Console.WriteLine("The peek is {0}", queue.Peek());

            for (int i = 1; i <=  4; i++)
            {
                queue.Dequeue();
            }

            Console.WriteLine("After dequeue 4 item the peek is {0}", queue.Peek());
        }
    }
}
