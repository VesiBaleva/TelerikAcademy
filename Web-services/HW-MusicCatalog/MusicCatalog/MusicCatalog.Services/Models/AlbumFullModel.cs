using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicCatalog.Services.Models
{
    public class AlbumFullModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<SongModel> Songs { get; set; }
    }
}