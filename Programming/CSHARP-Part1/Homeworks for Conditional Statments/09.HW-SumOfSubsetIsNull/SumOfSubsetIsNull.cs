/* We are given 5 integer numbers.
 * Write a program that checks if the sum of some subset of them is 0.
 * Example: 3, -2, 1, 1, 8  1+1-2=0.*/
using System;
class SumOfSubsetIsNull
{
    static void Main()
    {
        Console.WriteLine("Enter 5 integer value on a separate line: ");
        int[] item= new int [5];
        //in array enter 5 values
        for (int i=0;i<item.Length;i++)
        {
            item[i]=int.Parse(Console.ReadLine());
        }
        //we have an example and our numbers in array seems with this 8 1 1 -2 3
        int maxCombination=(int)Math.Pow(2,5)-1;
        //maximum combination is 31 -> in binary this ->from 0 0 0 0 1
        //                                               to  1 1 1 1 1
        //exluding 0
        int countSubsets=0;
        for (int i=1;i<=maxCombination;i++)
        {
            int sum=0;
            string subset="";
            for (int p=0;p<5;p++)
            {
                int mask=1<<p;
                int iAndMask = i & mask;
                int bit= iAndMask >> p;
               //with mask resieve bit at position
                if (bit==1)
               //when bit at position p is 1 we take from array the number with index p
                {
                    sum+=item[p];
                    subset=subset+item[p]+" ";
                }
            }
            //after 5 itteration we calculate the sum with taken numbers from array
            if (sum==0)
            //we compares sum of the taken numbers with 0
            {
                Console.WriteLine("The sum of subset {1} -> {0}",sum,subset);
                //and count the subsets with sum 0;
                countSubsets++;
            }            
        }
        Console.WriteLine("\nThe count of all subsets     -> {0}",countSubsets);
    }

}

