using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.MessagesInABottle
{
    class Program
    {
        static void Main(string[] args)
        {
            string code = Console.ReadLine();
            string cipher = Console.ReadLine();

            StringBuilder decode = new StringBuilder();
            
            List<KeyValuePair<string, string>> ciphers = new List<KeyValuePair<string, string>>();
            SortedSet<string> sorted = new SortedSet<string>();

            CreateDict(cipher, ciphers);
            Solve(decode,code,ciphers,sorted,0);

            Console.WriteLine(sorted.Count);
            foreach (var item in sorted)
            {
                Console.WriteLine(item);                
            }
        }
        static void Solve(StringBuilder decode, string code,List<KeyValuePair<string,string>> ciphers, SortedSet<string> sorted,int start)
        {

            if (start==code.Length)
            {
                sorted.Add(decode.ToString());
                return;
            }

            foreach (var cipher in ciphers)
            {
                if (code.Substring(start).StartsWith(cipher.Value))
                {
                    decode.Append(cipher.Key);
                    Solve(decode, code, ciphers, sorted, start+cipher.Value.Length);
                    decode.Length--;
                }
                
            }
        }

        static void CreateDict(string cipher, List<KeyValuePair<string,string>> ciphers)
        {
            string key=string.Empty;
            string value= string.Empty;

            for (int i = 0; i < cipher.Length; i++)
            {
                if ((cipher[i])>='A' && (cipher[i])<='Z')
                {
                    if (key != string.Empty)
                    {
                        ciphers.Add(new KeyValuePair<string,string>(key, value));
                        value = string.Empty;
                    }
                    
                    key = cipher[i].ToString();
                }
                else
                {
                    value += cipher[i].ToString();
                    
                }
            }

            if (key != string.Empty)
            {
                ciphers.Add(new KeyValuePair<string, string>(key, value));
                value = string.Empty;
            }

        }      
    }
}
