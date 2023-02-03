using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Issue:BaseEntity
    {
        public Issue()
        {
            IssueStatus = IssueStatus.Open;
            OpenDate = DateTime.Now;
        }
        public string Subject { get; set; }
        public string Answer { get; set; }
        public IssueStatus IssueStatus { get; set; }
        public DateTime OpenDate { get; set; }
        public string Email { get; set; }
        public int? AppUserID { get; set; }

        //Relationsl Properties
        public virtual AppUser AppUser { get; set; }
    }
}
