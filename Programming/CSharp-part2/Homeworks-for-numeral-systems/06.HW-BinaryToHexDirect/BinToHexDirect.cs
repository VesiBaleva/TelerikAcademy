/* Write a program to convert binary numbers to hexadecimal numbers (directly).
*/
using System;
using System.Text;

    class BinToHexDirect
    {
        static void Main()
        {
            Console.Write("Enter number in Binary bormat: ");
            string str = Console.ReadLine();
            
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 1; i <= 4-(str.Length%4); i++)
            {
                strBuilder.Append(0);
            }
            strBuilder.Append(str);
            string newStr = strBuilder.ToString();
            StringBuilder resultBuilder = new StringBuilder();
            string result = "";
            for (int i = 0; i < newStr.Length; i+=4)
            {
                switch (newStr.Substring(i, 4))
                {
                    case "0000": resultBuilder.Append("0"); break;
                    case "0001": resultBuilder.Append("1"); break;
                    case "0010": resultBuilder.Append("2"); break;
                    case "0011": resultBuilder.Append("3"); break;
                    case "0100": resultBuilder.Append("4"); break;
                    case "0101": resultBuilder.Append("5"); break;
                    case "0110": resultBuilder.Append("6"); break;
                    case "0111": resultBuilder.Append("7"); break;
                    case "1000": resultBuilder.Append("8"); break;
                    case "1001": resultBuilder.Append("9"); break;
                    case "1010": resultBuilder.Append("A"); break;
                    case "1011": resultBuilder.Append("B"); break;
                    case "1100": resultBuilder.Append("C"); break;
                    case "1101": resultBuilder.Append("D"); break;
                    case "1110": resultBuilder.Append("E"); break;
                    case "1111": resultBuilder.Append("F"); break;
                    default: break;
                }
            }
            result = resultBuilder.ToString();
            Console.WriteLine("Bin: {0} -> into Hex: {1}", str, result);
            Console.WriteLine();

        }
    }

