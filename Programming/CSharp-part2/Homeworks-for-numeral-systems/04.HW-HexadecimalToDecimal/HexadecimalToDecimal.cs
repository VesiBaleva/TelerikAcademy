/*Write a program to convert hexadecimal numbers to their decimal representation.
*/
using System;
using System.Text;
    class HexadecimalToDecimal
    {
        static void Main(string[] args)
        {
            StringBuilder hexNumber = new StringBuilder();

            Console.Write("Enter any number in hexadecimal: ");
            string numberInHex = Console.ReadLine();

                int sum = 0;

                for (int i = numberInHex.Length - 1; i >= 0; i--)
                {
                    switch (numberInHex[i])
                    {
                        case 'A': sum += 10 * (int)Math.Pow(16, numberInHex.Length - 1 - i); break;
                        case 'B': sum += 11 * (int)Math.Pow(16, numberInHex.Length - 1 - i); break;
                        case 'C': sum += 12 * (int)Math.Pow(16, numberInHex.Length - 1 - i); break;
                        case 'D': sum += 13 * (int)Math.Pow(16, numberInHex.Length - 1 - i); break;
                        case 'E': sum += 14 * (int)Math.Pow(16, numberInHex.Length - 1 - i); break;
                        case 'F': sum += 15 * (int)Math.Pow(16, numberInHex.Length - 1 - i); break;
                        case 'a': sum += 10 * (int)Math.Pow(16, numberInHex.Length - 1 - i); break;
                        case 'b': sum += 11 * (int)Math.Pow(16, numberInHex.Length - 1 - i); break;
                        case 'c': sum += 12 * (int)Math.Pow(16, numberInHex.Length - 1 - i); break;
                        case 'd': sum += 13 * (int)Math.Pow(16, numberInHex.Length - 1 - i); break;
                        case 'e': sum += 14 * (int)Math.Pow(16, numberInHex.Length - 1 - i); break;
                        case 'f': sum += 15 * (int)Math.Pow(16, numberInHex.Length - 1 - i); break;
                        default:
                            string digit = numberInHex[i].ToString();
                            sum += int.Parse(digit) * (int)Math.Pow(16, numberInHex.Length - 1 - i);
                            break;
                    }              
                }
                Console.WriteLine("{0}", sum);            
        }
    }

