/*Write a program that extracts from given HTML file its title (if available), and its body text without the HTML tags. Example:
            <html>
              <head><title>News</title></head>
              <body><p><a href="http://academy.telerik.com">Telerik
                Academy</a>aims to provide free real-world practical
                training for young people who want to turn into
                skillful .NET software engineers.</p></body>
           </html>
 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

    class ExtractTextWithOutHTMLTags
    {
        static void Main()
        {
            string text = string.Empty;
            using (var reader = new StreamReader("../../example.html"))
            {
                text = reader.ReadToEnd();
            }

            int startTag = text.IndexOf('<');
            int endTag = text.IndexOf('>');
            while (endTag > -1)
            {
                text = text.Remove(startTag, endTag - startTag + 1);
                startTag = text.IndexOf('<');
                endTag = text.IndexOf('>');
            }
            Console.WriteLine(text);
        }
    }
