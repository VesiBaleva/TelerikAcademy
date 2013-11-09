using System;
using System.Linq;
using System.IO;

namespace _02.TraverseTheDirectory
{
    class TraverseDir
    {
        static void Main(string[] args)
        {
            string searchInDirectory = @"C:\Windows";
            string mask = @"*.exe";

            ShowFiles(mask, searchInDirectory);      
        }

        public static void ShowFiles(string mask, string searchInDirectory)
        {
            try
            {
                string[] filesInCurrentDirectory = Directory.GetFiles(searchInDirectory, mask);

                foreach (var file in filesInCurrentDirectory)
                {
                    Console.WriteLine(file);
                }

                string[] currentDirectory = Directory.GetDirectories(searchInDirectory);

                foreach (var directory in currentDirectory)
                {
                    ShowFiles(mask,directory);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("The Directory can not be accessed!");
                return;
            }

        }
    }
}
