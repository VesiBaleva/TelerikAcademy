/*Write a program that extracts from a given text all sentences containing given word.
		Example: The word is "in". The text is:
 *              We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight.
 *              So we are drinking all the day. We will move out of it in 5 days.
 * The expected result is:
 *              We are living in a yellow submarine.
*               We will move out of it in 5 days.
*/
using System;
using System.Text;

    class ExtractSentence
    {
        static void Main()
        {
            string str = "We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            string[] sentence = str.Split('.');
            string target="in";

            foreach (var item in sentence)
            {
                string[] words = item.Split(' ');
                foreach (var word in words)
                {
                    if (word.ToLower().Trim() == target)
                    {
                        Console.WriteLine("{0}.",item.Trim());
                        break;
                    }
                }                
            }
        }
    }

