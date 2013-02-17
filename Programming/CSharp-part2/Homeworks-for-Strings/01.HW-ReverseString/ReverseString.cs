/*Write a program that reads a string, reverses it and prints the result at the console.
Example: "sample"  "elpmas".
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class ReverseString
    {
        static StringBuilder Reverse(string str)
        {
            
            StringBuilder result=new StringBuilder();
            for (int i = str.Length-1; i >=0 ; i--)
			{
			    result.Append(str.Substring(i,1));
			}
            return result;
        }
        static void Main()
        {
            string str = "This is a book, a cat and a computer.";
            
            Console.WriteLine("{0}\n{1}",str,Reverse(str).ToString());
            Console.WriteLine();
            Console.WriteLine("Enter your word or frase: ");
            str = Console.ReadLine();
            Console.WriteLine("{0}\n{1}", str, Reverse(str).ToString());
        }
    }

