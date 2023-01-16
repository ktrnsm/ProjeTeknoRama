using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class EmployeeTerritory:BaseEntity
    {
        public int EmployeeID { get; set; }
        public int TerritoryID { get; set; }

        //Relational Properties
        public virtual Employee Employee { get; set; }
        public virtual Territory Territory { get; set; }

    }
}
