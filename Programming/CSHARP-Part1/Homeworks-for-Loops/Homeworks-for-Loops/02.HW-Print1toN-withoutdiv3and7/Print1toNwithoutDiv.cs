using System;

class Print1toNwithoutDiv
{
    static void Main()
    {
        int n;
        do
        {
            Console.Write("Enter positive number (N) = ");
            n = int.Parse(Console.ReadLine());
        } while (n < 1);
        for (int num=1; num <= n;num++ )
        {
            if ((num % 7 == 0) && (num % 3 == 0))
                {                    
                    continue;
                }
            Console.Write(num + " ");                
         }
        Console.WriteLine();
    }
}
