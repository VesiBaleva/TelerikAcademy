/* Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤  16).*/
using System;
using System.Text;

    class FromStoD
    {
        static int sToDecimal(string number,int s)
        {
                int sum = 0;
                for (int i = number.Length - 1; i >= 0; i--)
                {
                    switch (number[i])
                    {
                        case 'A': sum += 10 * (int)Math.Pow(s, number.Length - 1 - i); break;
                        case 'B': sum += 11 * (int)Math.Pow(s, number.Length - 1 - i); break;
                        case 'C': sum += 12 * (int)Math.Pow(s, number.Length - 1 - i); break;
                        case 'D': sum += 13 * (int)Math.Pow(s, number.Length - 1 - i); break;
                        case 'E': sum += 14 * (int)Math.Pow(s, number.Length - 1 - i); break;
                        case 'F': sum += 15 * (int)Math.Pow(s, number.Length - 1 - i); break;
                        case 'a': sum += 10 * (int)Math.Pow(s, number.Length - 1 - i); break;
                        case 'b': sum += 11 * (int)Math.Pow(s, number.Length - 1 - i); break;
                        case 'c': sum += 12 * (int)Math.Pow(s, number.Length - 1 - i); break;
                        case 'd': sum += 13 * (int)Math.Pow(s, number.Length - 1 - i); break;
                        case 'e': sum += 14 * (int)Math.Pow(s, number.Length - 1 - i); break;
                        case 'f': sum += 15 * (int)Math.Pow(s, number.Length - 1 - i); break;
                        default:
                            string digit = number[i].ToString();
                            sum += int.Parse(digit) * (int)Math.Pow(s, number.Length - 1 - i);
                            break;
                    }             
                }
                return sum;
        }
        
        static void decimalToD(int number,int d)
        {

            StringBuilder dNumber = new StringBuilder();

            while (number > 0)
            {
                switch (number % d)
                {
                    case 10: dNumber.Append('A'); break;
                    case 11: dNumber.Append('B'); break;
                    case 12: dNumber.Append('C'); break;
                    case 13: dNumber.Append('D'); break;
                    case 14: dNumber.Append('E'); break;
                    case 15: dNumber.Append('F'); break;
                    default: dNumber.Append(number % d); break;
                }
                number = number / d;
            }
            
            string dNumberEnd = dNumber.ToString();
            for (int i = dNumberEnd.Length - 1; i >= 0; i--)
            {
                Console.Write(dNumberEnd[i]);
            }
            Console.WriteLine();
        }
        
        static void Main()
        {
            Console.Write("Enter base system -> convert from: ");
            int s = int.Parse(Console.ReadLine());
            Console.Write("Enter base system -> convert to: ");
            int d = int.Parse(Console.ReadLine());
            Console.Write("Enter number for convertion: ");
            string number=Console.ReadLine();
            sToDecimal(number, s);
            decimalToD(sToDecimal(number, s), d);

        }
    }

