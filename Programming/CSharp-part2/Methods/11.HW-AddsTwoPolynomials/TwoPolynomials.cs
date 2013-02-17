/*Write a method that adds two polynomials.
 * Represent them as arrays of their coefficients as in the example below:
		x^2 + 5 = 1x^2 + 0x + 5  501
*/
using System;
using System.Text;

    class TwoPolynomials
    {
        static void PrintPolynomial(int[] arr)
        {
            StringBuilder polinom=new StringBuilder(); 
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] < 0)
                {
                    polinom.AppendFormat("{0}*x^{1}", arr[i], i);
                }
                else if (i == arr.Length - 1)
                {
                    polinom.AppendFormat("{0}*x^{1}", arr[i], i);
                }
                else
                {
                    polinom.AppendFormat("+{0}*x^{1}", arr[i], i);

                }
            }
            Console.WriteLine(polinom.ToString());                
        }

        static int[] Add(int[] arr1, int[] arr2)
        {

            int i = 0;

            int[] result = new int[Math.Max(arr1.Length, arr2.Length)];

            int currentDigit1 = 0;
            int currentDigit2 = 0;
            int currentTotal = 0;

            for (i = 0; i < Math.Max(arr1.Length, arr2.Length); i++)
            {
                if (i >= arr1.Length)
                {
                    currentDigit1 = 0;
                }
                else
                {
                    currentDigit1 = arr1[i];
                }
                if (i >= arr2.Length)
                {
                    currentDigit2 = 0;
                }
                else
                {
                    currentDigit2 = arr2[i];
                }

                currentTotal = currentDigit1 + currentDigit2;
                result[i] = currentTotal;
            }
            return result;
        }

        static int[] Subtract(int[] arr1, int[] arr2)
        {

            int i = 0;

            int[] result = new int[Math.Max(arr1.Length, arr2.Length)];

            int currentDigit1 = 0;
            int currentDigit2 = 0;
            int currentTotal = 0;

            for (i = 0; i < Math.Max(arr1.Length, arr2.Length); i++)
            {
                if (i >= arr1.Length)
                {
                    currentDigit1 = 0;
                }
                else
                {
                    currentDigit1 = arr1[i];
                }
                if (i >= arr2.Length)
                {
                    currentDigit2 = 0;
                }
                else
                {
                    currentDigit2 = arr2[i];
                }

                currentTotal = currentDigit1 - currentDigit2;
                result[i] = currentTotal;
            }
            return result;
        }

        public static int[] Multiply(int[] arr1, int[] arr2)
        {
            int[] result = new int[arr1.Length + arr2.Length - 1];

            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < arr2.Length; j++)
                {
                    result[i + j] += arr1[i] * arr2[j];
                }
            }
            return result;
        }

        static void Main()
        {
            Console.WriteLine("Adds two polynomials");
            int[] arr1 = { -2, 0, 3, 4 };
            PrintPolynomial(arr1);
            int[] arr2 = { 1, 2, 3, -4, 5, 6 };
            PrintPolynomial(arr2);
            int[] result = new int[Math.Max(arr1.Length, arr2.Length)];
            result = Add(arr1, arr2);
            PrintPolynomial(result);
            Console.WriteLine();

            Console.WriteLine("Subtract two polynomials");
            PrintPolynomial(arr1);
            PrintPolynomial(arr2);
            result = Subtract(arr1, arr2);
            PrintPolynomial(result);
            Console.WriteLine();

            Console.WriteLine("Multiply two polynomials");
            int[] resultMultiply = new int[arr1.Length+arr2.Length-1];
            resultMultiply = Multiply(new int[] { 2, 1 }, new int[] { 1, 1 });
            PrintPolynomial(new int[] { 2, 1 });
            PrintPolynomial(new int[] { 1, 1 });
            PrintPolynomial(resultMultiply);
            Console.WriteLine();
        }
    }

