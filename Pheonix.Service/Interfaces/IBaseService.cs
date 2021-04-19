using FluentValidation;
using Pheonix.Domain.Entities;
using System.Collections.Generic;

namespace Pheonix.Service.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        TEntity Add<TValidador>(TEntity entity) where TValidador : AbstractValidator<TEntity>;
        void Delete(int id);
        IList<TEntity> GetAll();
        TEntity Get(int id);
        TEntity Update<TValidator>(TEntity entity) where TValidator : AbstractValidator<TEntity>;
    }
}
