using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ExtractsStrOddNumsOfTimes
{
    public class StrOddNumsOfTimes
    {
        static void Main()
        {
            Console.WriteLine("Enter sequence:");
            string sequence = Console.ReadLine();

            Console.WriteLine("Dictionary<TKey,TValue>");
            Console.WriteLine("-----------------------");

            IDictionary<string, int> seqCount = new Dictionary<string, int>();

            seqCount = CountWordInSeq(sequence);

            PrintDict(seqCount);

            Console.Write("Extract words only odd times: ");

            PrintExtracts(seqCount);

            Console.WriteLine();
        }

        private static IDictionary<string, int> CountWordInSeq(string sequence)
        {
            IDictionary<string, int> seqCount = new Dictionary<string, int>();

            string[] words = sequence.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                int count = 1;

                if (seqCount.ContainsKey(word))
                {
                    count = seqCount[word] + 1;
                }

                seqCount[word] = count;
            }
            
            return seqCount; 
        }

        private static void PrintDict(IDictionary<string, int> seqCount)
        {
            foreach (var word in seqCount)
            {
                Console.WriteLine("{0} --> {1}", word.Key,word.Value);
            }
            Console.WriteLine();
        }

        private static void PrintExtracts(IDictionary<string, int> seqCount)
        {
            foreach (var word in seqCount)
            {
                if (!(word.Value % 2 == 0))
                {
                    Console.Write("{0}, ",word.Key);
                }
            }
        }
    }
}
