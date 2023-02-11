using Project.DAL.Context;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.StrategyPattern
{
    //The Strategy Pattern is a behavioral design pattern that allows you to define a set of algorithms, encapsulate them, and make them interchangeable. The key idea behind this pattern is to abstract behavior and encapsulate it into individual objects, known as strategies. The client code can then dynamically switch between different strategies based on the needs at runtime. This pattern promotes the open-closed principle, as new algorithms can be added without affecting the existing code, making it easier to maintain and extend.

    public class MyInit:CreateDatabaseIfNotExists<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            #region Admin
            
            //todo
            #endregion
        }
    }
}
