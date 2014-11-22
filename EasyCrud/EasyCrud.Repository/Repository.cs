using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EasyCrud.Repository
{
    public class Repository<T> : IRepository<T>, IDisposable
        where T : class
    {
        protected DbSet<T> _dbSet;
        protected DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        ~Repository()
        {
            Dispose(false);
        }

        public IEnumerable<T> List(Expression<Func<T, T>> selector)
        {
            return _dbSet.Select(selector).ToList();
        }

        public void Insert(T model)
        {
            _dbSet.Add(model);
            SaveChanges();
        }

        public T SearchById(int id)
        {
            return _dbSet.Find(id);
        }

        public ICollection<T> SearchFor(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> selector)
        {
            return _dbSet.Where(predicate).Select(selector).ToList();
        }

        public void Update(T model)
        {
            _context.Entry<T>(model).State = EntityState.Modified;
            SaveChanges();
        }

        public void Remove(int id)
        {
            var entity = _dbSet.Find(id);
            _dbSet.Remove(entity);
            SaveChanges();
        }

        public async Task<IEnumerable<T>> ListAsync(Expression<Func<T, T>> selector)
        {
            return await Task.Run(() => List(selector));
        }

        public async Task InsertAsync(T model)
        {
            await Task.Run(() => Insert(model));
            await SaveChangesAsync();
        }

        public async Task<T> SearchByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<ICollection<T>> SearchForAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> selector)
        {
            return await Task.Run(() => SearchFor(predicate, selector));
        }

        public async Task UpdateAsync(T model)
        {
            await Task.Run(() => _context.Entry<T>(model).State = EntityState.Modified);
            await SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            await Task.Run(() => _dbSet.Remove(entity));
            await SaveChangesAsync();
        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        }

        private async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}