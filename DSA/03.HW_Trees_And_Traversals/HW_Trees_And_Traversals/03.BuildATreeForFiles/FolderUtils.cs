using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.BuildATreeForFiles
{
    public static class FolderUtils
    {
        public static Folder CopyFileSystem(ref Folder directoryToSearch)
        {
            try
            {
                string[] allFilesInCurrentFolder = Directory.GetFiles(directoryToSearch.Name, "*.*");

                //Add the files to the folder
                for (int i = 0; i < allFilesInCurrentFolder.Length; i++)
                {
                    long sizeOfNewFile = new FileInfo(allFilesInCurrentFolder[i]).Length;
                    File newFile = new File(allFilesInCurrentFolder[i], sizeOfNewFile);

                    directoryToSearch.AddFile(newFile);
                }

                var foldersInCurrentDir = Directory.EnumerateDirectories(directoryToSearch.Name);

                foreach (var folder in foldersInCurrentDir)
                {
                    Folder newFolder = new Folder(folder);

                    directoryToSearch.AddFolder(newFolder);

                    CopyFileSystem(ref newFolder);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Directory {0} cannot be accessed", directoryToSearch.Name);
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Directory {0} does not exist.", directoryToSearch.Name);
            }

            return directoryToSearch;
        }

        public static Folder FindFolder(Folder folder, string folderName)
        {
            if (folder.Name == folderName)
            {
                return folder;
            }

            Folder findFolder = null;
            foreach (var child in folder.Folders)
            {
                if (findFolder == null)
                {
                    Folder currentFolder = FindFolder(child, folderName);
                    if (currentFolder != null)
                    {
                        findFolder = currentFolder;
                    }
                }
            }

            return findFolder;
        }

        public static decimal ToMegabytes(this decimal size)
        {
            return size / 1048576;
        }
    }
}
