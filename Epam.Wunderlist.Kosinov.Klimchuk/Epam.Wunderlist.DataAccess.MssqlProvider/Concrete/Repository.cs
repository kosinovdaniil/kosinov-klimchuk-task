﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using Epam.Wunderlist.DomainModel;
using Epam.Wunderlist.DataAccess.MssqlProvider.Interfaces.Repository;

namespace Epam.Wunderlist.DataAccess.MssqlProvider.Concrete
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
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
        public virtual IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>();
        }

        public virtual TEntity GetById(int id)
        {
            var entity = context.Set<TEntity>().FirstOrDefault(item => item.Id == id);
            if (entity == null)
            {
                throw new ArgumentException("There is no item with such id", "id");
            }
            return entity;
        }

        public virtual IEnumerable<TEntity> GetByPredicate(Expression<Func<TEntity, bool>> f)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity Create(TEntity entity)
        {
            var elem = context.Set<TEntity>().Add(entity);
            return elem;
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var entities = context.Set<TEntity>();
            var elem = context.Set<TEntity>().FirstOrDefault(item => item.Id == entity.Id);
            if (elem == null)
            {
                return;
            }
            entities.Remove(elem);
        }

        public virtual void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var elem = context.Set<TEntity>().FirstOrDefault(item => item.Id == entity.Id);
            if (elem == null)
            {
                throw new ArgumentException("There is no element with such id", "entity");
            }
            //CopyEntityFields(entity, elem);
        }
        #endregion
    }
}