using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Bookstore.Data;

namespace SimpleSearcherBook
{
    public static class simpleSearcherBook
    {
        static void Main()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../simple-query.xml");
            string authorname = xmlDoc.GetChildText("/query/author");
            string title = xmlDoc.GetChildText("/query/title");
            string isbn = xmlDoc.GetChildText("/query/isbn");
            var books =
                BookstoreDAL.FindBookByTitleAuthorOrISBN(authorname, title, isbn);
            if (books.Count > 0)
            {
                foreach (var book in books)
                {
                    Console.WriteLine("{0} books found:");
                    Console.WriteLine("{0} --> ", book.Title);
                }
            }
            else
            {
                Console.WriteLine("Nothing found");
            }
        }

        private static string GetChildText(
            this XmlNode node, string xpath)
        {
            XmlNode childNode = node.SelectSingleNode(xpath);
            if (childNode == null)
            {
                return null;
            }
            return childNode.InnerText.Trim();
        }
    }
}
