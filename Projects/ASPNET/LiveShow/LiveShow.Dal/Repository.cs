using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LiveShow.Dal
{
    internal class Repository<T> : IRepository<T>
        where T : class
    {
        private readonly DbSet<T> dbSet;
        private readonly ApplicationDbContext dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.FirstOrDefaultAsync(predicate);
        }

        public IAsyncEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Where(predicate).AsAsyncEnumerable();
        }

        public async Task AddAsync(params T[] entities)
        {
            await dbSet.AddRangeAsync(entities);

            await SaveChanges();
        }

        public async Task UpdateAsync(params T[] entities)
        {
            dbSet.UpdateRange(entities);

            await SaveChanges();
        }

        public async Task DeleteAsync(params T[] entities)
        {
            dbSet.RemoveRange(entities);

            await SaveChanges();
        }

        private async Task SaveChanges()
        {
            await dbContext.SaveChangesAsync();
        }



        //My Methods - not async
        public T Add(T itemToAdd)
        {
            var entity = dbContext.Set<T>().Add(itemToAdd);
            dbContext.SaveChanges();
            return entity.Entity;
        }

        public T GetById(Guid Id)
        {
            return dbContext.Set<T>()
                            .Find(Id);
        }

        public bool Delete(T itemToDelete)
        {
            dbContext.Remove<T>(itemToDelete);
            dbContext.SaveChanges();
            return true;
        }

        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>()
                           .AsEnumerable();
        }

        public T Update(T itemToUpdate)
        {
            var entity = dbContext.Update<T>(itemToUpdate);
            dbContext.SaveChanges();
            return entity.Entity;
        }
    }
}
