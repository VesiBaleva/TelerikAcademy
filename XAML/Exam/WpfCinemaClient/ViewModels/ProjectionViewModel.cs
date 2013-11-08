using CinemaReserve.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCinemaClient.ViewModels
{
    public class ProjectionViewModel
    {
        public int Id {get;set;}

        public DateTime Time { get; set; }

        public IQueryable<MovieModel> Movie { get; set; }

        public IQueryable<CinemaModel> Cinema { get; set; }
    }
}
