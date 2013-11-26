/*Write a program to print the first 100 members
 * of the sequence of Fibonacci:
 * 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
 */
using System;
class SequenceOfFibonacci
{
    static void Main()
    {
        byte members = 100;
        uint mem0 = 0;
        uint mem1 = 1;
        uint mem2 = 0;
        Console.Write("{0} {1} ", mem0,mem1);
        for (int i = 3; i <= 100; i++)
        {
            mem2 = mem1 + mem0;
            Console.Write("{0} ", mem2);
            mem0 = mem1;
            mem1 = mem2;            
        }
    }
}

