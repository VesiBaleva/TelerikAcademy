/*Write a program to convert hexadecimal numbers to binary numbers (directly).
*/
using System;
using System.Text;
    class HexToBinary
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number in Hexadecimal bormat: ");
            string str = Console.ReadLine();
            str = str.ToUpper();
            StringBuilder resultBuilder = new StringBuilder();
            string result = "";
            for (int i = 0; i < str.Length; i++)
            {
                switch (str.Substring(i, 1))
                {
                    case "0": resultBuilder.Append("0000"); break;
                    case "1": resultBuilder.Append("0001"); break;
                    case "2": resultBuilder.Append("0010"); break;
                    case "3": resultBuilder.Append("0011"); break;
                    case "4": resultBuilder.Append("0100"); break;
                    case "5": resultBuilder.Append("0101"); break;
                    case "6": resultBuilder.Append("0110"); break;
                    case "7": resultBuilder.Append("0111"); break;
                    case "8": resultBuilder.Append("1000"); break;
                    case "9": resultBuilder.Append("1001"); break;
                    case "A": resultBuilder.Append("1010"); break;
                    case "B": resultBuilder.Append("1011"); break;
                    case "C": resultBuilder.Append("1100"); break;
                    case "D": resultBuilder.Append("1101"); break;
                    case "E": resultBuilder.Append("1110"); break;
                    case "F": resultBuilder.Append("1111"); break;
                    default: break;
                }
            }  
                result = resultBuilder.ToString();
                Console.WriteLine("Hex: {0} -> Binary: {1}", str, result);
                Console.WriteLine();
        }
    }



