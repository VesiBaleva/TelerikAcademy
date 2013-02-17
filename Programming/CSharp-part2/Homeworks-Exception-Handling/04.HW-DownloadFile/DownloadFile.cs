/*Write a program that downloads a file from Internet (e.g. http://www.devbg.org/img/Logo-BASD.jpg) 
 * and stores it the current directory. Find in Google how to download files in C#. 
 * Be sure to catch all exceptions and to free any used resources in the finally block.
*/
using System;
using System.Net;

    class DownloadFile
    {
        static void Main()
        {
            using (WebClient webClient = new WebClient())
            {
                string hyperlink="http://www.devbg.org/img/Logo-BASD.jpg";
                string logo = "../../Logo-BASD.jpg";
                try
                {
                    webClient.DownloadFile(hyperlink, logo);
                    Console.WriteLine("The file was downloaded in the Debug folder of the project!");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("There isn't such URL");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("The web address name is emty!");
                }
                catch (WebException)
                {
                    Console.WriteLine("Invalid URL!");
                }
                catch (NotSupportedException)
                {

                    Console.WriteLine("The Method Have Out Of Range!");
                }
                
            }
        }
    }

