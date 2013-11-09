using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.StackAsAuto_resizableArray
{
    public class Demo
    {
        internal static void Main()
        {
            StackAsAutoResizableArray<string> stack = new StackAsAutoResizableArray<string>(4);

            for (int i = 0; i < 4; i++)
            {
                stack.Push("Item. " + i);
            }

            Console.WriteLine(stack.ToString());

            Console.WriteLine("The top is {0}", stack.Peek());

            stack.Pop();

            Console.WriteLine(stack.ToString());

            string[] testArray = new string[stack.Count];

            testArray = stack.ToArray();

            Array.Sort(testArray);

            Console.Write("Sorted: ");
            for (int i = 0; i < testArray.Length; i++)
            {
                Console.Write("{0} ",testArray[i]);
            }
            Console.WriteLine();
        }
    }
}
