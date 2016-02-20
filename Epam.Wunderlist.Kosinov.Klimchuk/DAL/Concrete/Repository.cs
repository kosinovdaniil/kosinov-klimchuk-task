using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interface.Repository;
using DAL.Interfacies.DTO;
using ORM;
using System.Data.Entity;
using System.Linq.Expressions;

namespace DAL.Concrete
{
    public abstract class Repository<TDalEntity, TEntity> : IRepository<TDalEntity>
        where TDalEntity : DalEntity
        where TEntity : Entity
    {
        #region Fields

        protected readonly DbContext context;

        #endregion

        #region Constructors

        protected Repository(DbContext context)
        {
            this.context = context;
        }
        #endregion

        #region Methods
        public virtual IEnumerable<TDalEntity> GetAll()
        {
            return context.Set<TEntity>().ToList().Select(MapToDalEntity);
        }

        public virtual TDalEntity GetById(int id)
        {
            var entity = context.Set<TEntity>().FirstOrDefault(item => item.Id == id);
            if (entity == null)
            {
                throw new ArgumentException("There is no item with such id", "id");
            }
            return MapToDalEntity(entity);
        }

        public virtual IEnumerable<TDalEntity> GetByPredicate(Expression<Func<TDalEntity, bool>> f)
        {
            throw new NotImplementedException();
        }

        public virtual TDalEntity Create(TDalEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var e = context.Set<TEntity>().Add(MapToEntity(entity));
            return MapToDalEntity(e);
        }

        public virtual void Delete(TDalEntity dalEntity)
        {
            if (dalEntity == null)
            {
                throw new ArgumentNullException("dalEntity");
            }
            var entities = context.Set<TEntity>();
            var entity = entities.FirstOrDefault(item => item.Id == dalEntity.Id);
            if (entity == null)
            {
                return;
            }
            entities.Remove(entity);
        }

        public virtual void Update(TDalEntity dalEntity)
        {
            if (dalEntity == null)
            {
                throw new ArgumentNullException("dalEntity");
            }
            var entity = context.Set<TEntity>().FirstOrDefault(item => item.Id == dalEntity.Id);
            if (entity == null)
            {
                throw new ArgumentException("There is no element with such id", "dalEntity");
            }
            CopyEntityFields(dalEntity, entity);
        }

        #region Protected methods

        protected abstract TDalEntity MapToDalEntity(TEntity entity);

        protected abstract TEntity MapToEntity(TDalEntity dalEntity);

        protected abstract void CopyEntityFields(TDalEntity source, TEntity target);

        #endregion
        #endregion
    }
}
