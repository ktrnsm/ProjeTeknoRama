using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Territory:BaseEntity
    {
        public string TerritoryDescription { get; set; }

        //Relational Properties
        public virtual List<EmployeeTerritory> EmployeeTerritories { get; set; }
    }
}
