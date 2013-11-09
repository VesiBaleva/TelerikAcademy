using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.EntityFrameworkModel
{
    public partial class Employee
    {
        private EntitySet<Territory> entityTerritories;

        public EntitySet<Territory> EntityTerritories
        {
            get
            {
                var employeeTeritories = this.Territories;
                EntitySet<Territory> entityTerritories = new EntitySet<Territory>();
                entityTerritories.AddRange(employeeTeritories);
                return entityTerritories;
            }
        }
    }
}
