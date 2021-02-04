using Agent.SharedKernel;
using Agent.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Agent.Infrastructure.Data
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, IAggregateRoot
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public EfRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            var entry = _dbSet.SingleOrDefault(e => e.Id == entity.Id);
            _dbContext.Entry(entry).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Expression<Func<TEntity, bool>> where)
        {
            foreach (TEntity entity in _dbSet.Where(where).AsEnumerable())
                _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _dbSet.Where(where).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where)
        {
            return await _dbSet.Where(where).ToListAsync();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }
    }
}
