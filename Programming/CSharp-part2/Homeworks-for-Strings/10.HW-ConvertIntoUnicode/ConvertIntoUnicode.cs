/*Write a program that converts a string to a sequence of C# Unicode character literals. Use format strings. Sample input:
    Hi!
 * Expected output:
        \u0048\u0069\u0021

 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class ConvertIntoUnicode
    {
        static void Main()
        {
            string word = "Hi!";
            StringBuilder resultBuild=new StringBuilder();
            for (int i = 0; i < word.Length; i++)
            {
                resultBuild.AppendFormat("\\u{0:x4}",(ushort)word[i]);
            }
            Console.WriteLine(resultBuild.ToString());
        }
    }

