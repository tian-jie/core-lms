using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoreLMS.Persistence
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// Gets all objects from database
        /// </summary>
        /// <returns></returns>
        Task<IQueryable<TEntity>> AllAsync();

        /// <summary>
        /// Gets objects from database by filter.
        /// </summary>
        /// <param name="predicate">Specified a filter</param>
        /// <returns></returns>
        Task<IQueryable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> predicate);

        ///////// <summary>
        ///////// Gets objects from database with filtering and paging.
        ///////// </summary>
        ///////// <param name="filter">Specified a filter</param>
        ///////// <param name="total">Returns the total records count of the filter.</param>
        ///////// <param name="index">Specified the page index.</param>
        ///////// <param name="size">Specified the page size</param>
        ///////// <returns></returns>
        //////Task<IQueryable<TEntity>> WhereAsync(Expression<Func<TEntity, bool>> filter, out int total, int index = 0, int size = 50);

        /// <summary>
        /// Gets the object(s) is exists in database by specified filter.
        /// </summary>
        /// <param name="predicate">Specified the filter expression</param>
        /// <returns></returns>
        Task<bool> ContainsAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Find object by keys.
        /// </summary>
        /// <param name="keys">Specified the search keys.</param>
        /// <returns></returns>
        Task<TEntity> FindAsync(params object[] keys);

        /// <summary>
        /// Find object by specified expression.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Create a new object to database.
        /// </summary>
        /// <param name="t">Specified a new object to create.</param>
        /// <returns></returns>
        Task CreateAsync(TEntity t);

        /// <summary>
        /// Delete the object from database.
        /// </summary>
        /// <param name="t">Specified a existing object to delete.</param>
        Task DeleteAsync(TEntity t);

        /// <summary>
        /// Delete objects from database by specified filter expression.
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<int> DeleteAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Update object changes and save to database.
        /// </summary>
        /// <param name="t">Specified the object to save.</param>
        /// <returns></returns>
        Task UpdateAsync(TEntity t);

        /// <summary>
        /// Select Single Item by specified expression.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression);
    }
}
