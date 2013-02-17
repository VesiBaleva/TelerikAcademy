/*Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).*/
using System;
using System.Collections.Generic;

class ShortRepresentation
    {
        static void Main()
        {
            Console.Write("Enter number bitween -32767 and 32767: ");
            short number = short.Parse(Console.ReadLine());
            List<byte> convertered = new List<byte>();
            int num = Math.Abs(number);
            while (num > 0)
            {
                convertered.Add((byte)(num % 2));
                num /= 2;
            }
            int length = convertered.Count;

            for (int i = 1; i <=15-length; i++)
            {
                convertered.Add(0);
            }

             if (number < 0)
            {
                convertered.Add(1);
            }
            else
            {
                convertered.Add(0);
            }           
            convertered.Reverse();

            Console.Write("The result ->");
            for (int i = 0; i < convertered.Count; i++)
            {
                Console.Write("{0}", convertered[i]);
            }
            Console.WriteLine(" -> 16 bits signed intiger binary representation!");


        }
    }

