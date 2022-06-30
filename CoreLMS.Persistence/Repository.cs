using CoreLMS.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoreLMS.Persistence
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly IAppDbContext _unitOfWork;

        public Repository(IAppDbContext unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbSet = ((AppDbContext)unitOfWork).Set<TEntity>();
        }

        /// <summary>
        /// Gets all objects from database
        /// </summary>
        /// <returns></returns>
        public async Task<IQueryable<TEntity>> AllAsync()
        {
            return await Task.Run(() =>
            {
                return _dbSet.Where(a => true);
            });
        }

        /// <summary>
        /// Gets objects from database by filter.
        /// </summary>
        /// <param name="predicate">Specified a filter</param>
        /// <returns></returns>
        public virtual async Task<IQueryable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Run(() =>
            {
                return _dbSet.Where<TEntity>(predicate).AsQueryable<TEntity>();
            });
        }

        ///////// <summary>
        ///////// Gets objects from database with filtering and paging.
        ///////// </summary>
        ///////// <param name="filter">Specified a filter</param>
        ///////// <param name="total">Returns the total records count of the filter.</param>
        ///////// <param name="index">Specified the page index.</param>
        ///////// <param name="size">Specified the page size</param>
        ///////// <returns></returns>
        //////public virtual async Task<IQueryable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> filter, out int total, int index = 0,int size = 50)
        //////{
        //////    var resultSet = await Task.Run(() =>
        //////    {
        //////        var skipCount = index * size;
        //////        var resultSet = filter != null
        //////            ? _dbSet.Where<TEntity>(filter).AsQueryable()
        //////            : _dbSet.AsQueryable();
        //////        resultSet = skipCount == 0 ? resultSet.Take(size) : resultSet.Skip(skipCount).Take(size);
        //////        return resultSet.AsQueryable();
        //////    });
        //////    total = resultSet.Count();
        //////    return resultSet;
        //////}

        /// <summary>
        /// Gets the object(s) is exists in database by specified filter.
        /// </summary>
        /// <param name="predicate">Specified the filter expression</param>
        /// <returns></returns>
        public async Task<bool> ContainsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        /// <summary>
        /// Find object by keys.
        /// </summary>
        /// <param name="keys">Specified the search keys.</param>
        /// <returns></returns>
        public virtual async Task<TEntity> FindAsync(params object[] keys)
        {
            return await _dbSet.FindAsync(keys);
        }

        /// <summary>
        /// Find object by specified expression.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync<TEntity>(predicate);
        }

        /// <summary>
        /// Create a new object to database.
        /// </summary>
        /// <param name="t">Specified a new object to create.</param>
        /// <returns></returns>
        public virtual async Task CreateAsync(TEntity t)
        {
            await _dbSet.AddAsync(t);
            await ((DbContext)_unitOfWork).SaveChangesAsync();
        }

        /// <summary>
        /// Delete the object from database.
        /// </summary>
        /// <param name="t">Specified a existing object to delete.</param>
        public virtual async Task DeleteAsync(TEntity t)
        {
            await Task.Run(() =>
            {
                _dbSet.Remove(t);
            });
            await ((DbContext)_unitOfWork).SaveChangesAsync();
        }

        /// <summary>
        /// Delete objects from database by specified filter expression.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual async Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var objects = await WhereAsync(predicate);
            var db = (DbContext)_unitOfWork;
            await db.BulkDeleteAsync<TEntity>(objects);

            return 1;
        }

        /// <summary>
        /// Update object changes and save to database.
        /// </summary>
        /// <param name="t">Specified the object to save.</param>
        /// <returns></returns>
        public virtual async Task UpdateAsync(TEntity t)
        {
            await Task.Run(() =>
            {
                _dbSet.Update(t);
            });
            await ((DbContext)_unitOfWork).SaveChangesAsync();

            //try
            //{
            //    var entry = _dbContext.Entry(t);
            //    _dbSet.Attach(t);
            //    entry.State = EntityState.Modified;
            //}
            //catch (OptimisticConcurrencyException ex)
            //{
            //    throw ex;
            //}
        }

        /// <summary>
        /// Select Single Item by specified expression.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await FindAsync(expression);
        }
    }
}
