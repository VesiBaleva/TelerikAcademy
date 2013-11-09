using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _02.FindFirstProducts
{
    public class FindProducts
    {
        private static readonly Random getrandom = new Random();

        public static int GetRandomNumber(int min, int max)
        {
            return getrandom.Next(min, max);
        }

        public static void Main()
        {
            OrderedBag<Product> catalog = new OrderedBag<Product>();

            for (int i = 0; i < 500000; i++)
            {
                catalog.Add(new Product("Product" + i, GetRandomNumber(39,709)));
            }
            var prices = catalog.FindAll(x => x.Price > 200 && x.Price < 350);

            
            int count = 20;
            StringBuilder sb = new StringBuilder();
            foreach (var product in prices)
            {
                sb.AppendFormat("name: {0} -> price {1}", product.Name, product.Price);
                sb.AppendLine();
               
                count -= 1;
                if (count <= 0)
                {
                    break;
               }
            }
            Console.WriteLine("Print results: ");
            Console.WriteLine(sb.ToString());
        }

        
    }
}
