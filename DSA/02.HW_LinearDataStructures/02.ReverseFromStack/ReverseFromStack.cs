using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ReverseFromStack
{
    class ReverseFromStack
    {
        static Stack<int> FillStack()
        {
            Console.WriteLine("Enter N as a number of integers: ");

            int parsedN = int.MinValue;

            Stack<int> stack = new Stack<int>();

            if (int.TryParse(Console.ReadLine(), out parsedN) && parsedN > 0)
            {
                int item = int.MinValue;

                for (int i = 0; i < parsedN; i++)
                {
                    Console.Write("Enter number {0}:",i);

                    if (int.TryParse(Console.ReadLine(), out item))
                    {
                        stack.Push(item);
                    }
                    else
                    {
                        Console.WriteLine("Entered is not an integer!");
                    }
                }
                
            }
            else
            {
                Console.WriteLine("Invalid number N!");
            }

            return stack;
        }

        static void ReverseStack(Stack<int> stack)
        {
            while (stack.Count > 0)
            {
                int reversed = stack.Pop();

                Console.WriteLine(reversed);
            }
 
        }

        static void Main()
        {
            Stack<int> stack = FillStack();

            Console.WriteLine("Reverse:");

            ReverseStack(stack);
        }
    }
}
