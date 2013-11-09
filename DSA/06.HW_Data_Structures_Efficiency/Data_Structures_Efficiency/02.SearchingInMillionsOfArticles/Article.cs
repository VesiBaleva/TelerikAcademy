using System;
using System.Linq;

namespace _02.SearchingInMillionsOfArticles
{
    public class Article:IComparable<Article>
    {
        public string Barcode { get; set; }
        public string Vendor { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }

        public Article(string title, string vendor, string barcode, double price)
        {
            this.Barcode = barcode;
            this.Vendor = vendor;
            this.Title = title;
            this.Price = price;
        }

        public int CompareTo(Article other)
        {
            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            string str = string.Format(
                "Price: {0,10:F2}, Barcode: {1}, Vendor: {2}, Title: {3}",
                this.Price,
                this.Barcode,
                this.Vendor,
                this.Title);

            return str;
        }
    }
}
