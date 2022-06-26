using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Onventis.Test.Webhook.Data.Repositories
{
    public class EfRepository<TEntity> : RepositoryBase<TEntity>, IRepository<TEntity> where TEntity : class
    {
        public EfRepository(WebhookDbContext dbContext) : base(dbContext) 
        {
        }

        public EfRepository(WebhookDbContext dbContext, ISpecificationEvaluator<TEntity> specificationEvaluator) : base(dbContext, specificationEvaluator)
        {
        }

        public Task<List<TEntity>> ListAsync(Expression<Func<TEntity, bool>> where)
        {
            var specification = new WhereCSpecification(where);

            return ListAsync(specification);

        }

        private class WhereCSpecification : Specification<TEntity>
        {
            public WhereCSpecification(Expression<Func<TEntity, bool>> where)
            {
                Query.Where(where);
            }
        }
    }
}
