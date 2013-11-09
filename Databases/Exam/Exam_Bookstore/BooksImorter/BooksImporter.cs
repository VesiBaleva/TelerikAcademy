using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Transactions;
using Bookstore.Data;
using System.Threading;

public static class BooksImporter
{
    static void Main()
    {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../BooksData.xml");
            string xPathQuery = "/catalog/book";

            XmlNodeList booksList = xmlDoc.SelectNodes(xPathQuery);
            foreach (XmlNode bookNode in booksList)
            {
                string author = bookNode.GetChildText("author");
                string title = bookNode.GetChildText("title");
                string isbn = bookNode.GetChildText("isbn");
                string price = bookNode.GetChildText("price");
                string website = bookNode.GetChildText("web-site");
                TransactionScope tran = new TransactionScope(
                TransactionScopeOption.Required,
                   new TransactionOptions()
                   {
                       IsolationLevel = IsolationLevel.RepeatableRead
                   });
                using (tran)
                {
                    BookstoreDAL.AddBook(author, title, isbn, price, website);

                    tran.Complete();
                }

            }
            
        
    }

    private static string GetChildText(this XmlNode node, string tagName)
    {
        XmlNode childNode = node.SelectSingleNode(tagName);
        if (childNode == null) {
            return null;
        }
        return childNode.InnerText.Trim();
    }
}
