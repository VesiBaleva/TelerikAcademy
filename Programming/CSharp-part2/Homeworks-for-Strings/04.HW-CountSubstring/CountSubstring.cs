/*Write a program that finds how many times a substring is contained in a given text
 * (perform case insensitive search).
	Example: The target substring is "in". The text is as follows:
 * 
 * We are living in an yellow submarine. We don't have anything else. 
 * Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

  class CountSubstring
    {
        static void Main()
        {
            string str = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            Console.WriteLine("{0}",str);
            string strLower=str.ToLower();
            
            string subStr = "in";
            string subStrLower = subStr.ToLower();

            int counter=0;
            int position=0;
            bool isContain = true;

            while (isContain)
            {
                position = strLower.IndexOf(subStrLower, position);
                if (position > 0)
                {
                    counter++;
                }
                else
                {
                    isContain = false;
                }
                position++;
            }
            Console.WriteLine("Result: {0}",counter);
        }
    }

