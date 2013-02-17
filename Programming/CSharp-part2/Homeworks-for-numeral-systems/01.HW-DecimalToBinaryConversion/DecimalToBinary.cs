/*Write a program to convert decimal numbers to their binary representation.
*/
using System;
using System.Collections.Generic;

    class DecimalToBinary
    {
        static void Main(string[] args)
        {
            Console.Write("Enter any number: ");
            int number = int.Parse(Console.ReadLine());
            List<byte> convertered = new List<byte>();
            while (number > 0)
            {
                convertered.Add((byte)(number % 2));
                number /= 2;
            }
            convertered.Reverse();
            for (int i = 0; i < convertered.Count; i++)
            {
                Console.Write("{0}",convertered[i]);
            }
            Console.WriteLine();
        }
    }

