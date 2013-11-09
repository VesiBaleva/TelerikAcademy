using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.ImplementLinkedList
{
    public class ImplementLinkedList
    {
        public static void Main()
        {
            CustomLinkedList<int> testList = new CustomLinkedList<int>();

            for (int i = 1; i < 25; i++)
            {
                testList.AddFirst(i);
            }

            for (int i = 1; i < 25; i++)
            {
                testList.AddLast(i);
            }

            Console.WriteLine(testList.Count);

            for (int i = 0; i < testList.Count; i++)
            {
                Console.Write("{0} ", testList[i]);
            }

            Console.WriteLine();
            Console.WriteLine("Demonstration without 1");
            testList.Remove(1);

            for (int i = 0; i < testList.Count; i++)
            {
                Console.Write("{0} ", testList[i]);
            }

            Console.Write("The sequence contains 2: {0}",testList.Contains(2));

            testList.Clear();

            Console.WriteLine();
        }
    }
}
