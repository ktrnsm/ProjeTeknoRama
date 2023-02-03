using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBUI.VMClasses
{
    public class EmployeeTerritoryVM
    {
        public EmployeeTerritory EmployeeTerritory { get; set; }
        public Employee Employee { get; set; }
        public List<EmployeeTerritory> EmployeeTerritories { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Territory> Territories { get; set; }

    }
}