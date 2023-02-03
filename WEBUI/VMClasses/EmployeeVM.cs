using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBUI.VMClasses
{
    public class EmployeeVM
    {
        public Employee Employee { get; set; }
        public List<Employee> Employees { get; set; }
    }
}