using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZtlModenaModel.Repositories;

namespace ZtlModenaService.Services
{
    public class BaseService<TEntity>(string connectionString) where TEntity : class
    {
        private BaseRepository<TEntity> _mainRepository = new(connectionString);

        public async Task<int> AddAsync(TEntity entity)
      => await _mainRepository.AddAsync(entity);

        public async Task<int> AddRangeAsync(List<TEntity> entities)
            => await _mainRepository.AddRangeAsync(entities);

        public async Task<int> UpdateAsync(TEntity entity)
            => await _mainRepository.UpdateAsync(entity);

        public async Task<int> UpdateRangeAsync(List<TEntity> entities)
            => await _mainRepository.UpdateRangeAsync(entities);

        public async Task<int> RemoveAsync(TEntity entity)
            => await _mainRepository.RemoveAsync(entity);

        public async Task<int> RemoveAllAsync(List<TEntity> entities)
            => await _mainRepository.RemoveAllAsync(entities);

        private protected async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null)
            => await _mainRepository.GetAsync(filter);

        private protected async Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null)
            => await _mainRepository.GetFirstOrDefaultAsync(filter);


    }
}
