using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreExample.Repository
{
    public interface IUnitOfWork<TContext> where TContext : DbContext
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : class;
        void SaveChanges();
    }

    public interface IRepository<T>
    {
        void Insert(T entity);
        void Delete(T entity);
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T GetById(int id);
    }

    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext: DbContext
    {
        private TContext _context;
        private Dictionary<string, object> _repositories;
        private IServiceProvider _provider;

        public UnitOfWork(TContext context, IServiceProvider provider)
        {
            _context = context;
            _repositories = new Dictionary<string, object>();
            _provider = provider;
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var type = typeof(TEntity);
            var repository = _repositories.GetValueOrDefault(type.ToString());
            if (repository == null) {
                repository = Activator.CreateInstance(typeof(Repository<TEntity>), _context);
                _repositories.Add(type.ToString(), repository);
            }
            return (IRepository<TEntity>)repository;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> _dbSet;

        public Repository(DbContext dataContext)
        {
            _dbSet = dataContext.Set<T>();
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }
    }
}
