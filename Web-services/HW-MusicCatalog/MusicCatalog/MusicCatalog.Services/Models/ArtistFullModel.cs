using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicCatalog.Services.Models
{
    public class ArtistFullModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}