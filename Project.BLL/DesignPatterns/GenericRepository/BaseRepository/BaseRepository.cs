using Project.BLL.DesignPatterns.GenericRepository.IRepository;
using Project.BLL.DesignPatterns.SingletonPattern;
using Project.DAL.Context;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.BaseRepository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {

        MyContext _db;

        public BaseRepository()
        {
            _db = DBTool.DBInstance;
        }

        
public List<T> GetAll()
        
            throw new NotImplementedException();
        }

        public List<T> GetActives()
        {
            throw new NotImplementedException();
        }

        public List<T> GetPassives()
        {
            throw new NotImplementedException();
        }

        public List<T> GetModifieds()
        {
            throw new NotImplementedException();
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void AddRange(List<T> list)
        {
            throw new NotImplementedException();
        }

        public void Delete(T item)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(List<T> list)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(List<T> list)
        {
            throw new NotImplementedException();
        }

        public void Destroy(T item)
        {
            throw new NotImplementedException();
        }

        public void DestroyRange(List<T> item)
        {
            throw new NotImplementedException();
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public object Select(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public IQueryable<X> SelectViaClass<X>(Expression<Func<T, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public T Find(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetLastDatas(int number)
        {
            throw new NotImplementedException();
        }

        public List<T> GetFirstDatas(int number)
        {
            throw new NotImplementedException();
        }

        _db.SaveChanges();
        }


    }
}
