using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicCatalog.Services.Models
{
    public class AlbumModel
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public string Producer { get; set; }

        public int Year { get; set; }
    }
}