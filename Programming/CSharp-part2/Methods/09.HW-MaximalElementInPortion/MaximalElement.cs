/* Write a method that return the maximal element in a portion of array of integers 
 * starting at given index. Using it write another method that sorts an array in ascending / descending order.
*/
using System;

    class MaximalElement
    {
        public static int MaxItem(int[] array,int index, int endIndex)
        {
            int result=array[index];
            

            for (int i = index; i < endIndex; i++)
            {
                if (array[i] > result)
                {
                    result = array[i];
                }
            }

            return result;
        }
        public static int MaxItemIndex(int[] array, int index, int endIndex)
        {
            int result = index;


            for (int i = index; i < endIndex; i++)
            {
                if (array[i] > array[result])
                {
                    result = i;
                }
            }

            return result;
        }
        public static void SortDescending(int[] array)
        {
            Console.WriteLine("Sorting Descending!");
            int temp=0;
            int tempIndex = 0;
            for (int i = 0; i < array.Length; i++)
            {
                temp = array[i];
                tempIndex = MaxItemIndex(array, i,array.Length);
                array[i] = MaxItem(array, i,array.Length);
                array[tempIndex] = temp;
          
            }
            
        }

        public static void SortAscending(int[] array)
        {
            Console.WriteLine("Sorting Ascending!");
            int temp = 0;
            int tempIndex = 0;
            for (int i = array.Length-1; i >=0; i--)
            {
                temp = array[i];
                tempIndex = MaxItemIndex(array, 0,i+1);
                array[i] = MaxItem(array, 0, i+1);
                array[tempIndex] = temp;
                
            }

        }

        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0,5}",array[i]);
            }

            Console.WriteLine();
        }
        
        static void Main(string[] args)
        {
            int[] array = { 52, 67, 845, 902, 1033, 1005, 1, 2, 58, 99, 101, 75, 68, 32 };
            foreach (var item in array)
            {
                Console.Write("{0,5}",item);
            }
            Console.WriteLine();
            int maxValue = MaxItem(array, 0,array.Length);
            Console.WriteLine("Maximal value in sequence from 0 -> {0} at position {1} ", maxValue,MaxItemIndex(array,0,array.Length));
            Console.WriteLine();
            maxValue = MaxItem(array, 3,array.Length);
            Console.WriteLine("Maximal value in sequence from 3 -> {0} at position {1} ", maxValue, MaxItemIndex(array, 3,array.Length));
            Console.WriteLine();
            maxValue = MaxItem(array, 11,array.Length);
            Console.WriteLine("Maximal value in sequence from 11 -> {0} at position {1}", maxValue, MaxItemIndex(array, 11,array.Length));
            Console.WriteLine();
            maxValue = MaxItem(array, 13,array.Length);
            Console.WriteLine("Maximal value in sequence from 13 -> {0} at position {1}", maxValue, MaxItemIndex(array, 13,array.Length));

            Console.WriteLine();

            SortAscending(array);
            PrintArray(array);
            SortDescending(array);            
            PrintArray(array);
            
        }
    }

