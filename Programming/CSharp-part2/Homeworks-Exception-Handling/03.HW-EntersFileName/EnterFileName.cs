/*Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini),
 * reads its contents and prints it on the console. 
 * Find in MSDN how to use System.IO.File.ReadAllText(…).
 * Be sure to catch all possible exceptions and print user-friendly error messages.
*/
using System;
using System.IO;

    class EnterFileName
    {
        static void Main()
        {
            try
            {
                string str = @"c:\windows\win.ini";
                string fileContent = File.ReadAllText(str);
                Console.WriteLine("The content of the file ->");
                Console.WriteLine();
                Console.WriteLine(fileContent);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The path contains directory that could not be found!");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("There isn't such a file!");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Wrong path!");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Empty path!");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("The entered file path is too long - 248 characters are the maximum!");
            }

            catch (UnauthorizedAccessException uae)
            {
                Console.WriteLine(uae.Message);
            }

            catch (System.Security.SecurityException)
            {
                Console.WriteLine("You don't have the required permission to access this file!");
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Invalid file path format!");
            }
            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
        }
    }

