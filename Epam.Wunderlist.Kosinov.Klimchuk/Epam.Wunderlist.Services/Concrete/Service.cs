using Epam.Wunderlist.DataAccess.Interfaces.Repository;
using Epam.Wunderlist.DomainModel;
using Epam.Wunderlist.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Epam.Wunderlist.Services.Services
{
    public abstract class Service<TEntity> : ICrudService<TEntity>
        where TEntity : Entity
    {
        #region Fields
        protected readonly IUnitOfWork _uow;
        protected readonly IRepository<TEntity> _repository;
        #endregion

        #region Constructor
        protected Service(IUnitOfWork uow, IRepository<TEntity> repository)
        {
            this._uow = uow;
            this._repository = repository;
        }
        #endregion

        #region Methods
        public virtual TEntity Create(TEntity entity)
        {
            if (entity == null)                            
            {
                throw new ArgumentNullException("entity");
            }
            var result = _repository.Create(entity);
            if (result != null)
                _uow.Commit();

            return result;
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _repository.Delete(entity);
            _uow.Commit();
        }

        public virtual TEntity Get(int id)
        {
            return _repository.GetById(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _repository.Update(entity);
            _uow.Commit();
        }
        #endregion
    }
}
