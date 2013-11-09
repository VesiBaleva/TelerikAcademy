using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.BuildATreeForFiles
{
    public class Folder
    {
        public string Name { get; set; }

        public List<File> Files { get; set; }

        public List<Folder> Folders { get; set; }

        public Folder(string name)
        {
            this.Name = name;
            this.Files = new List<File>();
            this.Folders = new List<Folder>();
        }

        public void AddFolder(Folder folder)
        {
            Folders.Add(folder);
        }

        public void AddFile(File file)
        {
            Files.Add(file);
        }

        public decimal GetSize()
        {
            decimal folderSize = 0;

            foreach (var file in Files)
            {
                folderSize += file.Size;
            }

            foreach (var folder in Folders)
            {
                decimal childSum = folder.GetSize();
                folderSize += childSum;
            }

            return folderSize;
        }
    }
}
