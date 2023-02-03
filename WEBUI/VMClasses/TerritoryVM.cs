using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBUI.VMClasses
{
    public class TerritoryVM
    {
        public Territory Territory { get; set; }
        public List<Territory> Territories { get; set; }
    }
}