using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCinemaClient.Helpers
{
     public class ProjectionsNavigateArgs : EventArgs
        {
            public object VM { get; set; }

            public ProjectionsNavigateArgs(object vm)
                : base()
            {
                this.VM = vm;
            }
        }
}
