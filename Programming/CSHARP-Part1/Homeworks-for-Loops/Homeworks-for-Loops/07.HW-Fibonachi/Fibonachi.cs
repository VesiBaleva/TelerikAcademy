using System;

class Fibonachi
    {
        static void Main()
        {
            int num = 1;
            do
            {
                Console.Write("Enter number (N) = ");
                num = int.Parse(Console.ReadLine());
            } while (num<1);
            decimal fib1 = 0;
            decimal sum = fib1;
            Console.Write(fib1+" ");            
            decimal fib2 = 1;
            sum += sum+fib2;
            Console.Write(fib2+" ");
            decimal fib3 = fib1+fib2;
            
            for (int i=3;i<=num ;i++ )
            {
                
                Console.Write(fib3 + " ");
                sum += fib3;
                fib1 = fib2;
                fib2 = fib3;
                fib3 = fib1 + fib2;                
            }
            Console.WriteLine();
            Console.WriteLine("The sum of n {0} of Fibonacci is = {1}",num,sum);
        }
    }

