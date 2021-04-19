using FluentValidation;
using Pheonix.Domain.Entities;
using Pheonix.Domain.Interfaces;
using Pheonix.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pheonix.Service.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        protected BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public TEntity Add<TValidador>(TEntity entity) where TValidador : AbstractValidator<TEntity>
        {
            entity.Activate();
            Validate(entity, Activator.CreateInstance<TValidador>());
            _baseRepository.Insert(entity);
            return entity;
        }

        public void Delete(int id)
        {
            _baseRepository.Delete(id);
        }

        public IList<TEntity> GetAll()
        {
            return _baseRepository.Query().ToList();
        }

        public TEntity Get(int id)
        {
            return _baseRepository.Select(id);
        }

        public TEntity Update<TValidator>(TEntity entity) where TValidator : AbstractValidator<TEntity>
        {
            Validate(entity, Activator.CreateInstance<TValidator>());
            _baseRepository.Update(entity);
            return entity;
        }

        private static void Validate(TEntity entity, AbstractValidator<TEntity> validaor)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Registros não detectados!");

            validaor.ValidateAndThrow(entity);
        }
    }
}
