/* Write a program that reads a rectangular matrix of size N x M and 
 * finds in it the square 3 x 3 that has maximal sum of its elements.
*/
using System;

    class MaximalSum
    {
        static void Main()
        {
            int[,] array ={
                             {1, 2, 3, 4},
                             {5, 6, 7, 8},     
                             {9, 10, 11, 12}
                             
                         };
            int currentSum = 0;
            int bestSum = 0;
            int bestI = 0;
            int bestJ = 0;
            Console.Write("Enter K - size of platform: ");
            int k = int.Parse(Console.ReadLine());
            for (int i=0; i < array.GetLength(0)-(k-1); i++)
            {
                for (int j = 0; j < array.GetLength(1)-(k-1); j++)
                {
                    for (int n = 0; n < k; n++)
                    {
                        for (int m = 0; m < k; m++)
                        {
                            currentSum += array[i+n, j+m];
                        }
                    }
                    if (currentSum > bestSum)
                    {
                        bestSum = currentSum;
                        bestI = i;
                        bestJ = j;
                    }
                    currentSum = 0;
                }                
            }
            Console.WriteLine();
            Console.WriteLine("Printing the matrix with maximal sum of platform!");
            Console.WriteLine("The maximal sum -> {0}", bestSum);
            Console.WriteLine();
            for (int i = 0; i < array.GetLength(0) ; i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if ((i >= bestI && j >= bestJ) && (i < bestI + k && j < bestJ + k))
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    Console.Write("{0,4}",array[i,j]);
                }
                Console.WriteLine();  
            }
        }
    }

