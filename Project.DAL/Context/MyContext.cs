using Project.DAL.StrategyPattern;
using Project.ENTITIES.Models;
using Project.MAP.Options;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Context
{
    //This is a class definition for a DbContext class named MyContext. The class inherits from the DbContext class in the Entity Framework and is used as a bridge between the application and the database.
    //The constructor for this class sets the name of the database connection string to "MyConnection" and initializes it with a custom database initializer MyInit.
    //The OnModelCreating method is used to add configurations for different entities (AppUser, Category, Employee, Order, etc.). This method is used to define the relationship between the entities and their corresponding tables in the database.
    //The class also defines several DbSet properties, one for each of the entities defined in the model. These properties represent the sets of entities stored in the database and are used to interact with the data stored in the database.

    public class MyContext:DbContext
    {
        public MyContext():base("MyConnection")
        {
            Database.SetInitializer(new MyInit());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Adding entity maps to the model builder
            modelBuilder.Configurations.Add(new AppUserMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new EmployeeTerritoryMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());
            modelBuilder.Configurations.Add(new MessageMap());
            modelBuilder.Configurations.Add(new ExpenseMap());
            modelBuilder.Configurations.Add(new IssueMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ShipperMap());
            modelBuilder.Configurations.Add(new SupplierMap());
            modelBuilder.Configurations.Add(new TerritoryMap());
            modelBuilder.Configurations.Add(new UserProfileMap());


        }

        // Entity Sets
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Territory> Territories { get; set; }


    }
}
