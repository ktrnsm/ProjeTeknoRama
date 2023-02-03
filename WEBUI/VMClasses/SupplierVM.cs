using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBUI.VMClasses
{
    public class SupplierVM
    {
      public Supplier Supplier { get; set; }
      public List<Supplier> Suppliers { get; set; }

    }
}