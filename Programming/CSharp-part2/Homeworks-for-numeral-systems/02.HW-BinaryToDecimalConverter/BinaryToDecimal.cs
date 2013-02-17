/*Write a program to convert binary numbers to their decimal representation.
*/
using System;

    class BinaryToDecimal
    {
        static void Main()
        {
            Console.Write("Enter any number in binary: ");
            string numberInBin = Console.ReadLine();
            bool check = true;
            for (int i = 0; i < numberInBin.Length; i++)
            {
                if (Convert.ToInt32(numberInBin.Substring(i, 1)) > 1)
                {
                    Console.WriteLine("Your number is not in binary format!");
                    check = false;
                }
            }
            if (check == true)
            {
                int sum = 0;
                int product = 1;

                for (int i = numberInBin.Length - 1; i >= 0; i--)
                {
                    sum += Convert.ToInt32(numberInBin.Substring(i, 1)) * (int)Math.Pow(2, numberInBin.Length - 1 - i);
                }

                Console.WriteLine("{0}", sum);
            }
        }
    }

