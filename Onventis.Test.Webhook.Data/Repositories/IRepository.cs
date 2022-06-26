using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Onventis.Test.Webhook.Data.Repositories
{
    public interface IRepository<TEntity> : IRepositoryBase<TEntity>
        where TEntity : class
    {
        Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>> where);
    }
}
