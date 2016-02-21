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
        protected readonly IUnitOfWork _uow;
        protected readonly IRepository<TDalEntity> _repository;
        #endregion

        #region Constructor
        protected Service(IUnitOfWork uow, IRepository<TDalEntity> repository)
        {
            this._uow = uow;
            this._repository = repository;
        }
        #endregion

        #region Methods
        public virtual TBllEntity Create(TBllEntity entity)
        {
            if (entity == null)                            //отследить в контроллерах
            {
                throw new ArgumentNullException("entity");
            }
            var temp = _repository.Create(MapToDalEntity(entity));
            if (temp != null)
                _uow.Commit();

            return MapToBllEntity(temp);
        }

        public virtual void Delete(TBllEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _repository.Delete(MapToDalEntity(entity));
            _uow.Commit();
        }

        public virtual TBllEntity Get(int id)
        {
            return MapToBllEntity(_repository.GetById(id));
        }

        public virtual IEnumerable<TBllEntity> GetAll()
        {
            return _repository.GetAll().Select(MapToBllEntity);
        }

        public virtual void Update(TBllEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _repository.Update(MapToDalEntity(entity));
            _uow.Commit();
        }
        #endregion

        #region Protected

        protected abstract TDalEntity MapToDalEntity(TBllEntity entity);

        protected abstract TBllEntity MapToBllEntity(TDalEntity entity);

        #endregion
    }
}
