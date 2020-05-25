using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ForumRepository<T> : IRepository<T> where T : class
    {
        private readonly DBContext _dbctx;
        DbSet<T> _dbSet;

        public ForumRepository(DBContext dbctx)
        {
            _dbctx = dbctx;
            _dbSet = _dbctx.Set<T>();
        }

        public void Add(T model)
        {
            _dbSet.Add(model);
            _dbctx.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Remove(int id)
        {
            var model = _dbSet.Find(id);
            _dbSet.Remove(model);
            _dbctx.SaveChanges();
        }

        public void Update(T model)
        {
            _dbctx.Entry(model).State = EntityState.Modified;
            _dbctx.SaveChanges();
        }
    }
}
