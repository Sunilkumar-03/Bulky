using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repositories.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Bulky.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbSet<T> Db { set; get; }
        private ApplicationDbContext _Context;
        public Repository(ApplicationDbContext context)
        {
            _Context = context;
            Db = _Context.Set<T>();


            ;       }
        public void Add(T entity)
        {
            Db.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = Db;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = Db;
            return query.ToList();
        }

        public void Remove(T entity)
        {
            Db.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Db.RemoveRange(entities);
        }
    }
}
