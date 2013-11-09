using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CountWordsInFileAndOrder
{
    class CountAndOrderWordsFormFile
    {
        static void Main()
        {
            StreamReader reader = new StreamReader(@"../../words.txt");
            using (reader)
            {
                string text = reader.ReadToEnd();
                string textOnly = text.Substring(0, text.Length - 2);
                char[] separators = { ' ', '.', ',', '!', '?', '–' };
                string[] words = textOnly.ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries);

                IDictionary<string,int> wordsCount = new Dictionary<string,int>();

                wordsCount = CountWords(words);

                List<KeyValuePair<string, int>> sorted = new List<KeyValuePair<string, int>>();

                sorted = OrderedWordsByValue(wordsCount);

                PrintSortedWords(sorted);
            }
        }
        private static IDictionary<string, int> CountWords(string[] words)
        {
            IDictionary<string, int> wordsCount = new Dictionary<string, int>();

            foreach (var word in words)
            {
                int count = 1;
                if (wordsCount.ContainsKey(word))
                {
                    count = wordsCount[word] + 1;
                }
                wordsCount[word] = count;
            }

            return wordsCount;
        }

        private static List<KeyValuePair<string, int>> OrderedWordsByValue(IDictionary<string, int> wordsCount)
        {
            List<KeyValuePair<string, int>> sorted = wordsCount.ToList();

            sorted.Sort((firstPair, nextPair) =>
                {
                    return firstPair.Value.CompareTo(nextPair.Value);
                }
            );

            return sorted;
        }

        private static void PrintSortedWords(List<KeyValuePair<string, int>> sorted)
        {
            foreach (var pair in sorted)
            {
                Console.WriteLine("{0} --> {1}",pair.Key,pair.Value);
            }
        }

    }
}
