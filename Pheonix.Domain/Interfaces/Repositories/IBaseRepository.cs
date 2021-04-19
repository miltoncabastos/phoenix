using Pheonix.Domain.Entities;
using System.Linq;

namespace Pheonix.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        TEntity Select(int id);
        IQueryable<TEntity> Query();
        IQueryable<TEntity> QueryReadOnly();
    }
}
