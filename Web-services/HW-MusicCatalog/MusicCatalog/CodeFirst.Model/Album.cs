using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Model
{
    public class Album
    {
        /// <summary>
        /// tyyfrtyftyfyt
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// hghjghjgj
        /// </summary>
        public string Title { get; set; }
        public int Year { get; set; }
        public string Producer { get; set; }
        public virtual ICollection<Artist> Artists {get; set;}
        public virtual ICollection<Song> Songs { get; set; }

        public Album()
        {
            this.Artists = new HashSet<Artist>();
            this.Songs = new HashSet<Song>();
        }

    }
}
