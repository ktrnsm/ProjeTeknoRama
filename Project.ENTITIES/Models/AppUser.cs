using Project.ENTITIES.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Project.ENTITIES.Models
{
    //The ENTITIES class is likely a namespace within a software application that contains model classes that define the structure of data objects used within the system. These classes are used to define the properties, fields, and relationships of data that will be stored and manipulated within the application. The ENTITIES classes represent the domain or business objects of the system and are typically used by the data access layer to interact with a database or other data storage mechanism. These classes may also be used in the presentation layer of the application to transfer data between different parts of the system.

    public class AppUser:BaseEntity
    {
        public AppUser()
        {
            Role = UserRole.Member;
            ActivationCode = Guid.NewGuid();
            
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public Guid ActivationCode { get; set; }
        public bool Active { get; set; }

        // Relational Properties

        public virtual UserProfile Profile { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<Issue> Issues { get; set; }

    
    }
    
}
