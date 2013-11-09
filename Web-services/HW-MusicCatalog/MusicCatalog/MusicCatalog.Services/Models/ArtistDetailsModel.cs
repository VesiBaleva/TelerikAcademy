using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicCatalog.Services.Models
{
    public class ArtistDetailsModel
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime DateOfBirth { get; set; }

        //  public IQueryable<AlbumModel> Albums { get; set; }

        //    public IEnumerable<ArtistModel> Artists { get; set; }


        public string AlbumName { get; set; }


        public IEnumerable<SongModel> Songs { get; set; }
    }
}