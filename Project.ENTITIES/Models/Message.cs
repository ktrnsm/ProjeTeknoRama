using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    public class Message:BaseEntity
    {
        public Message()
        {

        }

        public string Subject { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public DateTime MessageDate { get; set; }
        public MessageType MessageType { get; set; }

        //Relational Properties
        public virtual AppUser AppUser { get; set; }
    }
}
