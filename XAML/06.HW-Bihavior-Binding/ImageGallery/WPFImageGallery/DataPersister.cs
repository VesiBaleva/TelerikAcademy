using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WPFImageGallery
{
    public class DataPersister
    {
        public static IEnumerable<AlbumViewModel> GetAlbumsFromXml(string xmlPath)
        {
            XDocument doc = XDocument.Load(xmlPath);
            var root = doc.Root;
            var albums = root.Elements("album").AsQueryable().Select(AlbumViewModel.FromXElement);
            return albums;
        }
    }
}
