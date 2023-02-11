using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.IRepository
// Interface for a generic repository for entities of type T that inherit from BaseEntity

{
    public interface IRepository<T> where T:BaseEntity
    {
        // Returns a list of all entities of type T

        List<T> GetAll();
        // Returns a list of all active entities of type T

        List<T> GetActives();
        // Returns a list of all passive entities of type T

        List<T> GetPassives();
        // Returns a list of all modified entities of type T

        List<T> GetModifieds();

        // Adds a single entity of type T to the repository

        void Add(T item);
        // Adds a list of entities of type T to the repository

        void AddRange(List<T> list);
        // Deletes a single entity of type T from the repository

        void Delete(T item);
        // Deletes a list of entities of type T from the repository

        void DeleteRange(List<T> list);
        // Updates a single entity of type T in the repository

        void Update(T item);
        // Updates a list of entities of type T in the repository

        void UpdateRange(List<T> list);
        // Destroys a single entity of type T in the repository
        void Destroy(T item);
        

        // Destroys a list of entities of type T in the repository

        void DestroyRange(List<T> item);

        // Returns a list of entities of type T that match the given expression

        List<T> Where(Expression<Func<T, bool>> exp);

        // Returns a boolean indicating if any entities of type T match the given expression

        bool Any(Expression<Func<T, bool>> exp);

        // Returns the first entity of type T that matches the given expression, or a default value if none are found

        T FirstOrDefault(Expression<Func<T, bool>> exp);

        // Returns an object representing the result of a query based on the given expression

        object Select(Expression<Func<T, bool>> exp);

        // Returns a queryable object of type X representing the result of a query based on the given expression

        IQueryable<X> SelectViaClass<X>(Expression<Func<T, bool>> exp);

        // Returns the entity of type T with the given id

        T Find(int id);

        // Returns a list of the last N entities of type T

        List<T> GetLastDatas(int number);

        // Returns a list of the first N entities of type T

        List<T> GetFirstDatas(int number);


    }
}
