/*Write a program that parses an URL address given in the format:
 * [protocol]://[server]/[resource]
and extracts from it the [protocol], [server] and [resource] elements. 
 * 
 * For example from the URL http://www.devbg.org/forum/index.php the following information should be extracted:
		[protocol] = "http"
		[server] = "www.devbg.org"
		[resource] = "/forum/index.php"
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class ParseAnURL
    {
        static void Main()
        {
            Uri address = new Uri("http://wwww.devbg.org/forum/index.php");
            string protocol = address.Scheme;
            string server = address.Host;
            string resource = address.LocalPath;
            Console.WriteLine("[protocol]={0}",protocol);
            Console.WriteLine("[server]={0}",server);
            Console.WriteLine("[resource]={0}",resource);          

        }
    }

