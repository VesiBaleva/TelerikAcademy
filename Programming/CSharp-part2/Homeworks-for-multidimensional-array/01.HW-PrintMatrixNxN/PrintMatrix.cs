/* Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)
 *
 */
using System;

    class PrintMatrix
    {
        static void PrinA(int[,] array, int n)
        {
          for (int i = 0; i < n; i++)
          {
              for (int j = 0,number=1; j < n; j++,number+=n)
              {
                  array [i,j] = i+number;
              }
          }
          for (int i = 0; i < n; i++)
          {
              for (int j = 0; j < n; j++)
              {
                  Console.Write("{0,4}", array[i,j]);
              }
              Console.WriteLine();
          }
        }

        static void PrintB(int[,] array, int n, int start)
        {
              for (int i = 0; i <= n; i++)
              {
                  if (i == n)
                  {
                      break;
                  }
                  for (int j = 0; j < n; j++)
                  {
                      array[j, i] = start;
                      start++;
                  }
                  i++;
                  if (i == n)
                  {
                      break;
                  }
                  for (int j = n-1; j >= 0; j--)
                  {
                      array[j, i] = start;
                      start++;
                  }
              }
              for (int i = 0; i < n; i++)
              {
                  for (int j = 0; j < n; j++)
                  {
                      Console.Write("{0,4}", array[i, j]);
                  }
                  Console.WriteLine();
              }
        }

        static void PrintC(int[,] array, int n, int start)
        {
            for (int diag = 0; diag < (n * 2) - 1; diag++)
            {
                int i = n - 1 - diag;
                if (i < 0)
                {
                    i = 0;
                }
                int j = 0;
                if (diag >= n)
                {
                    j = diag - n + 1;
                }
                while ((i < n) && (j < n))
                {
                    array[i, j] = start;
                    start++;
                    i++;
                    j++;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0,4}", array[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void PrintD(int[,] array, int n, int start)
        {
            int i = 0;
            int j = 0;
            for (int times = 0; times < n / 2 + n % 2; times++)
            {
                for (i = times, j = times; j < n - times; j++)
                {
                    array[j, i] = start;
                    start++;
                }
                for (i = times + 1, j = j - 1; i < n - times; i++)
                {
                    array[j, i] = start;
                    start++;
                }
                for (i = i - 1, j = j - 1; j >= times; j--)
                {
                    array[j, i] = start;
                    start++;

                }
                for (i = i - 1, j = j + 1; i > times; i--)
                {
                    array[j, i] = start;
                    start++;
                }
            }
            i = 0;
            j = 0;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write("{0,4}", array[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void Main()
        {
            Console.Write("Enter number N: ");
            int n = int.Parse(Console.ReadLine());
            int[,] array = new int[n, n];
            PrinA(array, n);
            Console.WriteLine();
            Console.WriteLine();
            PrintB(array, n, 1);
            Console.WriteLine();
            Console.WriteLine();
            PrintC(array, n, 1);
            Console.WriteLine();
            Console.WriteLine();
            PrintD(array, n, 1);        
    }       
}

