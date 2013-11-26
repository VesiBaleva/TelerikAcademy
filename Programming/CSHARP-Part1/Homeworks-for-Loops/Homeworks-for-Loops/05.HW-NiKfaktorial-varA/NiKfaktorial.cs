using System;

class NiKfaktorial
{
    static void Main()
    {
        Console.Write("Enter number K = ");
        int k = int.Parse(Console.ReadLine());
        Console.Write("Enter number N (less than N and greater than 1) = ");
        int n = int.Parse(Console.ReadLine());
        decimal result = 1;        
        
        if (n < k && n > 1)
        {
            //Zadachata N!*K!/(K-N)! moje da se oprosti do proizvedenieto na chislata ot 
            //((K-N)+1 do K)*N!
            for (int i = (k-n)+1; i <= k; i++)
            {
                result *= i;
            }
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            Console.WriteLine("The result for N!*K!/(K-N)! = "+result);                   
        }
        else
        {
            Console.WriteLine("Number n is out of the limited!!!");
        }
    }
}

