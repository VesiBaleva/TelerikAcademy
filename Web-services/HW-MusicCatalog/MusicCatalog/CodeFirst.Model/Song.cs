using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Model
{
      public class Song
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public int Year { get; set; }
            public string Genre { get; set; }
            public int? ArtistId { get; set; }
            public virtual Artist Artist { get; set; }

            [ForeignKey("Album")]
            public int? AlbumId { get; set; }
            public virtual Album Album { get; set; }

        }
}
