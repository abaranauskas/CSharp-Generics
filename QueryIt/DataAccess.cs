using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryIt
{
    public class EmployeeDb : DbContext
    {
        public DbSet<Employee> Employeess { get; set; }
    }

    public interface IReadoOnlyRepository<out T> : IDisposable
    {
        T FindById(int id);
        IQueryable<T> FindAll();
    }

    public interface IWriteoOnlyRepository<in T> : IDisposable
    {
        void Add(T newEntity);
        void Delete(T entity);
        int Commit();
    }

    public interface IRepository<T> : IReadoOnlyRepository<T>, IWriteoOnlyRepository<T>
    {
    }
        

    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {
        DbContext _ctx;
        DbSet<T> _set;

        public SqlRepository(DbContext ctx)
        {
            _ctx = ctx;
            _set = _ctx.Set<T>();
        }

        public void Add(T newEntity)
        {
            if (newEntity.IsValid())
            {
                _set.Add(newEntity);
            }

        }

        public int Commit()
        {
            return _ctx.SaveChanges();
        }

        public void Delete(T entity)
        {
            _set.Remove(entity);
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

        public IQueryable<T> FindAll()
        {
            return _set;
        }

        public T FindById(int id)
        {
            T entity = default(T);

            entity = _set.Find(id);

            return entity;
        }
    }
}
