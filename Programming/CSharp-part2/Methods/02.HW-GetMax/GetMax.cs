/* Write a method GetMax() with two parameters that returns the bigger of two integers.
 * Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().
*/
using System;

    class GetMax
    {
        static int GetMaxMethod(int num1, int num2)
        {
            return Math.Max(num1,num2);
        }

        static void Main()
        {
            Console.WriteLine("Enter one number: ");
            int num1 = int.Parse(Console.ReadLine());
            int biggest=num1;
            for (int i = 1; i <=2; i++)
			{
			    Console.WriteLine("Enter another number: ");
                num1 = int.Parse(Console.ReadLine());
                biggest=GetMaxMethod(biggest,num1);
			}
            Console.WriteLine("The best number -> {0}",biggest);
        }
    }

