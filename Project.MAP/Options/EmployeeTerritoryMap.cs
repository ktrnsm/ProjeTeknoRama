using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class EmployeeTerritoryMap:BaseMap<EmployeeTerritory>
    {
        public EmployeeTerritoryMap()
        {
            Ignore(x => x.ID);
            HasKey(x => new
            {
                x.EmployeeID,
                x.TerritoryID
            });
        }
    }
}
