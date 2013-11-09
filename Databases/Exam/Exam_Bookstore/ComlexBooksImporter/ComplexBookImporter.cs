using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Xml;
using Bookstore.Data;

public static class ComplexBookImporter
{
    static void Main()
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("../../MoreBooks.xml");
        string xPathQuery = "/catalog/book";

        XmlNodeList booksList = xmlDoc.SelectNodes(xPathQuery);
        foreach (XmlNode bookNode in booksList)
        {
            XmlNodeList authorsNode = bookNode.SelectSingleNode("authors").SelectNodes("author");
            List<string> authors = new List<string>();
            foreach (XmlNode authorN in authorsNode)
            {
                authors.Add(authorN.GetChildAuthorText("author"));    
            }
            
            string title = bookNode.GetChildText("title");
            string isbn = bookNode.GetChildText("isbn");
            string price = bookNode.GetChildText("price");
            string website = bookNode.GetChildText("web-site");

            XmlNodeList reviewsNode = bookNode.SelectSingleNode("reviews").SelectNodes("review");
            List<Review> reviews = new List<Review>();
            foreach (XmlNode reviewN in reviewsNode)
            {
                
            }

            BookstoreDAL.AddBookComplex(authors, title, isbn, price, website);

        }


    }

    
    private static string GetChildText(this XmlNode node, string tagName)
    {
        XmlNode childNode = node.SelectSingleNode(tagName);
        if (childNode == null)
        {
            return null;
        }
        return childNode.InnerText.Trim();
    }

    private static string GetChildAuthorText(this XmlNode node, string tagName)
    {
        XmlNode childNode = node;
        if (childNode == null)
        {
            return null;
        }
        return childNode.InnerText.Trim();
    }

  //private static Review GetChildReviewText(XmlNode node)
  //{
  //    XmlNode childNode = node;
  //    if (childNode == null)
  //    {
  //        return null;
  //    }
  //    return childNode.InnerText.Trim();
  //}

  // private static string GetChildInnerText(this XmlNode node, string tagName)
  // {
  //     string childNode = node[tagName].Value;
  //     if (childNode==null)
  //     {
  //         return null;
  //     }
  //     return childNode.Trim();
  // }
}
