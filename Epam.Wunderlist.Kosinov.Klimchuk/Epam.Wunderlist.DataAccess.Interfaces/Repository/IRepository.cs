﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Epam.Wunderlist.DomainModel;

namespace Epam.Wunderlist.DataAccess.Interfaces.Repository
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int key);

        IEnumerable<TEntity> GetByPredicate(Expression<Func<TEntity, bool>> f);

        TEntity Create(TEntity e);

        void Delete(TEntity e);

        void Update(TEntity entity);
    }
}