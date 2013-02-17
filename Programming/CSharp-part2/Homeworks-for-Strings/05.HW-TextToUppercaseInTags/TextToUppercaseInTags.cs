/*You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase>
 * and </upcase> to uppercase. The tags cannot be nested. Example:
 * 
 *          We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.
*   The expected result:
 *   We are living in a YELLOW SUBMARINE. We don't have ANYTHING else.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class TextToUppercaseInTags
    {
        static void Main()
        {
            string str = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";
            Console.WriteLine("{0}", str);
            
            string strUp=String.Empty;

            string startTag = "<upcase>";
            string endTag = "</upcase>";

            int counter = 0;
            int positionStart = 0;
            int positionEnd = 0;
            
            bool isContaintEndTag = true;
            int position=0;

            StringBuilder result = new StringBuilder();

            while (isContaintEndTag)
            {
                positionStart = str.IndexOf(startTag, positionStart);
                
                if (positionStart > 0)
                {
                    result.Append(str.Substring(position,positionStart-position));
                    positionStart+=startTag.Length;
                    positionEnd = str.IndexOf(endTag, positionStart+1);
                    if (positionEnd > 0)
                    {
                        strUp=str.Substring(positionStart,positionEnd-positionStart).ToUpper();
                        result.Append(strUp);
                        position = positionEnd + endTag.Length;                        
                    }
                    else
                    {
                        result.Append(str.Substring(positionStart,str.Length-positionStart-startTag.Length));
                        isContaintEndTag = false;
                    }
                }
                else
                {
                    isContaintEndTag = false;
                }
                
            }
            result.Append(str.Substring(position,str.Length-position));
            Console.WriteLine("Result: {0}", result.ToString());
        }
    }

