using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DTO
{
    //DTO stands for Data Transfer Object, which is a plain old data structure used to transport data between different layers of an application, such as between the UI and business logic layers. It's a simple, lightweight class that holds data without any behavior. The purpose of a DTO is to allow data to be passed between different parts of an application without exposing the underlying implementation details of the data or its storage. By using DTO classes, it's possible to decouple the different parts of the application and make them more loosely coupled and easier to maintain and modify.

    public class PaymentDTO
    {
        public int ID { get; set; }
        public string CardUserName { get; set; }
        public string CardNumber { get; set; }
        public string SecurityNumber { get; set; }
        public int CardExpiryMonth { get; set; }
        public int CardEXpiryYear { get; set; }
        public decimal ShoppingPrice { get; set; }
    }
}
