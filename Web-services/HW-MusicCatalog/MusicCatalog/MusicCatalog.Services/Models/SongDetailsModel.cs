using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicCatalog.Services.Models
{
    public class SongDetailsModel
    {

        public string Title { get; set; }

        public int Year { get; set; }

        public string Genre { get; set; }

      //  public IQueryable<AlbumModel> Albums { get; set; }

    //    public IEnumerable<ArtistModel> Artists { get; set; }


        public string FromAlbum { get; set; }

        public string ArtistName { get; set; }
    }
}