/* Write a boolean expression that checks for given integer 
 * if it can be divided (without remainder) by 7 and 5 in the same time.*/
using System;

    class BooleanExprForDiv5and7
    {
        static void Main()
        {
            Console.Write("Enter your integer number: ");
            int number = int.Parse(Console.ReadLine());
            if (number % 5 == 0 && number % 7 == 0)
            {
                Console.WriteLine("Boolean Expression that checks {0} can be divided by 7 and 5 in the same time is True!", number);
            }
            else
            {
                Console.WriteLine("Boolean Expression that checks {0} can be divided by 7 and 5 in the same time is False!",number);
            }
        }
    }

