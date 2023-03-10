using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class OrderDetail:BaseEntity
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public short Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        //Relational Properties
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
