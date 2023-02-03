using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBUI.VMClasses
{
    public class ShipperVM
    {
        public Shipper Shipper{ get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        
    }
}