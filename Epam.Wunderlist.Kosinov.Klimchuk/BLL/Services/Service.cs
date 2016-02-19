using BLL.Interface.Entities;
using BLL.Interface.Services;
using DAL.Interface.Repository;
using DAL.Interfacies.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.Services
{
    public abstract class Service<TBllEntity, TDalEntity> : ICrudService<TBllEntity>
        where TBllEntity : BllEntity
        where TDalEntity : DalEntity
    {
        #region Fields
        protected readonly IUnitOfWork uow;
        protected readonly IRepository<TDalEntity> repository;
        #endregion

        #region Constructor
        protected Service(IUnitOfWork uow, IRepository<TDalEntity> repository)
        {
            this.uow = uow;
            this.repository = repository;
        }
        #endregion

        #region Methods
        public virtual TBllEntity Create(TBllEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var temp = repository.Create(MapToDalEntity(entity));
            if (temp != null)
                uow.Commit();

            return MapToBllEntity(temp) ?? null;
        }

        public virtual void Delete(TBllEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            repository.Delete(MapToDalEntity(entity));
            uow.Commit();
        }

        public virtual TBllEntity Get(int id)
        {
            return MapToBllEntity(repository.GetById(id));
        }

        public virtual IEnumerable<TBllEntity> GetAll()
        {
            return repository.GetAll().Select(MapToBllEntity);
        }

        public virtual void Update(TBllEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            repository.Update(MapToDalEntity(entity));
            uow.Commit();
        }
        #endregion

        #region Protected

        protected abstract TDalEntity MapToDalEntity(TBllEntity entity);

        protected abstract TBllEntity MapToBllEntity(TDalEntity entity);

        #endregion
    }
}
