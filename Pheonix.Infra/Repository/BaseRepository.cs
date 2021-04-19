using Microsoft.EntityFrameworkCore;
using Pheonix.Domain.Entities;
using Pheonix.Domain.Interfaces;
using Pheonix.Infra.Context;
using System.Linq;

namespace Pheonix.Infra.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly PheonixContext _pheonixContext;

        protected BaseRepository(PheonixContext pheonixContext)
        {
            _pheonixContext = pheonixContext;
        }

        public void Delete(int id)
        {
            var entity = Select(id);
            entity.Disable();
            Update(entity);
        }

        public void Insert(TEntity entity)
        {
            entity.Activate();
            _pheonixContext.Set<TEntity>().Add(entity);
            _pheonixContext.SaveChanges();
        }        

        public TEntity Select(int id)
        {
            return _pheonixContext.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity)
        {
            _pheonixContext.Set<TEntity>().Update(entity);
            _pheonixContext.SaveChanges();
        }

        public IQueryable<TEntity> Query()
        {
            return _pheonixContext.Set<TEntity>();
        }

        public IQueryable<TEntity> QueryReadOnly()
        {
            return _pheonixContext.Set<TEntity>().AsNoTracking();
        }
    }
}
