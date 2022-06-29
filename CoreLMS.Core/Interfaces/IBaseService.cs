using CoreLMS.Persistence;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IBaseService<TEntity> where TEntity : class, IEntity
{
    TEntity MapFrom(IDto dto);
    Task AddAsync(IDto dto);
    Task AddAsync(TEntity entity);

    Task<TEntity> GetByIdAsync(int id);

    Task<List<TEntity>> GetAllAsync();

    Task DeleteByIdAsync(int id);

    Task UpdateAsync(IDto dto, int id);


}