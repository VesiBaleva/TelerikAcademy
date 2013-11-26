using System;
class FirTree
{
    static void Main()
    {
        byte n=byte.Parse(Console.ReadLine());
        byte k = (byte)(n - 1);
        bool flag = false;
        for (int i = 1; i<=n; i++)
        {
            if (i == n)
            {
                i = 1;
                flag = !flag;
            }
            for (int j = 1; j < 2*(n - 1);j++ )
                if (j > k-i  && j < k+i)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }
            Console.WriteLine();
            if (flag) break;
        }
    }
}

