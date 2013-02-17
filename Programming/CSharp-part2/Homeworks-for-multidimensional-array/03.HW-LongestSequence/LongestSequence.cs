/* We are given a matrix of strings of size N x M. 
 * Sequences in the matrix we define as sets of several neighbor elements
 * located on the same line, column or diagonal. 
 * Write a program that finds the longest sequence of equal strings in the matrix. Example:
*/
using System;

class LongestSequence
{

    static void Main()
    {
        string[,] matrix = {
                                   {"fifi",  "xxx",  "pp",    "spp"},
                                   {"fo",    "pp",   "fiftt", "sp"},
                                   {"pp",    "xp",   "xp",    "sp"}
                               };
        string theSame = "";
        string bestTheSame = "";
        int countTheSame = 1;
        int longestTheSame = 0;
        int longestI = 0;
        int longestJ = 0;
        int streigth = 0;
        int diagLength = Math.Min(matrix.GetLength(0), matrix.GetLength(1));
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                theSame = matrix[i, j];
                for (int k = j + 1; k < matrix.GetLength(1); k++)
                {
                    
                    if (theSame == matrix[i, k])
                    {
                        countTheSame++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (countTheSame > longestTheSame)
                {
                    longestTheSame = countTheSame;
                    bestTheSame = theSame;
                    longestI = i;
                    longestJ = j;
                    streigth = 1;
                }
                countTheSame = 1;
                theSame = "";
            }
        }

            Console.WriteLine();

        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                theSame = matrix[j, i];
                for (int k = j + 1; k < matrix.GetLength(0); k++)
                {
                    
                    if (theSame == matrix[k, i])
                    {
                        countTheSame++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (countTheSame > longestTheSame)
                {
                    longestTheSame = countTheSame;
                    bestTheSame = theSame;
                    longestI = i;
                    longestJ = j;
                    streigth = 2;
                }
                countTheSame = 1;
                theSame = "";
            }
        }

            Console.WriteLine();

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                theSame = matrix[i, j];
                for (int k = i + 1, l = j + 1; (k <matrix.GetLength(0) && l<matrix.GetLength(1)); k++, l++)
                {
                
                        
                        if (theSame == matrix[k, l])
                        {
                            countTheSame++;
                        }
                        else
                        {
                            break;
                        }  
                }
                if (countTheSame > longestTheSame)
                {
                    longestTheSame = countTheSame;
                    bestTheSame = theSame;
                    longestI = i;
                    longestJ = j;
                    streigth = 3;
                }
                countTheSame = 1;
                theSame = "";
            }
        }

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                theSame = matrix[i, j];
                for (int k = i - 1, l = j + 1; (k < matrix.GetLength(0) && l < matrix.GetLength(1) && k>=0); k--, l++)
                {


                    if (theSame == matrix[k, l])
                    {
                        countTheSame++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (countTheSame > longestTheSame)
                {
                    longestTheSame = countTheSame;
                    bestTheSame = theSame;
                    longestI = i;
                    longestJ = j;
                    streigth = 4;
                }
                countTheSame = 1;
                theSame = "";
            }
        }
        Console.WriteLine();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0,10}", matrix[i,j]);
            }
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.Write("The result is: ");
        for (int i = 0; i < longestTheSame; i++)
        {
            Console.Write("{0} ",bestTheSame);
        }
        Console.Write("({0} times) ", longestTheSame);
        switch (streigth)
        {
            case 1: Console.WriteLine("horizontally"); break;
            case 2: Console.WriteLine("vertically"); break;
            case 3: Console.WriteLine("rigth down"); break;
            case 4: Console.WriteLine("rigth top"); break;
            default: Console.WriteLine(); break;
        }

    }
}

