using CoreLMS.Application.Validators;
using CoreLMS.Core;
using CoreLMS.Core.Interfaces;
using CoreLMS.Persistence;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoreLMS.Application.Services
{
    public partial class BaseService<TEntity> : IBaseService<TEntity> where TEntity: class, IEntity, new()
    {   
        internal readonly IRepository<TEntity> _repository;
        internal readonly ILog _logger = LogManager.GetLogger(typeof(BaseService<TEntity>));
        IAppDbContext _unitOfWork;

        public IAppDbContext UnitOfWork
        {
            get
            {
                return _unitOfWork;
            }
        }

        public BaseService(IAppDbContext unitOfWork)
        {
            _repository = new Repository<TEntity>(unitOfWork);
            _unitOfWork = unitOfWork;
        }

        public virtual TEntity MapFrom(IDto dto)
        {
            var mapper = AutoMapperInstance.GetMapper();
            return mapper.Map<TEntity>(dto);
        }

        public virtual async Task AddAsync(IDto dto)
        {
            try
            {
                this.ValidateOnCreate(dto);
            }
            catch (Exception ex)
            {
                _logger.Error("Attempted to add invalid record.", ex);
                throw;
            }

            var entity = MapFrom(dto);

            await _repository.CreateAsync(entity);
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            try
            {
                this.ValidateOnCreate(entity);
            }
            catch (Exception ex)
            {
                _logger.Error("Attempted to add invalid record.", ex);
                throw;
            }


            await _repository.CreateAsync(entity);
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _repository.FindAsync(a => a.Id == id);

            // TODO Test logging / exception logging for efficiency //
            if (entity == null)
            {
                _logger.Warn($"Entity with Id [{id}] not found.");
                throw new ApplicationException($"Entity with Id [{id}] not found.");
            }

            return entity;
        }

        public async Task<List<TEntity>> GetAllAsync() => (await _repository.AllAsync()).ToList();

        public async Task DeleteByIdAsync(int id)
        {
            //var author = await _repository.FindAsync(a=>a.Id == id);

            //// TODO Add test case for invalid course/author/etc. on deletion attempt //
            //if (author == null)
            //{
            //    _logger.LogWarning($"Author {id} not found for deletion.");
            //    throw new ApplicationException($"Author {id} not found for deletion.");
            //}

            await _repository.DeleteAsync(a => a.Id == id);
        }

        public async Task DeleteRangeAsync(Expression<Func<TEntity, bool>> predicate)
        {
            await _repository.DeleteAsync(predicate);
        }

        public async Task UpdateAsync(IDto dto, int id)
        {
            try
            {
                this.ValidateOnUpdate(dto);
            }
            catch (Exception ex)
            {
                _logger.Error("Attempted to add invalid entity.", ex);
                throw;
            }

            var entity = MapFrom(dto);
            await _repository.UpdateAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity, int id)
        {
            try
            {
                this.ValidateOnUpdate(entity);
            }
            catch (Exception ex)
            {
                _logger.Error("Attempted to add invalid entity.", ex);
                throw;
            }

            await _repository.UpdateAsync(entity);
        }





        internal virtual void ValidateOnCreate(object obj)
        {
            ModelValidator.ValidateModel(obj);
        }

        internal virtual void ValidateOnUpdate(object obj)
        {
            ModelValidator.ValidateModel(obj);
        }
    }
}
