/*Write a program to check if in a given expression the brackets are put correctly.
Example of correct expression: ((a+b)/5-d).
Example of incorrect expression: )(a+b)).
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CheckBracket
{

    static void Main()
    {
        Console.Write("Enter your expression: ");
        string input = Console.ReadLine();
        int bracketsCounter = 0;
        bool areCorrect = true;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '(')
            {
                bracketsCounter++;
            }
            else if (input[i] == ')')
            {
                bracketsCounter--;
                if (bracketsCounter < 0)
                {
                    areCorrect = false;
                    break;
                }
            }
        }

        if (bracketsCounter == 0)
        {
            areCorrect = true;
        }
        else
        {
            areCorrect = false;
        }

        Console.WriteLine("The brackets are put correctly: {0}", areCorrect);
    }

}