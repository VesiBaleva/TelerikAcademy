using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _02.SearchingInMillionsOfArticles
{
    class SearchArticle
    {
        static void Main()
        {

            List<string[]> inputs = ReadData();
            OrderedMultiDictionary<double, Article> byPrice = new OrderedMultiDictionary<double, Article>(true);
            foreach (var input in inputs)
            {
                Article article = new Article(input[0], input[1], input[2], Convert.ToDouble(input[3]));
                byPrice.Add(article.Price, article);
            }

            Console.WriteLine("Print all articles");
            foreach (var item in byPrice)
            {
                Console.WriteLine(item.ToString());
            }

            OrderedMultiDictionary<double, Article>.View priceInRange = GetPriceRange(40, 90, byPrice);
            Console.WriteLine();
            Console.WriteLine("Print articles in range [40, 90]");
            foreach (var item in priceInRange)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static OrderedMultiDictionary<double, Article>.View GetPriceRange(double lowPrice, double highPrice, OrderedMultiDictionary<double, Article> byPrice)
        {
            return byPrice.Range(lowPrice, true, highPrice, true);
        }

        private static List<string[]> ReadData()
        {
            List<string[]> articles = new List<string[]>();

            string inputText;

            StreamReader sr = new StreamReader(@"../../articles.txt");
            using (sr)
            {
                while (sr.Peek() >= 0)
                {
                    inputText = sr.ReadLine();
                    var article = inputText.Split(new char[] { '|', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    articles.Add(article);
                }
            }

            return articles;
        }
    }
}
