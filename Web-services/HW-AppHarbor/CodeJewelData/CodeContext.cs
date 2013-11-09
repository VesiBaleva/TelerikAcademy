using CodeJewelModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJewelData
{
    public class CodeContext : DbContext
    {
        public CodeContext() :base("CodeDb")
        {
        }

        public DbSet<Vote> Votes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CodeJewel> CodeJewels { get; set; }

    }
}
