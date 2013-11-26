using System;

class MatrixSpiral
{
    static void Main()
    {
        int num=1;
        do
        {
            Console.Write("N = ");
            num = int.Parse(Console.ReadLine());
        }
        while (num <= 0 || num > 20);
        int[,] array = new int[num, num];
        int i=0;
        int j = 0;
        int k = 0;
        int n=num-1;
        for (int broi = 0; broi <= n; broi++,n--)
        {
            for (i = broi, j = broi; j <= n; j++)
            {
                array[i, j] = ++k;
            }
            for (i = broi+1, j = n; i <= n; i++)
            {
                array[i, j] = ++k;
            }
            for (i = n, j = n-1; j >= broi; j--)
            {
                array[i, j] = ++k;
            }
            for (i = n-1, j = broi; i > broi; i--)
            {
                array[i, j] = ++k;
            }
        }
        for (i = 0; i < num; i++)
        {
            for (j = 0; j <num; j++)
            {
                if (array[i,j]<=9)
                {
                    Console.Write(array[i, j] + "  |");
                }
                else if (array[i, j] <= 99 && array[i,j]>=10)
                {
                    Console.Write(array[i, j] + " |");
                }  
                else
                {
                    Console.Write(array[i, j] + "|");
                }
            }
            Console.WriteLine();
        }
        
    }
}

