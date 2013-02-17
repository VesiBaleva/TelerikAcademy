/* You are given an array of strings. 
 * Write a method that sorts the array by the length of its elements (the number of characters composing them).
*/
using System;
using System.Linq;

    class SortsArray
    {
        static void order(string[] array)
        {
            //Using lambda expressions

            Array.Sort(array, (x,y)=>x.Length.CompareTo(y.Length) );
            foreach (var item in array)
            {
                Console.WriteLine(item);                
            }

        }
        static void Main()
        {
            string[] array = { "ivan", "petyo", "kirilovaaa", "tonchev", "toshev", "ivanov" };
            order(array);
        }
    }
