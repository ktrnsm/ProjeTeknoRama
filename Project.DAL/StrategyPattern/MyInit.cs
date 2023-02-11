using Project.DAL.Context;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Project.COMMON.Tools;
using System.Data.SqlTypes;
using Bogus.DataSets;
using System.Runtime.ExceptionServices;

namespace Project.DAL.StrategyPattern
{
    //The Strategy Pattern is a behavioral design pattern that allows you to define a set of algorithms, encapsulate them, and make them interchangeable. The key idea behind this pattern is to abstract behavior and encapsulate it into individual objects, known as strategies. The client code can then dynamically switch between different strategies based on the needs at runtime. This pattern promotes the open-closed principle, as new algorithms can be added without affecting the existing code, making it easier to maintain and extend.

    //The method creates new instances of several objects, including an "AppUser" object for an admin, a regular user, a branch manager, a sales representative, and a warehouse person. These objects are then added to the "AppUsers" and "Employees" DbSets in the database context. For each user, the user name, email, and hashed password are specified. The password is hashed using the "Crypto.HashPassword" method, which is probably a custom method for password hashing. The method also checks the password hash using "Crypto.VerifyPassword" method, which is probably a custom method for password verification, and throws an exception if the password verification fails. For each profile, various personal information such as first name, last name, age, gender, salary, etc. are specified and added to the "UserProfiles" DbSet in the database context. Finally, the method saves all changes to the database using the "SaveChanges" method.

    public class MyInit:CreateDatabaseIfNotExists<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            #region Admin
            AppUser admin = new AppUser
            {
                UserName = "admin",
                Email = "iktuerensemih@gmail.com",
                Password = Crypto.HashPassword("admin"),
                Role = ENTITIES.Enums.UserRole.Admin,
                Active = true,

            };

            if (!Crypto.VerifyPassword("admin", admin.Password))
            {
                throw new Exception("Failed to verify admin password");
            };

            context.AppUsers.Add(admin);
            context.SaveChanges();
            UserProfile adminProfile = new UserProfile
            {
                ID = admin.ID,
                FirstName = "Semih",
                LastName = "Iktueren",
                Age=38,
                Gender=ENTITIES.Enums.Gender.Male
            };
            context.UserProfiles.Add(adminProfile);
            context.SaveChanges();

            #endregion

            #region User
            AppUser user = new AppUser
            {
                UserName="FirstUser",
                Password=Crypto.HashPassword("FirstUser"),
                Email="iktuerensemih@proton.me",
                Role=ENTITIES.Enums.UserRole.Member,
                Active=true,
            };
            if(!Crypto.VerifyPassword("FirstUser", user.Password))
            {
                throw new Exception("Failed to verify user password");
            };
            context.AppUsers.Add(user);
            context.SaveChanges();

            UserProfile userProfile = new UserProfile
            {
                ID = user.ID,
                FirstName = "sem",
                LastName = "ktrn",
                Age = 24,
                Gender = ENTITIES.Enums.Gender.Male
            };
            #endregion

            #region BranchManager

            AppUser manager = new AppUser
            {
                UserName = "FirstBranchManager",
                Password = Crypto.HashPassword("FirstBranchManager"),
                Email = "iktuerensemih@proton.me",
                Role = ENTITIES.Enums.UserRole.BranchManager,
                Active = true
            };

            if (!Crypto.VerifyPassword("FirstBranchManager", user.Password))
            {
                throw new Exception("Failed to verify user password");
            }
            context.AppUsers.Add(manager);
            context.SaveChanges();

            Employee branchManager = new Employee
            {
                FirstName = "FirstBranch",
                LastName="Manager",
                Email = "iktuerensemih@proton.me",
                Role = ENTITIES.Enums.UserRole.Employee,
                PhoneNumber="0123456789",
                Gender=ENTITIES.Enums.Gender.Female,
                Salary=100
                
            };
            context.Employees.Add(branchManager);
            context.SaveChanges();

            #endregion

            #region Sales Presentative

            AppUser sale = new AppUser
            {
                UserName = "FirstSales",
                Password = Crypto.HashPassword("FirstSales"),
                Email = "iktuerensemih@proton.me",
                Role = ENTITIES.Enums.UserRole.SalesPerson,
                Active = true

            };
            if(!Crypto.VerifyPassword("FirstSales",user.Password))
            {
                throw new Exception("Failed to verfy SalePerson password");
            }
            context.AppUsers.Add(sale);
            context.SaveChanges();

