using Project.BLL.DesignPatterns.GenericRepository.IRepository;
using Project.BLL.DesignPatterns.SingletonPattern;
using Project.DAL.Context;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.BaseRepository

//The Base Repository is a class that provides common functionality for interacting with data in a database. It acts as a layer between the data access code and the business logic, helping to decouple the two and simplify the code. The Base Repository class is used as a blueprint for other repository classes and typically includes methods such as Create, Read, Update, and Delete (CRUD) operations. This allows for a consistent way of accessing and manipulating data in the database, making it easier to maintain and update code in the future.
{
    // This class is implementing the IRepository interface and implementing its functions 
    // for performing various operations on the Entity provided as a generic argument
    public abstract class BaseRepository<T>:IRepository<T>where T:BaseEntity
    {

        // Member variable to store the context of the database
        MyContext _db;

        // Constructor to initialize the database context

        public BaseRepository()
        {
            _db = DBTool.DBInstance;
        }

        // Function to save the changes made to the database context

        void Save()
        {
            _db.SaveChanges();
        }
        // Function to add a single item to the database

        public void Add(T item)
        {
            // Adding the item to the context

            _db.Set<T>().Add(item);
            // Saving the changes to the database

            Save();
        }
        // Function to add a range of items to the database

        public void AddRange(List<T> item)
        {
            // Adding the list of items to the context

            _db.Set<T>().AddRange(item);

            // Saving the changes to the database

            Save();
        }
        // Function to check if there is any item in the database that matches the given expression

        public bool Any(Expression<Func<T, bool>> exp)
        {
        return  _db.Set<T>().Any(exp);
        }
        // Function to mark an item as deleted in the database

        public void Delete(T item)
        {
            // Updating the status of the item to Deleted

            item.Status = ENTITIES.Enums.DataStatus.Deleted;
            // Setting the DeletedDate to the current date and time

            item.DeletedDate = DateTime.Now;
            // Saving the changes to the database

            Save();
        }
        // Function to mark a range of items as deleted in the database

        public void DeleteRange(List<T> item)
        {
            // Iterating over the list of items and marking each one as deleted

            foreach (T element in item)
            {
                Delete(element);
            }
        }
        // Function to permanently remove an item from the database

        public void Destroy(T item)
        {
        // Removing the item from the context

            _db.Set<T>().Remove(item);

            // Saving the changes to the database

            Save();
        }
        // Function to permanently remove a range of items from the database

        public void DestroyRange(List<T> item)
        {
            foreach(T element in item)
            {
                Destroy(element);

            }
        }

        //This method takes an ID as a parameter and returns the entity object with that ID from the database.
        public T Find(int id)
        {
            return _db.Set<T>().Find(id);

        }
        //This method takes an expression as a parameter and returns the first entity object that matches the expression from the database. If no match is found, it returns null

        public T FirstOrDefault(Expression<Func<T,bool>> exp)
        {
            return _db.Set<T>().FirstOrDefault(exp);
        }
        //This method returns a list of all entity objects in the database whose status is not "Deleted"

        public List<T> GetActives()
        {
            return Where (x => x.Status != ENTITIES.Enums.DataStatus.Deleted);
        }
        //This method returns a list of all entity objects in the database.
        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }
        //This method returns a list of entity objects in the database whose status is "Deleted".

        public List<T>GetModifieds()
        {
            
            return Where(x=>x.Status==ENTITIES.Enums.DataStatus.Deleted);
        }

        //This method returns a list of entity objects in the database whose status is "Deleted".

        public List<T>GetPassives()
        {
            return Where(x => x.Status == ENTITIES.Enums.DataStatus.Deleted);
        }
        //This method takes an expression as a parameter and returns a list of values selected from the entity objects in the database based on the expression.
        public object Select(Expression<Func<T,object>> exp)
        {
            return _db.Set<T>().Select(exp).ToList();
        }

        //This method takes an entity object as a parameter, updates its modified date and status, finds the corresponding entity object in the database and updates its values with the new values from the input entity object.
        public void Update(T item)
        {
            item.ModifiedDate = DateTime.Now;
            item.Status = ENTITIES.Enums.DataStatus.Updated;
            T toBeUpdated = Find(item.ID);
            _db.Entry(toBeUpdated).CurrentValues.SetValues(item);
            Save();
        }

        // This method takes a list of entity objects as a parameter and updates each item by calling the Update method.

        public void UpdateRange(List<T> item)
        {
            foreach(T element in item)
            {
                Update(element);
            }
        }

        //This method takes an expression as a parameter and returns a list of entity objects from the database that match the expression.

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Where(exp).ToList();        }

        public object Select(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }
        //This method is not implemented and throws a NotImplementedException if called.
        public IQueryable<X> SelectViaClass<X>(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }
        //This method is not implemented and throws a NotImplementedException if called.
        public List<T> GetLastDatas(int number)
        {
            throw new NotImplementedException();
        }
        //This method is not implemented and throws a NotImplementedException if called.
        public List<T> GetFirstDatas(int number)
        {
            throw new NotImplementedException();
        }
    }
}
