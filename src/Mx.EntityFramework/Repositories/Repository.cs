using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mx.EntityFramework.Contracts;

namespace Mx.EntityFramework.Repositories
{
    public abstract class Repository<TEntity> : RepositoryReadOnly<TEntity>, IRepository<TEntity> where TEntity : class
    {
        protected Repository(IEntityContext entityContext) : base(entityContext)
        {
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync().ConfigureAwait(false);
        }

        public void Insert(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            if (!Exists(entity))
            {
                Context.Set<TEntity>().Attach(entity);
            }
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            if (!Exists(entity))
            {
                Context.Set<TEntity>().Attach(entity);
            }

            Context.Set<TEntity>().Remove(entity);
        }

        private bool Exists(TEntity entity)
        {
            return Context.Set<TEntity>().Local.Any(attachedEntity => attachedEntity == entity);
        }
        
    }
}