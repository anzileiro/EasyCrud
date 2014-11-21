using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EasyCrud.Repository
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> List(Expression<Func<T, T>> selector);
        void Insert(T model);
        T SearchById(int id);
        ICollection<T> SearchFor(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> selector);
        void Update(T model);
        void Remove(int id);
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, T>> selector);
        Task InsertAsync(T model);
        Task<T> SearchByIdAsync(int id);
        Task<ICollection<T>> SearchForAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> selector);
        Task UpdateAsync(T model);
        Task RemoveAsync(int id);
    }
}
