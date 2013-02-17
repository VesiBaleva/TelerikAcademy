/*Write a program that reads an integer number and calculates and prints its square root.
 * If the number is invalid or negative, print "Invalid number". 
 * In all cases finally print "Good bye". Use try-catch-finally.
*/
using System;

    class UseTryCatchFinaly
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an integer number: ");

            try
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 0) throw new FormatException();               
                Console.WriteLine("Calculates square root-> {0}", Math.Sqrt(number));                
            }
            catch (FormatException)
            {

                Console.WriteLine("Invalid number");
            }
            catch (OverflowException)
            {

                Console.WriteLine("Invalid number");
            }
            finally
            {
                Console.WriteLine("Good bye!");
            }
        }
    }

