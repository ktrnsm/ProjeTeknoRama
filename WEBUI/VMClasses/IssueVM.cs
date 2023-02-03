using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBUI.VMClasses
{
    public class IssueVM
    {
        public Issue Issue { get; set; }
        public List<Issue> Issues { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}