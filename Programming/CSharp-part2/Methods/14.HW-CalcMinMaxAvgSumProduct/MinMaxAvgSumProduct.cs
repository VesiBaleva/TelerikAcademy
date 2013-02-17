/*Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers.
 * Use variable number of arguments.
*/
using System;

class MinMaxAvgSumProduct
    {
        public static int MinOfSequence(params int[] sequence)
        {
            int result=sequence[0];
            for (int i = 0; i < sequence.Length; i++)
			{
			    if (sequence[i]<result)
                {
                    result=sequence[i];
                }
			}
            return result;            
        }


        public static int MaxOfSequence(params int[] sequence)
        {
            int result = sequence[0];
            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] > result)
                {
                    result = sequence[i];
                }
            }
            return result;
        }
        public static double AverageOfSequence(params int[] sequence)
        {
            int sum = 0;
            
            for (int i = 0; i < sequence.Length; i++)
            {
                sum += sequence[i];
            }
            return sum/sequence.Length;
        }
        public static int SumOfSequence(params int[] sequence)
        {
            int sum = 0;

            for (int i = 0; i < sequence.Length; i++)
            {
                sum += sequence[i];
            }
            return sum;
        }
        public static int ProductOfSequence(params int[] sequence)
        {
            int product = 1;

            for (int i = 0; i < sequence.Length; i++)
            {
                product *= sequence[i];
            }
            return product;
        }
    static void Main()
    {
        
        int result = MinOfSequence(-3,6,5,4,17,108,25,1033,56,-2,0,2013);
        Console.WriteLine("The minimum of 3,6,5,4,17,108,25,1033,56,-2,0,1 -> {0}", result);
        result = MaxOfSequence(- 3, 6, 5, 4, 17, 108, 25, 1033, 56, -2, 0, 2013);
        Console.WriteLine("The maximum of sequence -> {0}",result);
        Console.WriteLine("The average of sequence 3, 6, 5 -> {0}",AverageOfSequence(3,6,5));
        Console.WriteLine("The sum of sequence 3, 6, 5 -> {0}",SumOfSequence(3,6,5) );
        Console.WriteLine("The product of sequence 3,6, 5 -> {0}",ProductOfSequence(3,6,5));
    }
    
}

