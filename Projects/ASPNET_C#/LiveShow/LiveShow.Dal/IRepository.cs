using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LiveShow.Dal
{
    public interface IRepository<T>
        where T : class
    {
        Task AddAsync(params T[] entities);
        Task DeleteAsync(params T[] entities);
        IAsyncEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task UpdateAsync(params T[] entities);

        //My methods - not async
        IEnumerable<T> GetAll();
        T GetById(Guid Id);
        T Add(T itemToAdd);
        T Update(T itemToUpdate);
        bool Delete(T itemToDelete);
    }
}