            Employee sales = new Employee
            {
                FirstName="semih",
                LastName="ktrn",
                PhoneNumber="0123456789",
                Email="iktuerensemih@proton.me",
                Gender=ENTITIES.Enums.Gender.Male,
                MonthlySales=1500,
                Salary=100
                
            };
            context.Employees.Add(sales);
            context.SaveChanges();

            #endregion

            #region WareHouse
            AppUser wareHouse = new AppUser
            {
                UserName="FirstWareHouse",
                Password=Crypto.HashPassword("FirstWareHouse"),
                Email = "iktuerensemih@proton.me",
                Role=ENTITIES.Enums.UserRole.StockPerson,
                Active=true

            };
            if(!Crypto.VerifyPassword("FirstWareHouse",user.Password))
            {
                throw new Exception("Failed to verify StockPerson password");
            }
            context.AppUsers.Add(wareHouse);
            context.SaveChanges();

            Employee ware = new Employee
            {
                Email = "iktuerensemih@proton.me",
                Role=ENTITIES.Enums.UserRole.Employee,
                FirstName="ktrn",
                LastName="smh",
                PhoneNumber="0123456789",
                Gender=ENTITIES.Enums.Gender.Female,
                Salary=100
            };
            context.Employees.Add(ware);
            context.SaveChanges();

            #endregion

            #region Accounting
            AppUser account = new AppUser
            {
                UserName="FirstAccounter",
                Password=Crypto.HashPassword("FirstAccounter"),
                Email="iktuerensemih@proton.me",
                Role=ENTITIES.Enums.UserRole.AccountingPerson,
                Active=true
            };
            if(!Crypto.VerifyPassword("FirstAccounter", user.Password))
            {
                throw new Exception("Failed to verify Stock Person password");
            }
            context.AppUsers.Add(account);
            context.SaveChanges();

            Employee accounting = new Employee
            {
                FirstName = "ktrn",
                LastName = "smh",
                PhoneNumber = "0123456789",
                Gender = ENTITIES.Enums.Gender.Female,
                Salary = 100,
                Role=ENTITIES.Enums.UserRole.Employee
            };
            context.Employees.Add(accounting);
            context.SaveChanges();

            #endregion
            #region TechService

            AppUser tech = new AppUser
            {
                UserName="FirstTech",
                Password=Crypto.HashPassword("FirstTech"),
                Email="iktuerensemih@proton.me",
                Role=ENTITIES.Enums.UserRole.TechnicService,
                Active=true
            };
            if(!Crypto.VerifyPassword("FirstTech", user.Password))

            {
                throw new Exception("Failed to verify Stock Person password");
            }
            context.AppUsers.Add(tech);
            context.SaveChanges();

            Employee service = new Employee
            {
                Email="iktuerensemih@proton.me",
                Role=ENTITIES.Enums.UserRole.Employee,
                FirstName="ktrn",
                LastName="smh",
                PhoneNumber="0123456789",
                Gender=ENTITIES.Enums.Gender.NoWillToDeclerate,
                Salary=100
            };
            context.Employees.Add(service);
            context.SaveChanges();

            #endregion


            #region mobileSales
            AppUser mobile = new AppUser
            {
                UserName="FirstMobile",
                Password=Crypto.HashPassword("FirstMobile"),
                Email="iktuerensemih@proton.me",
                Role=ENTITIES.Enums.UserRole.MobileSalePerson,
                Active=true
            };

            if(!Crypto.VerifyPassword("FirstMobile", user.Password))
            {
                throw new Exception("Failed to verify Stock Person Password");
            }
            context.AppUsers.Add(mobile);
            context.SaveChanges();

            Employee mobileSales = new Employee
            {
                FirstName="ktrn",
                LastName="smh",
                Email="iktuerensemih@proton.me",
                Gender=ENTITIES.Enums.Gender.Other,
                Role=ENTITIES.Enums.UserRole.Employee

            };
            context.Employees.Add(mobileSales);
            context.SaveChanges();
            #endregion


            #region Fake Data

            for(int i=0;i<15;i++)
            {
                Category c = new Category
                {
                    CategoryName= new Commerce().Categories(1)[0],
                    Description= new Lorem().Sentence(15)
                };

                for(int j=0;j<20;j++)
                {
                    Product p = new Product
                    {
                        ProductName = new Commerce().ProductName(),
                        UnitPrice=Convert.ToDecimal(new Commerce().Price()),
                        UnitInStock=10,
                        ImangePatch=new Images().PicsumUrl(),
                    };

                    c.Products.Add(p);
                       
                }
                context.Categories.Add(c);
                context.SaveChanges();
            }

            #endregion




        }
    }
}
