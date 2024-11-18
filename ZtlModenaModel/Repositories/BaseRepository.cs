using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZtlModenaModel.Model;

namespace ZtlModenaModel.Repositories
{
    public class BaseRepository<TEntity>(string connectionString) where TEntity : class
    {
        private readonly string _connectionString = connectionString;

        public async Task<int> AddAsync(TEntity entity)
        {
            using XparkingContext DB = new(_connectionString);

            DB.Add(entity);
            return await DB.SaveChangesAsync();
        }

        public async Task<int> AddRangeAsync(List<TEntity> entities)
        {
            using XparkingContext DB = new(_connectionString);

            DB.AddRange(entities);
            return await DB.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            using XparkingContext DB = new(_connectionString);

            DB.Update(entity);
            return await DB.SaveChangesAsync();
        }
        public async Task<int> UpdateRangeAsync(List<TEntity> entities)
        {
            using XparkingContext DB = new(_connectionString);

            DB.UpdateRange(entities);
            return await DB.SaveChangesAsync();
        }

        public async Task<int> RemoveAsync(TEntity entity)
        {
            using XparkingContext DB = new(_connectionString);

            DB.Remove(entity);
            return await DB.SaveChangesAsync();
        }

        public async Task<int> RemoveAllAsync(List<TEntity> entities)
        {
            using XparkingContext DB = new(_connectionString);

            DB.RemoveRange(entities);
            return await DB.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using XparkingContext DB = new(_connectionString);

            IQueryable<TEntity> query = DB.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using XparkingContext DB = new(_connectionString);

            IQueryable<TEntity> query = DB.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.FirstOrDefaultAsync();
        }
    }
}
