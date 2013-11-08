using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCinemaClient.Helpers
{
    public class MoviesNavigateArgs:EventArgs
    {
        public object VM { get; set; }

        public MoviesNavigateArgs(object vm)
            : base()
        {
            this.VM = vm;
        }
    }
}
