/*Write a program that reads from the console a string of maximum 20 characters.
 * If the length of the string is less than 20, the rest of the characters should be filled with '*'. 
 * Print the result string into the console.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

  class FillString
    {
        static void Main()
        {
            Console.Write("Enter the string of maximum 20 characters: ");
            string input = Console.ReadLine();
            int maxLength = 20;
            if (input.Length <= maxLength)
            {
                string result = string.Empty;
                result = input.PadRight(maxLength, '*');
                Console.WriteLine("{0}", result);
            }
            else
            {
                Console.WriteLine("Your string is greater than 20 characters! Enter another string!");
            }
        }
    }

