using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBUI.VMClasses
{
    public class MessageVM
    {
        public MessageVM Message { get; set; }
        public List<Message> Messages { get; set; }

    }
}