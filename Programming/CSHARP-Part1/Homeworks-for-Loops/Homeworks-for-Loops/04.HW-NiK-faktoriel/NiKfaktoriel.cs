using System;

class NiKfaktoriel
{
    static void Main()
    {
        Console.Write("Enter number N = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter number K (less than N and greater than 1) = ");
        int k = int.Parse(Console.ReadLine());
        decimal result = 1;
        
        if (k < n && k > 1)
        {
            for (int i = (k+1); i <= n; i++)
            {
                result*=i;
            }                      
            Console.WriteLine("N!/K! = " + result);
        }
        else
        {
            Console.WriteLine("Number K is out of the limited!!!");
        }
    }
}

