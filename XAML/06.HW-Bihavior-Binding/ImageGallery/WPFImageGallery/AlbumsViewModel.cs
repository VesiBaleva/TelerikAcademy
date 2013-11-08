using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace WPFImageGallery
{
    public class AlbumsViewModel
    {
        public ObservableCollection<AlbumViewModel> Albums { get; set; }
        
        public AlbumsViewModel()
        {
            var albums = DataPersister.GetAlbumsFromXml("..\\..\\Images.xml");
            if (this.Albums == null)
            {
                this.Albums = new ObservableCollection<AlbumViewModel>();

                foreach (var album in albums)
                {
                    this.Albums.Add(album);
                }
            }
        }

        public ICommand Load { get; set; }

    }
}
