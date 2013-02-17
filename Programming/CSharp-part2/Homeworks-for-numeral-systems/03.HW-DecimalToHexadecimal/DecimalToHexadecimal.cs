/*Write a program to convert decimal numbers to their hexadecimal representation.
*/
using System;
using System.Text;

    class DecimalToHexadecimal
    {
        static void Main(string[] args)
        {
            Console.Write("Enter any number: ");
            int number = int.Parse(Console.ReadLine());
            
            StringBuilder hexNumber = new StringBuilder();

            while (number > 0)
            {
                switch (number % 16)
                {
                    case 10:hexNumber.Append('A');break;
                    case 11:hexNumber.Append('B');break;
                    case 12:hexNumber.Append('C');break;
                    case 13:hexNumber.Append('D');break;
                    case 14:hexNumber.Append('E');break;
                    case 15:hexNumber.Append('F');break;
                    default:hexNumber.Append(number % 16);break;
                }
                number = number / 16;
            }
            string hexNumberEnd = hexNumber.ToString();
            Console.Write("Your number in hexadecimal format is: ");
            for (int i = hexNumberEnd.Length - 1; i >=0; i--)
            {
                Console.Write(hexNumberEnd[i]);
            }
            Console.WriteLine();
        }
    }

