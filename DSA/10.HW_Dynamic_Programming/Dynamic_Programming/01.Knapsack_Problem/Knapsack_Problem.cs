using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Knapsack_Problem
{
    class Knapsack_Problem
    {
        static void Main(string[] args)
        {
            int[] sizes = new int[] { 3, 8, 4, 1, 2, 8 };
            int[] values = new int[] { 2, 12, 5, 4, 3, 13 };
            int capacity = 10;

            SolveKnapsackProblemNoDuplicatesAllowed(values, sizes, capacity);
        }

        private static void SolveKnapsackProblemNoDuplicatesAllowed(int[] V, int[] S, int C)
        {
            // Assume the array V[i] 
            // contains the values of the items
            // Assume the array S[i] 
            // contains the sizes of the items

            int n = V.Length;
            bool[,] used = new bool[C + 1, n];
            int[] M = new int[C + 1];

            // Trivial case when (j=0) 
            // the value we get is also zero
            M[0] = 0;

            // For each slot (j) in the knapsack do
            for (int j = 1; j <= C; j++)
            {
                // M[j] will be max1 (or M[j-1]) 
                // if the jth slot is empty
                int max1 = M[j - 1];

                // M[j] will be max2 if the jth 
                // slot is occupied by some item
                // Initialize max2 to some small number
                int max2 = -999999;

                // This is used to mark the previous (j) 
                // slot if the jth slot is occupied
                int mark = 0;

                // This is used to keep the index
                // of the last candidate which can be put
                // in the knapsack
                int candidateUsed = 0;

                // Search for an item to occupy the jth 
                // slot such that it gives us maximum value
                for (int i = 0; i < n; i++)
                {
                    // For each item (i) calculate (V[i] + M[j - S[i]]) 
                    // then compare it to the current max. If it is greater 
                    // then update the current max. Only those items satisfying 
                    // the condition (j - S[i] >= 0) are checked because capacity 
                    // should not be negative
                    if (j - S[i] >= 0 && !used[j - S[i], i] && V[i] + M[j - S[i]] > max2)
                    {
                        // Update the max
                        max2 = V[i] + M[j - S[i]];
                        // Save the previous (j) position 
                        // that gives us the maximum value
                        mark = j - S[i];
                        // Update the candidate item which
                        // might be put in the knapsack
                        candidateUsed = i;
                    }
                }

                //Case1: jth slot is empty
                if (max1 > max2)
                {
                    M[j] = max1;

                    for (int k = 0; k < n; k++)
                    {
                        used[j, k] = used[j - 1, k];
                    }
                }
                //Case 2: jth slot is occupied
                else
                {
                    M[j] = max2;

                    for (int k = 0; k < n; k++)
                    {
                        used[j, k] = used[mark, k];
                    }

                    // mark the candidate as used, which will prevent us
                    // from putting it again in the knapsack
                    used[j, candidateUsed] = true;
                }
            }

            Console.WriteLine(
                "The maximum value we can get by filling\r\n" +
                "the knapsack with capacity {0} is {1}.",
                C,
                M[C]);

            for (int i = 0; i < n; i++)
            {
                if (used[C, i])
                {
                    Console.WriteLine("Size: {0}, Value: {1}", S[i], V[i]);
                }
            }
        }
    }
}
