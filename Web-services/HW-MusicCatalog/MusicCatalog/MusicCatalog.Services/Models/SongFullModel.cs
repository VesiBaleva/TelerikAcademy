using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicCatalog.Services.Models
{
    public class SongFullModel
    {
        public DateTime ArtistDateOfBird { get; set; }

        public string ArtistName { get; set; }

        public string AlbumTitle { get; set; }

        public int Year { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }
    }
}