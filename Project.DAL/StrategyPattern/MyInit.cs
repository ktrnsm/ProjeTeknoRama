using Project.DAL.Context;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.StrategyPattern
{
    public class MyInit:CreateDatabaseIfNotExists<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            #region Admin
            AppUser admin = new AppUser
            {
                UserName="admin",
                Email="iktuerensemih@gmail.com",
                Password= Pass
                


            };

            #endregion
        }
    }
}
