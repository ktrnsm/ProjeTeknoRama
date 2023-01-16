using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Expense:BaseEntity
    {
        public Expense()
        {
            PaymentDate = DateTime.Now;
        }
        public decimal Amount { get; set; }
        public string Desciption { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
