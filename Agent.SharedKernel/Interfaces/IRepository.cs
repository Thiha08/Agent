using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agent.SharedKernel.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity, IAggregateRoot
    {
        // Marks an entity as new
        Task AddAsync(TEntity entity);

        // Marks an entity as modified
        Task UpdateAsync(TEntity entity);

        // Marks an entity to be removed
        Task DeleteAsync(TEntity entity);

        Task DeleteAsync(Expression<Func<TEntity, bool>> where);

        // Get an entity by int id
        Task<TEntity> GetByIdAsync(int id);

        // Get an entity using delegate
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> where);

        // Gets entities using delegate
        Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where);

        // Gets all entities of type T
        IQueryable<TEntity> GetAll();
    }
}
