/*Write a program that encodes and decodes a string using given encryption key (cipher). 
 * The key consists of a sequence of characters. The encoding/decoding is done by performing XOR (exclusive or) 
 * operation over the first letter of the string with the first of the key, the second – with the second, etc. 
 * When the last key character is reached, the next is the first.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

   class EncodesAndDecodesString
    {
        static void Main()
        {
            Console.Write("Enter string: ");
            string str = Console.ReadLine();
            Console.Write("Enter cifer: ");
            string cifer = Console.ReadLine();
            int strLength = str.Length;
            int ciferLength = cifer.Length;
            string newCifer = string.Empty;
            if (ciferLength < strLength)
            {
                StringBuilder ciferBuild = new StringBuilder();
                ciferBuild.Append(cifer);
                while (newCifer.Length<strLength)
                {
                    for (int i = 0; i < ciferLength; i++)
                    {
                        if (newCifer.Length == strLength)
                            break;
                        ciferBuild.Append(cifer[i]);
                        newCifer = ciferBuild.ToString();
                    }                    
                }                
            }
            else
            {
                newCifer = cifer;
            }
            StringBuilder encode = new StringBuilder();
            for (int i = 0; i < strLength; i++)
            {
                encode.AppendFormat("{0:d4}",(ushort)(str[i])^(ushort)(newCifer[i]));   
            }
            Console.WriteLine("Encode -> {0}",encode.ToString());

            string encodeStr = encode.ToString();
            StringBuilder decode = new StringBuilder();
            for (int i = 0,p=0; i < strLength; i++,p+=4)
            {
                decode.AppendFormat("{0}", (char)(ushort.Parse(encodeStr.Substring(p,4)) ^ (ushort)(newCifer[i])));
            }
            Console.WriteLine("Decode -> {0}",decode.ToString());

        }
    }

