using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicCatalog.Services.Models
{
    public class SongModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }

    }
}