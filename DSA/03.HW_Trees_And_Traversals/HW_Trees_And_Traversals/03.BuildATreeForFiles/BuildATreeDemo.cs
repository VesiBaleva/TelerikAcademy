using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.BuildATreeForFiles
{
    public class BuildATreeDemo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("C:\\Windows directoy");

            Folder masterFolder = new Folder(@"C:\Windows");

            Folder copiedFileSystem = FolderUtils.CopyFileSystem(ref masterFolder);

            Console.WriteLine();
            Console.WriteLine("Cloning of C:\\Windows is finished.");

            Console.Write("Choose a sub folder to check it's size: ");
            string subFolder = Console.ReadLine();

            decimal folderSize = FolderUtils.FindFolder(masterFolder, subFolder).GetSize();

            Console.WriteLine("The folder size is {0:0.00}mb", folderSize.ToMegabytes());

            Console.WriteLine(masterFolder.Folders.Count);
        }
    }
}
